using ExpenseSolution.Data;
using ExpenseSolution.Models;
using ExpenseSolution.Users.Interfaces;

namespace ExpenseSolution.Users
{
    public class UserRepository(AppDbContext context) : IUserRepository
    {
        private readonly AppDbContext _context = context;
        public async Task<UserDomain> GetByEmail(string email)
        {
            var user = await _context.Users.FindAsync(email);

            return user ?? throw new Exception("User not found");
        }
    }
}
