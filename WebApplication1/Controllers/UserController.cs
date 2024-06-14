using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService IUserService, IMapper mapper)
        {
            _userService = IUserService;
            _mapper = mapper;
        }

        [HttpGet("current")]
        //[Authorize]
        public async Task<IActionResult> GetCurrentUser()
        {
            var currentUser = await _userService.GetCurrentLoggedInUser(User);
            if (currentUser == null)
            {
                return BadRequest();
            }

            return Ok(currentUser);
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<List<UserDTO>> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            var result = _mapper.Map<List<UserDTO>>(users);
            return result;
        }

        [HttpGet("getUser/{id}")]

        public async Task<ActionResult<UserDTO>> GetUserById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var result = await _userService.GetUserById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> CreateUser([FromBody] UserInsertDTO userDto)
        {

            if (userDto == null)
            {
                return BadRequest();
            }
            IUser user = await _userService.CreateUser(userDto);
            return Ok(user);
        }

        


        [HttpPut]
        [Route("UpdateUserById")]
        public async Task<ActionResult<bool>> UpdateUser(int userId, [FromBody] UserInsertDTO userInsertDto)
        {
            if (userId == 0)
            {
                return BadRequest();
            }

            var updatedUser = await _userService.UpdateUser(userId, userInsertDto);
            if (!updatedUser)
            {
                return BadRequest();
            }
            return Ok(updatedUser);
        }

    

        [HttpDelete("{id}", Name = "DeleteUser")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var result = await _userService.DeleteUser(id);

            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }

    }
}

