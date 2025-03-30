using ExpenseSolution.Domain.Expenses;
using Microsoft.EntityFrameworkCore;

namespace ExpenseSolution.Repositories.Expenses
{
    public class ExpenseRepository(AppDbContext context) : GenericRepository<ExpenseDomain>(context), IExpenseRepository
    {
        protected readonly AppDbContext _expenseContext = context;
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

            Console.WriteLine(expense);
            if (expense == null) return false;

            expense.Status = status;

            return await _expenseContext.SaveChangesAsync() == 1;
        }
    }
}
