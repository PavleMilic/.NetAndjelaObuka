using WebApplication1.models;
using WebApplication1.shared.Interfaces;

namespace WebApplication1.DTO
{
    public class UserInsertDTO : IUserInsert
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public int Jmbg { get; set; }
        public int CityId { get; set; }

        public List<int> RoleIds { get; set; }
    }
}
