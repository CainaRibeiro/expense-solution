using ExpenseSolution.Domain.Expenses;
using ExpenseSolution.Domain.Refunds;
using ExpenseSolution.Domain.Reports;
using ExpenseSolution.Domain.Users;
using Microsoft.EntityFrameworkCore;
namespace ExpenseSolution.Repositories
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<UserDomain> Users { get; set; }
        public DbSet<ExpenseDomain> Expenses { get; set; }
        public DbSet<ReportDomain> Reports { get; set; }
        public DbSet<RefundDomain> Refunds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDomain>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Name).HasMaxLength(100).IsRequired();
                entity.Property(u => u.Email).HasMaxLength(255).IsRequired();
                entity.Property(u => u.Password).HasMaxLength(128).IsRequired();
            });

            modelBuilder.Entity<ExpenseDomain>(entity =>
            {
                entity.HasKey(u => u.Id);
            });

            modelBuilder.Entity<ReportDomain>(entity =>
            {
                entity.HasKey(u => u.Id);
            });

            modelBuilder.Entity<RefundDomain>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.HasOne<ExpenseDomain>()
                  .WithMany()
                  .HasForeignKey(r => r.ExpenseId)
                  .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
