using ExpenseSolution.Domain.Expenses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseSolution.Services.Expenses.DTOs
{
    public class UpdateStatusDTO
    {
        public int Id { get; set; }
        public ExpenseStatusEnum Status { get; set; }
    }
}
