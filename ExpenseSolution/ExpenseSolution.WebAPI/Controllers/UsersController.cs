using ExpenseSolution.DTOs.Users;
using ExpenseSolution.Users.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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
            var token = _userService.Authenticate(data.username, data.password);

            return Ok(token);
        }

        [HttpPost("create")]
        public IActionResult Create(CreateUserDTO data)
        {
            _userService.CreateUser(data);

            return Created("User created successfully", "");
        }
    }
}
