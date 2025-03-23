
using ExpenseSolution.Models;
using Microsoft.EntityFrameworkCore;
namespace ExpenseSolution.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<UserDomain> Users { get; set; }
    }
}
