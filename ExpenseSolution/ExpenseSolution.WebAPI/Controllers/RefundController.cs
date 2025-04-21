using ExpenseSolution.Services.Refunds;
using ExpenseSolution.Services.Refunds.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExpenseSolution.WebAPI.Controllers
{
    [Route("api/refund")]
    [ApiController]
    public class RefundController(IRefundService service) : ControllerBase
    {
        private readonly IRefundService _service = service;
        [HttpPost("create")]
        public async Task<IActionResult> CreateRefund([FromBody] RegisterRefundDTO registerRefund)
        {
            var result = await _service.CreateRefund(registerRefund);
            if (!result)
            {
                return BadRequest("An error occur while trying to create a refund");
            }
            return Created();
        }

        [HttpPut("evaluate")]
        public async Task<IActionResult> EvaluateRefund([FromBody] EvaluateRefundDTO evaluateRefund)
        {
            var result = await _service.EvaluateRefund(evaluateRefund);
            if (!result)
            {
                return BadRequest("And error occur while trying to update a refund");
            }
            return Ok();
        }
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllRefunds()
        {
            var refunds = await _service.GetAllRefunds();
            if (refunds.Count == 0)
            {
                return NotFound("Refunds not found");
            }
            return Ok(refunds);
        }
    }
}
