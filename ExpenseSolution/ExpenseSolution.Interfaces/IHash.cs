
namespace ExpenseSolution.Interfaces
{
    public interface IHash
    {
        string HashPassword(string password);

        Boolean ComparePassword(string password, string hashPassword);
    }
}
