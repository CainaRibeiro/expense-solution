using ExpenseSolution.Domain.Expenses;

namespace ExpenseSolution.Repositories.Expenses
{
    public interface IExpenseRepository: IGenericRepository<ExpenseDomain>
    {
        Task<bool> UpdateStatus(int id, ExpenseStatusEnum status);
        Task<List<ExpenseDomain>> GetApprovedExpensesByPeriod(DateTime startAt, DateTime endAt);
    }
}
