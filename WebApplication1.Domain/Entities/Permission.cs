using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Domain.Entities
{
    public class Permission
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();

        public ICollection<UserPermission> UserPermissions { get; set; } = new List<UserPermission>();

    }
}
