using ExpenseSolution.Domain.Expenses;
using ExpenseSolution.Repositories.Expenses;
using ExpenseSolution.Services.Expenses.DTOs;

namespace ExpenseSolution.Services.Expenses
{
    public class ExpenseService(IExpenseRepository expenseRepository) : IExpenseService
    {
        protected readonly IExpenseRepository _expenseRepository = expenseRepository;

        public async Task<List<ExpenseDomain>> GetAllExpenses()
        {
            return await _expenseRepository.GetAll();
        }

        public async Task<ExpenseDomain> RegisterExpense(RegisterExpenseDTO expenseDTO)
        {
            var expense = new ExpenseDomain(
                expenseDTO.UserId,
                expenseDTO.Type,
                expenseDTO.Value,
                expenseDTO.Receipt,
                expenseDTO.Description
                );

            await _expenseRepository.Create(expense);

            return expense;
        }

        public async Task<bool> UpdateExpenseStatus(UpdateStatusDTO updateStatusDTO)
        {
            return await _expenseRepository.UpdateStatus(updateStatusDTO.Id, updateStatusDTO.Status);
        }

        public async Task<List<ExpenseDomain>> GetPendingExpenses()
        {
            return await _expenseRepository.GetPendingExpenses();
        }

        public async Task<List<ExpenseDomain>> GetNotPendingExpenses()
        {
            return await _expenseRepository.GetNotPendingExpenses();
        }
        public async Task<List<ExpenseDomain>> GetPendingRefundAnalisysExpenses()
        {
            return await _expenseRepository.GetPendingRefundAnalisysExpenses();
        }
    }
}
