using ExpenseSolution.Domain.Users;

namespace ExpenseSolution.Utils.Interfaces
{
    public interface IJwt
    {
        string GenerateUserToken(int id, string email, UserRoles role);
        IDictionary<string, object> DecodeToken(string token);
        bool ValidateToken(string token);
    }
}
