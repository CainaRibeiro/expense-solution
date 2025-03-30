using ExpenseSolution.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace ExpenseSolution.Repositories.Users
{
    public class UserRepository(AppDbContext context) : GenericRepository<UserDomain>(context), IUserRepository
    {
        protected readonly AppDbContext _userContext = context;
        public async Task<UserDomain> GetByEmail(string email)
        {
            var user = await _userContext.Users.FirstOrDefaultAsync(u => u.Email == email);

            return user ?? throw new Exception("User not found");
        }
    }
}
