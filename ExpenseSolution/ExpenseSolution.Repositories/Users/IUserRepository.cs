using ExpenseSolution.Domain.Users;

namespace ExpenseSolution.Repositories.Users
{
    public interface IUserRepository: IGenericRepository<UserDomain>
    {
        Task<UserDomain> GetByEmail(string email);
    }
}
