using ExpenseSolution.Domain.Users;
using ExpenseSolution.Repositories.Users;
using ExpenseSolution.Services.Users.DTOs;
using ExpenseSolution.Utils.Interfaces;

namespace ExpenseSolution.Services.Users
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

            var token = _jwt.GenerateUserToken(user.Id, user.Email, user.Role);

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
