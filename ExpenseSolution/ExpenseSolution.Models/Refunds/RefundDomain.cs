namespace ExpenseSolution.Domain.Refunds
{
    public class RefundDomain(int expenseId, RefundStatusEnum status, DateTime requestDate)
    {
        public int Id { get; set; }
        public int ExpenseId { get; set; } = expenseId;
        public RefundStatusEnum Status { get; set; } = status;
        public DateTime RequestDate { get; set; } = requestDate;
    }
}
