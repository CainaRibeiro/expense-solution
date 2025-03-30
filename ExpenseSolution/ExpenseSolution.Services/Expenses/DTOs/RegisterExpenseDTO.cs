using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseSolution.Services.Expenses.DTOs
{
    public class RegisterExpenseDTO
    {
        public int UserId { get; set; }
        public string Type { get; set; } = string.Empty;
        public decimal Value { get; set; }
        public string Receipt { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
