using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Infrastructure.Identity
{
    public static class IdentitySeederRole
    {
        public static async Task SeedRolesAsync(RoleManager<IdentityRole<long>> roleManager)
        {
            if(!await roleManager.RoleExistsAsync("HR"))
            {
                await roleManager.CreateAsync(new IdentityRole<long>("HR"));
            }

            if (!await roleManager.RoleExistsAsync("Employee"))
            {
                await roleManager.CreateAsync(new IdentityRole<long>("Employee"));
            }

        }
    }
}
