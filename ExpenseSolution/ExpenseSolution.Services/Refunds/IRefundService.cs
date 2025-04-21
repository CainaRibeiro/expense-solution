using ExpenseSolution.Domain.Refunds;
using ExpenseSolution.Services.Refunds.DTOs;

namespace ExpenseSolution.Services.Refunds
{
    public interface IRefundService
    {
        Task<bool> CreateRefund(RegisterRefundDTO registerRefund);
        Task<List<RefundDomain>> GetAllRefunds();
        Task<bool> EvaluateRefund(EvaluateRefundDTO evaluate);
    }
}
