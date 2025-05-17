using ExpenseSolution.Domain.Refunds;

namespace ExpenseSolution.Repositories.Refund
{
    public interface IRefundRepository: IGenericRepository<RefundDomain>
    {
        Task<bool> UpdateStatus(int id, RefundStatusEnum status);
        Task<RefundDomain> GetByExpenseId(int ExpenseId);
        Task<List<RefundDomain>> GetApprovedByPeriod(DateTime startAt, DateTime endAt);
    }
}
