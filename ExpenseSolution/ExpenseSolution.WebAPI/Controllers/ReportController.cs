using ExpenseSolution.Services.Reports;
using ExpenseSolution.Services.Reports.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseSolution.WebAPI.Controllers
{
    [Route("api/reports")]
    [ApiController]
    public class ReportController(IReportService service) : ControllerBase
    {
        private readonly IReportService _service = service;

        [HttpPost("create")]
        public async Task<IActionResult> CreateReport([FromBody] CreateReportDTO createReport)
        {
            var result = await _service.GenerateReport(createReport);
            if (!result)
            {
                return Problem("Error while trying to create report");
            }
            return Created();
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllReports()
        {
            var reports = await _service.GetAllReports();
            if (reports.Count == 0)
            {
                return NotFound("Reports not found");
            }
            return Ok(reports);
        }

        [HttpGet("getByPeriod")]
        public async Task<IActionResult> GetByPeriod([FromQuery] ReportsByPeriodDTO reportsByPeriod)
        {
            var reports = await _service.GetReportsByPeriod(reportsByPeriod);
            if (reports.Count == 0)
            {
                return NotFound("Reports not found in this period");
            }
            return Ok(reports);
        }
    }
}
