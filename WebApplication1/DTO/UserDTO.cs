using WebApplication1.models;
using WebApplication1.shared.Interfaces;

namespace WebApplication1.DTO
{
    public class UserDTO : IUser
    {
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
        public List<string> Roles { get; set; }

    }
}
