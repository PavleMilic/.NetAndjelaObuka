using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApplication1.shared.Interfaces;

namespace WebApplication1.models
{
    public class User: IUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public int Jmbg { get; set; }

        public int CityId { get; set; }
        public string UserName { get; set; }

        public string PasswordHash { get; set; }
        public string Salt { get; set; }

        public City City { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }




    }
}
