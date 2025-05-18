namespace ExpenseSolution.Domain.Reports
{
    public class ReportDomain(string period, decimal totalExpenses, decimal totalRefunds)
    {
        public int Id { get; set; }
        public string Period { get; set; } = period;
        public decimal TotalExpenses { get; set; } = totalExpenses;
        public decimal TotalRefunds { get; set; } = totalRefunds;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
