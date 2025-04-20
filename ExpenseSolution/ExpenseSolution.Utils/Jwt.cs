using Azure.Identity;
using ExpenseSolution.Domain.Users;
using ExpenseSolution.Utils.Interfaces;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace ExpenseSolution.Utils
{
    public class Jwt : IJwt
    {
        private const string Secret = "TESTE";
        private readonly IJwtAlgorithm _algorithm;
        private readonly IJsonSerializer _serializer;
        private readonly IBase64UrlEncoder _urlEncoder;
        private readonly IDateTimeProvider _provider;
        private readonly IJwtValidator _validator;

        public Jwt()
        {
            _algorithm = new HMACSHA256Algorithm();
            _serializer = new JsonNetSerializer();
            _urlEncoder = new JwtBase64UrlEncoder();
            _provider = new UtcDateTimeProvider();
            _validator = new JwtValidator(_serializer, _provider);
        }
        public IDictionary<string, object> DecodeToken(string token)
        {
            IJwtDecoder decoder = new JwtDecoder(_serializer, _validator, _urlEncoder, _algorithm);
            
            var payload = decoder.DecodeToObject<IDictionary<string, object>>(token, Secret, verify: true);
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

            IJwtEncoder encoder = new JwtEncoder(_algorithm, _serializer, _urlEncoder);

            var token = encoder.Encode(payload, Secret);

            return token;
        }

        public bool ValidateToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token)) return false;

            try
            {
                var payload = DecodeToken(token);

                return payload.ContainsKey("userId") && payload.ContainsKey("username") && payload.ContainsKey("role");
            }
            catch
            {
                return false;
            }
        }
    }
}
