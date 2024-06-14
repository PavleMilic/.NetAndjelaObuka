using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO;
using WebApplication1.IServices;
using WebApplication1.models;
using WebApplication1.Services;
using WebApplication1.shared.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;
        private readonly IMapper _mapper;

        public CityController(ICityService cityService, IMapper mapper)
        {
            _cityService = cityService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<List<CityDTO>>> GetAllUsers()
        {

            var cities = await _cityService.GetAllCities();
            var result = _mapper.Map<List<CityDTO>>(cities);
            return result;
        }
        [HttpGet("getCity/{id}")]
        public async Task<ActionResult<CityDTO>> GetCityById(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            var city = await _cityService.GetCityById(id);
            if (city == null)
            {
                 return BadRequest("City does not exist.");
            }
            return Ok(city);
        }

        [HttpPost]

        public async Task<ActionResult<CityDTO>> CreateCity([FromBody] CityInsertDTO cityInsertDto)
        {
            if (cityInsertDto == null)
            {
                return BadRequest();
            }
            ICity cityCreatedId = await _cityService.CreateCity(cityInsertDto);
            return Ok(cityCreatedId);
        }
        [HttpPut]
        [Route("UpdateCityById")]
        public async Task<ActionResult<bool>> UpdateCity(int cityId, [FromBody] CityInsertDTO cityInsertDto)
        {
            if (cityId == 0)
            {
                return BadRequest(); 
            }

            var updatedCity = await _cityService.UpdateCity(cityId, cityInsertDto);
          
            return Ok(updatedCity);
        }
        [HttpDelete("{id}", Name = "DeleteCIty")]
        public async Task<ActionResult> DeleteCity(int id)
        {
            var result = await _cityService.DeleteCity(id);

            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }

    }
}
