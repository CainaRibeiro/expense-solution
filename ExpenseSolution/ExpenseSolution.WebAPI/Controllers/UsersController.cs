using ExpenseSolution.Domain.Users;
using ExpenseSolution.Services.Users;
using ExpenseSolution.Services.Users.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseSolution.WebAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UsersController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginDTO data)
        {
            var token = await _userService.Authenticate(data.Username, data.Password);

            return Ok(token);
        }

        [HttpPost("create")]
        public async Task<ActionResult<UserDomain>> Create(CreateUserDTO data)
        {
            await _userService.CreateUser(data);

            return Created("User created successfully", "");
        }
    }
}
