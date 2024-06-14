using System.ComponentModel.DataAnnotations;
using WebApplication1.shared.Interfaces;

namespace WebApplication1.models
{
    public class UserRole : IUserRole
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int RoleId { get; set; }
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }

    }
}
