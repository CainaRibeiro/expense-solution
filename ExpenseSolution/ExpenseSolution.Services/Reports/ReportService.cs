using ExpenseSolution.Domain.Expenses;
using ExpenseSolution.Domain.Reports;
using ExpenseSolution.Repositories.Expenses;
using ExpenseSolution.Repositories.Refund;
using ExpenseSolution.Repositories.Reports;
using ExpenseSolution.Services.Reports.DTOs;

namespace ExpenseSolution.Services.Reports
{
    public class ReportService(
        IReportRepository repository,
        IExpenseRepository expenseRepository,
        IRefundRepository refundRepository) : IReportService
    {
        private readonly IReportRepository _repository = repository;
        private readonly IExpenseRepository _expenseRepository = expenseRepository;
        private readonly IRefundRepository _refundRepository = refundRepository;

        public async Task<bool> GenerateReport(CreateReportDTO report)
        {// BUSCAR TODOS OS EXPENSES E REFUNDS ATIVOS, NÃO PEGAR VALORES DO FRONT
            var expenses = await _expenseRepository.GetApprovedExpensesByPeriod(report.StartAt, report.EndAt);
            var totalExpenses = expenses.Aggregate(0m, (acc, curr) => acc + curr.Value);
            var refunds = await _refundRepository.GetApprovedByPeriod(report.StartAt, report.EndAt);
            var totalRefunds = refunds.Aggregate(0m, (acc, curr) => acc + curr.Expense?.Value ?? 0m);
            var period = DateTime.Now;
            var r = new ReportDomain(period, totalExpenses, totalRefunds);
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
