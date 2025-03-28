using ExpenseSolution.Data;
using ExpenseSolution.Infrastructure;
using ExpenseSolution.Models;
using ExpenseSolution.Users.Interfaces;

namespace ExpenseSolution.Users
{
    public class UserRepository : GenericRepository<UserDomain>, IUserRepository
    {
        private readonly AppDbContext _c;

        public UserRepository(AppDbContext context) : base(context)
        {
            _c = context;
        }

        public async Task<UserDomain> GetByEmail(string email)
        {
            var user = await _c.Users.FindAsync(email);

            return user ?? throw new Exception("User not found");
        }
    }
}
