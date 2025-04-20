namespace ExpenseSolution.Domain.Reports
{
    public class ReportDomain(DateTime period, decimal totalExpenses, decimal totalRefunds)
    {
        public int Id { get; set; }
        public DateTime Period { get; set; } = period;
        public decimal TotalExpenses { get; set; } = totalExpenses;
        public decimal TotalRefunds { get; set; } = totalRefunds;
    }
}
