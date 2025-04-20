using ExpenseSolution.Domain.Reports;

namespace ExpenseSolution.Repositories.Reports
{
    public interface IReportRepository: IGenericRepository<ReportDomain>
    {
        Task<List<ReportDomain>> GetByPeriod(DateTime startTime, DateTime endTime);
    }
}
