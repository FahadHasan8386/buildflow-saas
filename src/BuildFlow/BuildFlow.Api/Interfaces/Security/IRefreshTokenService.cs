namespace BuildFlow.Api.Interfaces.Security
{
    public interface IRefreshTokenService
    {
        string GenerateRefreshToken();
        string HashToken(string token);
    }
}
