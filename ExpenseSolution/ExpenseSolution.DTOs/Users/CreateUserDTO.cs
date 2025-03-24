using ExpenseSolution.Enums.Users;

namespace ExpenseSolution.DTOs.Users
{
    public class CreateUserDTO
    {
        public string Name { get;  set; }
        public UserRoles Role { get;  set; }
        public string Email { get;  set; }
        public string Password { get; set; }
    }
}
