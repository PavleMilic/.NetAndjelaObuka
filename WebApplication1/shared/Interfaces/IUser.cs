using WebApplication1.models;

namespace WebApplication1.shared.Interfaces
{
    public interface IUser
    {
        public int Id { get; } // interfejsi imaju samo gettere
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public int Age { get; }
        public int Jmbg { get; }
        public int CityId { get; }
        public string UserName { get; }
        public string PasswordHash { get; }
        public string Salt { get; }
        public City City { get; }
    }
}
