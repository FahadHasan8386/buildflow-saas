using BuildFlow.Api.Interfaces.Security;

namespace BuildFlow.Api.Security
{
    public class PasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password) =>BCrypt.Net.BCrypt.HashPassword(password);
        public bool VerifyPassword(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }
    }
}
