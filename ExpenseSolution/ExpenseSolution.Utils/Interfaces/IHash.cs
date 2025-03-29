namespace ExpenseSolution.Utils.Interfaces
{
    public interface IHash
    {
        string HashPassword(string password);

        bool ComparePassword(string password, string hashPassword);
    }
}
