using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Domain.Entities
{
    public class RolePermission
    {
        public long RoleId { get; set; }
        public long PermissionId { get; set; }
        public IdentityRole<long> Role { get; set; } = null!;
        public Permission Permission { get; set; } = null!;

    }
}
