using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseSolution.Infrastructure
{
    public interface IGenericRepository<T> where T: class
    {
        Task<T> Create(T entity);
        Task<T> GetById(int id);
        Task Delete(int id);
    }
}
