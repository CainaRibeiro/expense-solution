using ExpenseSolution.Domain.Reports;
using Microsoft.EntityFrameworkCore;

namespace ExpenseSolution.Repositories.Reports
{
    public class ReportRepository(AppDbContext context) : GenericRepository<ReportDomain>(context), IReportRepository
    {
        private readonly AppDbContext _reportContext = context;
        async public Task<List<ReportDomain>> GetByPeriod(DateTime startTime, DateTime endTime)
        {
            return await _reportContext
                .Reports
                .Where(r => r.Period >= startTime && r.Period <= endTime)
                .ToListAsync();
        }
    }
}
