using app_homework.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApplication1.Application.Interfaces;
using WebApplication1.Application.Services;
using WebApplication1.Application.Settings;
using WebApplication1.Domain.Entities;
using WebApplication1.Domain.Interfaces;
using WebApplication1.Infrastructure.Data;
using WebApplication1.Infrastructure.Identity;
using WebApplication1.Infrastructure.Repositories;

internal class Program
{
     private static async Task Main(string[] args)
     {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        builder.Services.AddDbContext<AppDbContext>();

        builder.Services
        .AddIdentity<ApplicationUser, IdentityRole<long>>(options =>
        {
           options.Lockout.MaxFailedAccessAttempts = 3;
           options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(365);
           options.Lockout.AllowedForNewUsers = true;
         })
        .AddEntityFrameworkStores<AppDbContext>()
        .AddDefaultTokenProviders();

        // Swagger
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddTransient<LanguageMiddleware>();
        builder.Services.AddTransient<CorrelationIdMiddleware>();

        builder.Services.AddScoped(
            typeof(IGenericReadRepository<>),
            typeof(GenericReadRepository<>));

        builder.Services.AddScoped(
            typeof(IGenericWriteRepository<>),
            typeof(GenericWriteRepository<>));

        builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
        builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

        builder.Services.AddScoped<ICompanyService, CompanyService>();
        builder.Services.AddScoped<IDepartmentService, DepartmentService>();
        builder.Services.AddScoped<IEmployeeService, EmployeeService>();

        builder.Services.AddScoped<IIdentityService, IdentityService>();
        builder.Services.AddScoped<IJwtService, JwtService>();

        builder.Services.Configure<JwtSettings>(
            builder.Configuration.GetSection("Jwt"));

        builder.Services
        .AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme =
              JwtBearerDefaults.AuthenticationScheme;

            options.DefaultChallengeScheme =
              JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            var jwtSettings = builder.Configuration
             .GetSection("Jwt")
             .Get<JwtSettings>()!;

            options.TokenValidationParameters =
              new TokenValidationParameters
              {
                  ValidateIssuer = true,
                  ValidIssuer = jwtSettings.Issuer,

                  ValidateAudience = true,
                  ValidAudience = jwtSettings.Audience,

                  ValidateLifetime = true,

                  ValidateIssuerSigningKey = true,
                  IssuerSigningKey = new SymmetricSecurityKey(
                      Encoding.UTF8.GetBytes(jwtSettings.Key))
              };
        });

        builder.Services.AddAuthorization();

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var roleManager = scope.ServiceProvider
                .GetRequiredService<RoleManager<IdentityRole<long>>>();

            await IdentitySeederRole.SeedRolesAsync(roleManager);

            var context = scope.ServiceProvider
                .GetRequiredService<AppDbContext>();

            await PermissionSeeder.SeedAsync(context);
        }

        // Swagger
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}