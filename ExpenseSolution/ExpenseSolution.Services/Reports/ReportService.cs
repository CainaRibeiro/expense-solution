using ExpenseSolution.Domain.Reports;
using ExpenseSolution.Repositories.Reports;
using ExpenseSolution.Services.Reports.DTOs;

namespace ExpenseSolution.Services.Reports
{
    public class ReportService(IReportRepository repository) : IReportService
    {
        private readonly IReportRepository _repository = repository;

        public async Task<bool> GenerateReport(CreateReportDTO report)
        {
            var r = new ReportDomain(report.Period, report.TotalExpenses, report.TotalRefunds);
            var result = await _repository.Create(r);
            return result != null;
        }

        public async Task<List<ReportDomain>> GetAllReports()
        {
            return await _repository.GetAll();
        }

        public async Task<List<ReportDomain>> GetReportsByPeriod(ReportsByPeriodDTO reportsByPeriod)
        {
            return await _repository.GetByPeriod(reportsByPeriod.StartDate, reportsByPeriod.EndDate);
        }
    }
}
