using WebApplication1.models;

namespace WebApplication1.shared.Interfaces
{
    public interface IUserInsert
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public int Age { get; }
        public int Jmbg { get; }
        public int CityId { get; }
        public List<int> RoleIds { get;}

    }
}
