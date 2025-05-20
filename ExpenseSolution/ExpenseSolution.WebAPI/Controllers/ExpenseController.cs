using ExpenseSolution.Domain.Expenses;
using ExpenseSolution.Services.Expenses;
using ExpenseSolution.Services.Expenses.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseSolution.WebAPI.Controllers
{
    [Route("api/expense")]
    [ApiController]
    public class ExpenseController(IExpenseService expenseService) : ControllerBase
    {
        protected readonly IExpenseService _service = expenseService;
        [HttpPost("create")]
        public async Task<IActionResult> Register([FromBody] RegisterExpenseDTO registerExpense)
        {
            var expense = await _service.RegisterExpense(registerExpense);

            if (expense == null)
            {
                return BadRequest("An error occur when trying to register an expense");
            }

            return Created("Expense registered", expense);
        }

        [HttpPut("update")]
        public async Task<ActionResult<ExpenseDomain>> UpdateStatus([FromBody] UpdateStatusDTO updateStatus)
        {
            var expense = await _service.UpdateExpenseStatus(updateStatus);

            if (!expense)
            {
                return BadRequest("An error occur when trying to update an expense");
            }

            return Ok("Expense updated");
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllExpenses()
        {
            var expenses = await _service.GetAllExpenses();

            if (expenses.Count == 0) return NotFound();

            return Ok(expenses);
        }

        [HttpGet("pending")]
        public async Task<IActionResult> GetAllPendingExpenses()
        {
            var expenses = await _service.GetPendingExpenses();

            if (expenses.Count == 0) return NotFound();

            return Ok(expenses);
        }

        [HttpGet("notPending")]
        public async Task<IActionResult> GetAllNotPendingExpenses()
        {
            var expenses = await _service.GetNotPendingExpenses();

            if (expenses.Count == 0) return NotFound();

            return Ok(expenses);
        }

        [HttpGet("pendingRefunding")]
        public async Task<IActionResult> GetPendingRefundAnalisysExpenses()
        {
            var expenses = await _service.GetPendingRefundAnalisysExpenses();

            if (expenses.Count == 0) return NotFound();

            return Ok(expenses);
        }
    }
}
