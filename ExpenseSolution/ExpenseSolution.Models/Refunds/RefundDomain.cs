using ExpenseSolution.Domain.Expenses;

namespace ExpenseSolution.Domain.Refunds
{
    public class RefundDomain(int expenseId, RefundStatusEnum status)
    {
        public int Id { get; set; }
        public int ExpenseId { get; set; } = expenseId;
        public RefundStatusEnum Status { get; set; } = status;
        public DateTime RequestDate { get; set; } = DateTime.Now;
        public ExpenseDomain? Expense { get; set; }
    }
}
