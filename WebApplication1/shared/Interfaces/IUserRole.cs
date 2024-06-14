using System.ComponentModel.DataAnnotations;
using WebApplication1.models;

namespace WebApplication1.shared.Interfaces
{
    public interface IUserRole
    {
        public int UserId { get;}
        public int RoleId { get; }
        public  User User { get; }
        public  Role Role { get; }
    }
}
