using ExpenseSolution.Domain.Refunds;

namespace ExpenseSolution.Services.Refunds.DTOs
{
    public class EvaluateRefundDTO
    {
        public int ExpenseId { get; set; }
        public RefundStatusEnum Status { get; set; }
    }
}
