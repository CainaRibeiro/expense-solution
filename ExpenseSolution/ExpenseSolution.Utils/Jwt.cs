using ExpenseSolution.Domain.Users;
using ExpenseSolution.Utils.Interfaces;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
namespace ExpenseSolution.Utils
{
    public class Jwt : IJwt
    {
        public IDictionary<string, object> DecodeToken(string token)
        {
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtDecoder decoder = new JwtDecoder(serializer, urlEncoder);

            var payload = decoder.DecodeToObject<IDictionary<string, object>>(token, "TESTE");
            return payload;
        }

        public string GenerateUserToken(int id, string email, UserRoles role)
        {
            var payload = new Dictionary<string, object>
            {
                { "userId", id },
                { "username", email },
                { "role", role },
                { "exp", DateTimeOffset.UtcNow.AddDays(365).ToUnixTimeSeconds() }
            };

            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

            var token = encoder.Encode(payload, "TESTE");

            return token;
        }
    }
}
