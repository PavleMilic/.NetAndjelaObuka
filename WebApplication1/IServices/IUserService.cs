using System.Security.Claims;
using WebApplication1.DTO;
using WebApplication1.models;
using WebApplication1.shared.Interfaces;

namespace WebApplication1.IServices
{
    public interface IUserService
    {
        public Task<List<IUser>> GetAllUsers(); // da li sve ove metode u IUserServiceu treba da vracaju interface ili DTO?????
        public Task<IUser> GetUserById(int id);
        public Task<IUser> CreateUser(IUserInsert userIsnsertDto);
        public Task<bool> UpdateUser(int userId, IUserInsert userInsertDto);
        public Task<bool> DeleteUser(int userId);
        public Task<UserDTO> GetCurrentLoggedInUser(ClaimsPrincipal user);
    }
}
