using ExpenseSolution.Domain.Expenses;

namespace ExpenseSolution.Services.Expenses.DTOs
{
    public class RegisterExpenseDTO
    {
        public int UserId { get; set; }
        public ExpenseTypeEnum Type { get; set; }
        public decimal Value { get; set; }
        public string Receipt { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
