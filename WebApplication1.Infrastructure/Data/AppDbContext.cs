using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using WebApplication1.Domain.Entities;

namespace WebApplication1.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Connections.sqlConStr);
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasMany(d => d.Employees)
                .WithOne(e => e.Department)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<User>().Property(u => u.Id).UseIdentityColumn(5000, 1);

            modelBuilder.Entity<User>(entity => {
               entity.Property(x => x.FirstName).IsRequired();
               entity.Property(x => x.LastName).IsRequired();
               entity.Property(x => x.DateOfBirth).IsRequired();
               entity.Property(x => x.Nationality).IsRequired();
               entity.Property(x => x.Email).IsRequired();
               entity.Property(x => x.UserName).IsRequired();
               entity.Property(x => x.Password).IsRequired();
               entity.Property(x => x.Gender).IsRequired();
               entity.Property(x => x.Created).IsRequired();
               entity.Property(x => x.Updated).IsRequired();
               entity.Property(x => x.NationalNumber).IsRequired();
            });

            modelBuilder.Entity<User>().HasIndex(x => x.NationalNumber).IsUnique();
            modelBuilder.Entity<User>().HasIndex(x => x.Email).IsUnique();
            modelBuilder.Entity<User>().HasIndex(x => x.UserName).IsUnique();

            modelBuilder.Entity<User>().Property(x => x.Created).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<User>().Property(x => x.Updated).HasDefaultValueSql("GETDATE()");

        }
    }
}
