using AutoMapper;
using WebApplication1.DTO;
using WebApplication1.models;
using WebApplication1.shared.Interfaces;

namespace WebApplication1.Services
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<IUser, UserDTO>();
            CreateMap<IUserInsert, User>();
            CreateMap<UserDTO, User>();

            CreateMap<LoginUserDTO, LoginUser>().ReverseMap();

            CreateMap<IPermission, Permission>();
            
            //CreateMap<User, UserInsertDTO>().ReverseMap();

            CreateMap<ICity, CityDTO>();
            CreateMap<CityDTO, ICity>();
            CreateMap<ICityInsert, City>().ReverseMap();

            //CreateMap<City, CityInsertDTO>().ReverseMap();
            //CreateMap<City, CityInsertDTO>().ReverseMap();

        }
    }
}