using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Domain.Entities
{
    public class UserPermission
    {
        public long UserId { get; set; }
        public long PermissionId { get; set; }
        public ApplicationUser User { get; set; } = null!;
        public Permission Permission { get; set; } = null!;
    }
}
