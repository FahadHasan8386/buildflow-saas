using BuildFlow.Api.Domain.Entities;
using BuildFlow.Api.Interfaces.Data;
using BuildFlow.Api.Interfaces.Repositories;
using Dapper;
using Microsoft.AspNetCore.Connections;
using System.Data;

namespace BuildFlow.Api.Repositories
{
    public class AuthSessionRepository : IAuthSessionRepository
    {
        private readonly IDbConnectionFactory  _dbConnection;

        public AuthSessionRepository(IDbConnectionFactory dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<AuthSession?> GetByIdAsync(long id)
        {
            using var connection = _dbConnection.CreateConnection();
            return await connection.QuerySingleOrDefaultAsync<AuthSession>(
                "SELECT * FROM AuthSessions WHERE Id = @Id AND IsDeleted = 0;",
                new { Id = id });
        }

        public async Task<AuthSession?> GetByRefreshTokenHashAsync(string refreshTokenHash)
        {
            const string sql = @"SELECT * FROM AuthSessions WHERE RefreshTokenHash = @RefreshTokenHash AND  IsDeleted = 0;";

            using var connection = _dbConnection.CreateConnection();
            return await connection.QuerySingleOrDefaultAsync<AuthSession>(sql,new { RefreshTokenHash = refreshTokenHash });
        }   

        public async Task<IEnumerable<AuthSession>> GetActiveSessionsByUserIdAsync(long userId)
        {

            const string sql = @"SELECT * FROM AuthSessions 
                WHERE UserId = @UserId AND RevokedAt IS NULL AND ExpiresAt > GETUTCDATE() AND IsDeleted = 0
                ORDER BY CreatedAt DESC;";

            using var connection = _dbConnection.CreateConnection();
            return await connection.QueryAsync<AuthSession>(sql, new { UserId = userId });

        }

        public async Task<long> CreateAsync(AuthSession session, IDbConnection? connection = null, IDbTransaction? transaction = null)
        {
            const string sql = @"
                                INSERT INTO AuthSessions (UserId, RefreshTokenHash, DeviceInfo, IpAddress, ExpiresAt, RevokedAt, CreatedAt, CreatedBy, IsDeleted)
                                VALUES (@UserId, @RefreshTokenHash, @DeviceInfo, @IpAddress, @ExpiresAt, @RevokedAt, @CreatedAt, @CreatedBy, @IsDeleted);
                                SELECT CAST(SCOPE_IDENTITY() as bigint);";

            if (connection is not null)
            {
                return await connection.ExecuteScalarAsync<long>(sql, session, transaction);
            }

            using var newConnection = _dbConnection.CreateConnection();
            return await newConnection.ExecuteScalarAsync<long>(sql, session);
        }

        public async Task RevokeAsync(long sessionId, IDbConnection? connection = null, IDbTransaction? transaction = null)
        {
            const string sql = @"UPDATE AuthSessions SET RevokedAt = @RevokedAt, ModifiedAt = @RevokedAt WHERE Id = @Id AND RevokedAt IS NULL;";
            var parameters = new { Id = sessionId, RevokedAt = DateTime.UtcNow };

            if (connection is not null)
            {
                await connection.ExecuteAsync(sql, parameters, transaction);
                return;
            }

            using var newConnection = _dbConnection.CreateConnection();
            await newConnection.ExecuteAsync(sql, parameters);
        }

        public async Task RevokeAllByUserIdAsync(long userId, long? exceptSessionId = null)
        {
            const string sql = @"UPDATE AuthSessions 
                                SET RevokedAt = @RevokedAt, ModifiedAt = @RevokedAt 
                                WHERE UserId = @UserId AND RevokedAt IS NULL AND IsDeleted = 0
                                  AND (@ExceptSessionId IS NULL OR Id <> @ExceptSessionId);
                                ";
            using var connection = _dbConnection.CreateConnection();
            await connection.ExecuteAsync(sql, new { UserId = userId, ExceptSessionId = exceptSessionId, RevokedAt = DateTime.UtcNow });
        }
    }
}
