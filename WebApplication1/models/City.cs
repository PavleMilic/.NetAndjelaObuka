using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.shared.Interfaces;

namespace WebApplication1.models
{
    public class City : ICity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CityName { get; set; }
        public string CityState { get; set; }
        public ICollection<User?> Users { get; set; } 
    }
}
