using System.ComponentModel.DataAnnotations;
using WebApplication1.shared.Interfaces;

namespace WebApplication1.models
{
    public class Role : IRole
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public ICollection<RolePermission> RolePermissions { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
