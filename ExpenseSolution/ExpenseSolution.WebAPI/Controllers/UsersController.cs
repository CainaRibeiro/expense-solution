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
        public IActionResult Login(LoginDTO data)
        {
            var token = _userService.Authenticate(data.Username, data.Password);

            return Ok(token.Result);
        }

        [HttpPost("create")]
        public IActionResult Create(CreateUserDTO data)
        {
            _userService.CreateUser(data);

            return Created("User created successfully", "");
        }
    }
}
