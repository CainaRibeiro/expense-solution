using ExpenseSolution.Domain.Expenses;
using Microsoft.EntityFrameworkCore;

namespace ExpenseSolution.Repositories.Expenses
{
    public class ExpenseRepository(AppDbContext context) : GenericRepository<ExpenseDomain>(context), IExpenseRepository
    {
        protected readonly AppDbContext _expenseContext = context;

        public async Task<List<ExpenseDomain>> GetApprovedExpensesByPeriod(DateTime startAt, DateTime endAt)
        {
            return await _expenseContext
                    .Expenses
                    .Where(e => e.Status == ExpenseStatusEnum.APPROVED && (e.CreatedAt >= startAt && e.CreatedAt <= endAt))
                    .ToListAsync();
        }

        public async Task<bool> UpdateStatus(int id, ExpenseStatusEnum status)
        {
            // VERSÃO PARA BANCO REAL
            //var e = await _expenseContext.Expenses
            //    .Where(e => e.Id == expense.Id)
            //    .ExecuteUpdateAsync(setters => setters.SetProperty(e => e.Status, expense.Status));

            //_expenseContext.SaveChanges();
            //return e == 1;

            // VERSÃO PARA IN MEMORY
            var expense = await _expenseContext.Expenses.FirstOrDefaultAsync(e => e.Id == id);

            if (expense == null) return false;

            expense.Status = status;

            return await _expenseContext.SaveChangesAsync() == 1;
        }

        public async Task<List<ExpenseDomain>> GetPendingExpenses()
        {
            return await _expenseContext
                    .Expenses
                    .Where(e => e.Status == ExpenseStatusEnum.PENDING)
                    .ToListAsync();
        }

        public async Task<List<ExpenseDomain>> GetNotPendingExpenses()
        {
            return await _expenseContext
                    .Expenses
                    .Where(e => e.Status != ExpenseStatusEnum.PENDING)
                    .ToListAsync();
        }
    }
}
