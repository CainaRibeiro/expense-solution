namespace ExpenseSolution.Services.Reports.DTOs
{
    public class CreateReportDTO
    {
        public DateTime Period { get; set; }
        public decimal TotalExpenses { get; set; }
        public decimal TotalRefunds { get; set; }
    }
}
