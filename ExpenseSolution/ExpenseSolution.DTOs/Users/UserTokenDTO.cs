
using ExpenseSolution.Enums.Users;

namespace ExpenseSolution.DTOs.Users
{
    public class UserTokenDTO(int id, UserRoles role, string email)
    {
        public int Id { get; set; } = id;
        public UserRoles Role { get; set; } = role;
        public string Email { get; set; } = email;
    }
}
