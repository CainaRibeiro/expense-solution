using ExpenseSolution.DTOs.Users;
namespace ExpenseSolution.Interfaces
{
    public interface IJwt
    {
        string GenerateUserToken(UserTokenDTO usertToken);
        IDictionary<string, object> DecodeToken(string token);
    }
}
