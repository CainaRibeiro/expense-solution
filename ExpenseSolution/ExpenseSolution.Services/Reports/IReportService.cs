using ExpenseSolution.Domain.Reports;
using ExpenseSolution.Services.Reports.DTOs;

namespace ExpenseSolution.Services.Reports
{
    public interface IReportService
    {
        Task<bool> GenerateReport(CreateReportDTO report);
        Task<List<ReportDomain>> GetAllReports();
        Task<List<ReportDomain>> GetReportsByPeriod(ReportsByPeriodDTO reportsByPeriod);
    }
}
