using ExpenseSolution.Domain.Expenses;
using ExpenseSolution.Services.Expenses.DTOs;

namespace ExpenseSolution.Services.Expenses
{
    public interface IExpenseService
    {
        Task<bool> UpdateExpenseStatus(UpdateStatusDTO updateStatusDTO);
        Task<ExpenseDomain> RegisterExpense(RegisterExpenseDTO expenseDTO);
        Task<List<ExpenseDomain>> GetAllExpenses();
        Task<List<ExpenseDomain>> GetNotPendingExpenses();
        Task<List<ExpenseDomain>> GetPendingExpenses();
    }
}
