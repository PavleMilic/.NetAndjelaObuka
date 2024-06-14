using WebApplication1.models;
using WebApplication1.shared.Interfaces;

namespace WebApplication1.IServices
{
    public interface ICityService
    {
        public Task<List<ICity>> GetAllCities();

        public Task <ICity> GetCityById(int id);
        public Task<ICity> CreateCity(ICityInsert cityInsert);

        public Task<bool> UpdateCity(int cityId, ICityInsert cityInsertDto);

        public Task<bool> DeleteCity(int id);
    }
}
