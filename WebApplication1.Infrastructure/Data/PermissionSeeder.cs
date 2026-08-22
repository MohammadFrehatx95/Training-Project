using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Domain.Constants;
using WebApplication1.Domain.Entities;

namespace WebApplication1.Infrastructure.Data
{
    public static class PermissionSeeder
    {
        public static async Task SeedAsync(AppDbContext context)
        {
            var permissions = new List<Permission>
        {
            new Permission
            {
                Name = Permissions.EmployeesRead,
                Description = "View employees"
            },
            new Permission
            {
                Name = Permissions.EmployeesCreate,
                Description = "Create employees"
            },
            new Permission
            {
                Name = Permissions.EmployeesUpdate,
                Description = "Update employees"
            },
            new Permission
            {
                Name = Permissions.EmployeesDelete,
                Description = "Delete employees"
            }
        };

            foreach (var permission in permissions)
            {
                if (!await context.Permissions.AnyAsync(p => p.Name == permission.Name))
                {
                    context.Permissions.Add(permission);
                }

            }

            await context.SaveChangesAsync();

        }
    }
}
