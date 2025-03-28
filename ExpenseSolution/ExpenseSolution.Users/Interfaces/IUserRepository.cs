using ExpenseSolution.Infrastructure;
using ExpenseSolution.Models;

namespace ExpenseSolution.Users.Interfaces
{
    public interface IUserRepository: IGenericRepository<UserDomain>
    {
        Task<UserDomain> GetByEmail(string email);
    }
}
