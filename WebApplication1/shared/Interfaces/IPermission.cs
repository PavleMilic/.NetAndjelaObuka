using WebApplication1.models;

namespace WebApplication1.shared.Interfaces
{
    public interface IPermission
    {

        public int PermissionId { get; }
        public string PermissionName { get; }

        public ICollection<RolePermission> RolePermissions { get; }
    }
}
