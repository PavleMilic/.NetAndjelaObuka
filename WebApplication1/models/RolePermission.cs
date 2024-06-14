using System.ComponentModel.DataAnnotations;
using WebApplication1.shared.Interfaces;

namespace WebApplication1.models
{
    public class RolePermission : IRolePermission
    {
        [Required]
        public int RoleId { get; set; }
        [Required]
        public int PermissionId { get; set; }
        public Role Role { get; set; }
        public Permission Permission { get; set; }
    }
}
