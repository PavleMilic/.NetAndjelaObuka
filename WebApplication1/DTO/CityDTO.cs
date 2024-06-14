using WebApplication1.models;
using WebApplication1.shared.Interfaces;

namespace WebApplication1.DTO
{
    public class CityDTO : ICity
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public string CityState { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
