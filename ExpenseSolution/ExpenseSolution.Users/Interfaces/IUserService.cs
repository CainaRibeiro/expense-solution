
using ExpenseSolution.Models;

namespace ExpenseSolution.Users.Interfaces
{
    public interface IUserService
    {
        Task<string> Authenticate(string email, string password);
    }
}
