using BuildFlow.Api.Domain.Entities;

namespace BuildFlow.Api.Interfaces.Security
{
    public interface IJwtTokenService
    {
        string GenerateAccessToken(User user, long sessionId);
    }
}
