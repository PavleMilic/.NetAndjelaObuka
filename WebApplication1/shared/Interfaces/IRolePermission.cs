using System.ComponentModel.DataAnnotations;
using WebApplication1.models;

namespace WebApplication1.shared.Interfaces
{
    public interface IRolePermission
    {
        public int RoleId { get; }
        public int PermissionId { get;  }
        public Role Role { get;  }
        public Permission Permission { get;  }
    }
}
