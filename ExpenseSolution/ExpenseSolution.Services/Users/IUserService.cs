using ExpenseSolution.Services.Users.DTOs;

namespace ExpenseSolution.Services.Users
{
    public interface IUserService
    {
        Task<string> Authenticate(string email, string password);
        Task CreateUser(CreateUserDTO user);
    }
}
