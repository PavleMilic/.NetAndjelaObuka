using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApplication1.Data;
using WebApplication1.DTO;
using WebApplication1.IServices;
using WebApplication1.models;
using WebApplication1.shared.Interfaces;

namespace WebApplication1.Services
{
    public class CityService : ICityService
    {
        private readonly UserDbContext _db;
        public DbSet<City> dbSet;
        public readonly IMapper _mapper;

        public CityService (UserDbContext db, IMapper mapper) 
        {
            _db = db;
            _mapper = mapper;
            dbSet = db.Set<City>();

        }
        public async Task<ICity> CreateCity(ICityInsert cityInsertDto)
        {
            
            var cityToCreate = _mapper.Map<City>(cityInsertDto);
            var cityName = await dbSet.SingleOrDefaultAsync(x => x.CityName.ToLower() == cityToCreate.CityName.ToLower());
            if(cityName != null)
            {
                throw new BadHttpRequestException("City with that name already exists");
            }
            await dbSet.AddAsync(cityToCreate);
            await _db.SaveChangesAsync();
            return cityToCreate;
        }

        public async Task<bool> DeleteCity(int cityId)
        {
            var cityToDelete = await dbSet.SingleOrDefaultAsync(x => x.Id == cityId);
            if(cityToDelete == null)
            {
                throw new BadHttpRequestException("City does not exist");
            }
            dbSet.Remove(cityToDelete);
            await _db.SaveChangesAsync();
            return true;

        }

        public async Task<List<ICity>> GetAllCities()
        {
            var city = await dbSet.ToListAsync();
            return city.ToList<ICity>();
        }

        public async Task<ICity> GetCityById(int cityId)
        {
            var cityById = await dbSet.SingleOrDefaultAsync(x => x.Id == cityId);
            if(cityById == null)
            {
                throw new BadHttpRequestException("City does not exist");
            }
            return cityById;
        }

        public async Task<bool> UpdateCity(int cityId, ICityInsert cityInsertDTO)
        {
            var cityToUpdate = await dbSet.SingleOrDefaultAsync(x => x.Id == cityId);
            if( cityToUpdate == null)
            {
                throw new BadHttpRequestException("City does not exist");
            }
            var cityName = await dbSet.SingleOrDefaultAsync(x => x.CityName.ToLower() == cityToUpdate.CityName.ToLower() && x.Id != cityToUpdate.Id);
            if (cityName != null)
            {          
                throw new BadHttpRequestException("City with that name already exists");
            }
            _mapper.Map(cityInsertDTO, cityToUpdate);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
