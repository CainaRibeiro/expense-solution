using ExpenseSolution.DTOs.Users;
using ExpenseSolution.Enums.Users;
using ExpenseSolution.Interfaces;

namespace ExpenseSolution.Models
{
    public class UserDomain(CreateUserDTO user, IHash hashUtil)
    {
        public int Id { get; set; }
        public string Name { get; private set; } = user.Name;
        public UserRoles Role { get; private set; } = user.Role;
        public string Email { get; private set; } = user.Email;
        private string Password { get; set; } = user.Password;

        private IHash HashUtil { get; set; } = hashUtil;

        public bool ComparePassword(string password)
        {
            return HashUtil.ComparePassword(password, Password);
        }
    }
}
