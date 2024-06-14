using System.ComponentModel.DataAnnotations;
using WebApplication1.shared.Interfaces;

namespace WebApplication1.models
{
    public class Permission : IPermission
    {
        [Key]
        public int PermissionId { get; set; }
        public string ?PermissionName { get; set; }

        public ICollection<RolePermission> RolePermissions { get; set; }
        
    }
}
