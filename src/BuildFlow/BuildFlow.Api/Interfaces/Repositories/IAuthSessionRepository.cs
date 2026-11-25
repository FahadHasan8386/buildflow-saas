using BuildFlow.Api.Domain.Entities;
using System.Data;

namespace BuildFlow.Api.Interfaces.Repositories
{
    public interface IAuthSessionRepository
    {
        Task<AuthSession?> GetByIdAsync(long id);
        Task<AuthSession?> GetByRefreshTokenHashAsync(string refreshTokenHash);
        Task<IEnumerable<AuthSession>> GetActiveSessionsByUserIdAsync(long userId);
        Task<long> CreateAsync(AuthSession session, IDbConnection? connection = null, IDbTransaction? transaction = null);
        Task RevokeAsync(long sessionId, IDbConnection? connection = null, IDbTransaction? transaction = null);
        Task RevokeAllByUserIdAsync(long userId, long? exceptSessionId = null);
    }
}
