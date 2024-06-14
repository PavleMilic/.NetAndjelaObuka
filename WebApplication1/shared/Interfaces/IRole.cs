using WebApplication1.models;

namespace WebApplication1.shared.Interfaces
{
    public interface IRole
    {
        public int RoleId { get; }
        public string RoleName { get; }
        public ICollection<RolePermission> RolePermissions { get; }
        public ICollection<UserRole> UserRoles { get; }
    }
}
