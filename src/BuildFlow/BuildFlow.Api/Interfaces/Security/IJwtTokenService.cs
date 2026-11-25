using BuildFlow.Api.Domain.Entities;

namespace BuildFlow.Api.Interfaces.Security
{
    public interface IJwtTokenService
    {
        string GenerateAcessToken(User user, long sessionId);
    }
}
