using ExpenseSolution.DTOs.Users;
using ExpenseSolution.Interfaces;
using ExpenseSolution.Users.Interfaces;

namespace ExpenseSolution.Users
{
    public class UserService(IUserRepository repository, IJwt jwt) : IUserService
    {
        private readonly IUserRepository _repository = repository;
        private readonly IJwt _jwt = jwt;
        public async Task<string> Authenticate(string email, string password)
        {
            var user = await _repository.GetByEmail(email);

            var isValid = user.ComparePassword(password);

            if (!isValid)
            {
                throw new UnauthorizedAccessException("Invalid credentials");
            }

            var userTokenDTO = new UserTokenDTO(user.Id, user.Role, user.Email);
            var token = _jwt.GenerateUserToken(userTokenDTO);

            return token;
        }
    }
}
