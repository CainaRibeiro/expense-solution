using ExpenseSolution.Domain.Users;

namespace ExpenseSolution.Services.Users.DTOs
{
    public class CreateUserDTO
    {
        public string Name { get; set; } = string.Empty;
        public UserRoles Role { get;  set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
