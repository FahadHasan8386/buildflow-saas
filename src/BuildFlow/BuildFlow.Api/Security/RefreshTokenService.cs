using BuildFlow.Api.Interfaces.Security;
using System.Security.Cryptography;
using System.Text;

namespace BuildFlow.Api.Security
{
    public class RefreshTokenService : IRefreshTokenService
    {
        public string GenerateRefreshToken() => Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));

        public string HashToken(string token)
        {
            var hash = SHA256.HashData(Encoding.UTF8.GetBytes(token));
            
            return Convert.ToBase64String(hash);
        }
    }
}
