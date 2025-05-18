namespace ExpenseSolution.Domain.Expenses
{
    public class ExpenseDomain(int userId, ExpenseTypeEnum type, decimal value, string receipt, string description)
    {
        public int Id { get; set; }
        public int UserId { get; set; } = userId;
        public ExpenseTypeEnum Type { get; set; } = type;
        public decimal Value { get; set; } = value;
        public string Receipt { get; set; } = receipt;
        public string Description { get; set; } = description;
        public ExpenseStatusEnum Status { get; set; } = ExpenseStatusEnum.PENDING;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
