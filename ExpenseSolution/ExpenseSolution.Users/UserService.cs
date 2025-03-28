using ExpenseSolution.DTOs.Users;
using ExpenseSolution.Interfaces;
using ExpenseSolution.Models;
using ExpenseSolution.Users.Interfaces;

namespace ExpenseSolution.Users
{
    public class UserService(IUserRepository repository, IJwt jwt, IHash hash) : IUserService
    {
        private readonly IUserRepository _repository = repository;
        private readonly IJwt _jwt = jwt;
        private readonly IHash _hash = hash;
        public async Task<string> Authenticate(string email, string password)
        {
            var user = await _repository.GetByEmail(email);

            var isValid = _hash.ComparePassword(password, user.Password);

            if (!isValid)
            {
                throw new UnauthorizedAccessException("Invalid credentials");
            }

            var userTokenDTO = new UserTokenDTO(user.Id, user.Role, user.Email);
            var token = _jwt.GenerateUserToken(userTokenDTO);

            return token;
        }

        public async Task CreateUser(CreateUserDTO user)
        {
            user.Password = _hash.HashPassword(user.Password);
            var u = new UserDomain(user.Name, user.Role, user.Email, user.Password);
            await _repository.Create(u);
        }
    }
}
