using ExpenseSolution.Domain.Expenses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseSolution.Repositories.Expenses
{
    public interface IExpenseRepository: IGenericRepository<ExpenseDomain>
    {
        Task<bool> UpdateStatus(int id, ExpenseStatusEnum status); 
    }
}
