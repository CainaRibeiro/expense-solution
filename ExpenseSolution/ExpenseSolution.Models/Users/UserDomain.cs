namespace ExpenseSolution.Domain.Users
{
    public class UserDomain(string name, UserRoles role, string email, string password)
    {
        public int Id { get; set; }
        public string Name { get; private set; } = name;
        public UserRoles Role { get; private set; } = role;
        public string Email { get; private set; } = email;
        public string Password { get; set; } = password;

    }
}
