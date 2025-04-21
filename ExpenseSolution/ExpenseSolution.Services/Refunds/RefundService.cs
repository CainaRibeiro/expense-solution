using ExpenseSolution.Domain.Refunds;
using ExpenseSolution.Repositories.Refund;
using ExpenseSolution.Services.Refunds.DTOs;

namespace ExpenseSolution.Services.Refunds
{
    public class RefundService(IRefundRepository repository): IRefundService
    {
        private readonly IRefundRepository _repository = repository;

        public async Task<bool> CreateRefund(RegisterRefundDTO registerRefund)
        {
            var refund = new RefundDomain(
                registerRefund.ExpenseId,
                RefundStatusEnum.PENDING,
                new DateTime()
                );

            var result = await _repository.Create(refund);
            if (result == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> EvaluateRefund(EvaluateRefundDTO evaluate)
        {
            var refund = await _repository.GetByExpenseId(evaluate.ExpenseId);
            if (refund == null)
            {
                return false;
            }
            return await _repository.UpdateStatus(refund.Id, evaluate.Status);
        }

        public Task<List<RefundDomain>> GetAllRefunds()
        {
            return _repository.GetAll();
        }
    }
}
