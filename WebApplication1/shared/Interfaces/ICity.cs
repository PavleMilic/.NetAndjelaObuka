using WebApplication1.models;

namespace WebApplication1.shared.Interfaces
{
    public interface ICity
    {
        public int Id { get; }
        public string CityName { get; }
        public string CityState { get; }
        public ICollection<User> Users { get;}
    }
}
