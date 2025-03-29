using ExpenseSolution.Utils.Interfaces;

namespace ExpenseSolution.Utils
{
    public class Hash: IHash
    {
        public bool ComparePassword(string password, string hashPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashPassword);
        }

        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
