using AgileBoard.API.Auth;
using AgileBoard.Application.DTOs;
using AgileBoard.Application.Interfaces;
using AgileBoard.Domain.Contracts;
using AgileBoard.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace AgileBoard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly Authentication _authentication;

        public UserController(IUserService userService, Authentication authentication)
        {
            _userService = userService;
            _authentication = authentication;
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO userDto)
        {
            var user = await _userService.Login(userDto);

            if(user == null)
            {
                return NotFound("Invalid email or password");
            }
            string token = _authentication.CreateToken(user);
            return Ok(token);
        }

        

        [HttpPost("Register/")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDTO userDto)
        {
            var user = await _userService.Register(userDto);

            if (user == null)
            {
                return BadRequest();
            }

            return Ok(user);
        }

        [HttpGet("GetUserByEmail/{email}")]
        public async Task<ActionResult<User>> GetUserByEmail(string email)
        {
            var user = await _userService.GetUserEmail(email);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("GetUserById/{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();

            if(users == null)
                return NotFound();

            return Ok(users);
        }

        [HttpDelete("DeleteUser/{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var user = await _userService.DeleteUser(userId);

            if (user == null)
                return NotFound();

            return Ok(user);
        }


    }
}
