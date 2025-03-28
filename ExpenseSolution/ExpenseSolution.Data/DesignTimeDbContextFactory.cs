using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ExpenseSolution.Data
{
    public class DesignTimeDbContextFactory
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseInMemoryDatabase("BancoTeste");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
