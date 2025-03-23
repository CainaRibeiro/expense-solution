using ExpenseSolution.DTOs.Users;
using ExpenseSolution.Interfaces;
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
            IDateTimeProvider provider = new UtcDateTimeProvider();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtDecoder decoder = new JwtDecoder(serializer, urlEncoder);

            var payload = decoder.DecodeToObject<IDictionary<string, object>>(token, "TESTE");
            return payload;
        }

        public string GenerateUserToken(UserTokenDTO userToken)
        {
            var payload = new Dictionary<string, object>
            {
                { "userId", userToken.Id },
                { "username", userToken.Email },
                { "role", userToken.Role },
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
