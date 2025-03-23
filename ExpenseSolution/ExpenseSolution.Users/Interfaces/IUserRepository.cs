using ExpenseSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseSolution.Users.Interfaces
{
    public interface IUserRepository
    {
        Task<UserDomain> GetByEmail(string email);
    }
}
