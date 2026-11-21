using BuildFlow.Api.Domain.Entities;
using BuildFlow.Api.Interfaces.Data;
using BuildFlow.Api.Interfaces.Repositories;
using Dapper;

namespace BuildFlow.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public UserRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        // Get user by ID
        public async Task<User?> GetByIdAsync(long id)
        {
            const string sql = @"
                SELECT *
                FROM Users
                WHERE Id = @Id
                AND IsDeleted = 0;
            ";

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QuerySingleOrDefaultAsync<User>(
                sql,
                new { Id = id }
            );
        }

        // Get user by Email
        public async Task<User?> GetByEmailAsync(string email)
        {
            const string sql = @"
                SELECT *
                FROM Users
                WHERE Email = @Email
                AND IsDeleted = 0;
            ";

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QuerySingleOrDefaultAsync<User>(
                sql,
                new { Email = email.Trim() }
            );
        }

        // Check email exists
        public async Task<bool> ExistsByEmailAsync(string email)
        {
            const string sql = @"
                SELECT CASE
                    WHEN EXISTS
                    (
                        SELECT 1
                        FROM Users
                        WHERE Email = @Email
                        AND IsDeleted = 0
                    )
                    THEN CAST(1 AS BIT)
                    ELSE CAST(0 AS BIT)
                END;
            ";

            using var connection = _connectionFactory.CreateConnection();

            return await connection.ExecuteScalarAsync<bool>(
                sql,
                new { Email = email.Trim() }
            );
        }

        // Create user
        public async Task<long> CreateAsync(User user)
        {
            const string sql = @"
                INSERT INTO Users
                (
                    FullName,
                    Email,
                    PasswordHash,
                    IsActive,
                    CreatedAt,
                    CreatedBy,
                    IsDeleted
                )
                VALUES
                (
                    @FullName,
                    @Email,
                    @PasswordHash,
                    @IsActive,
                    SYSUTCDATETIME(),
                    @CreatedBy,
                    0
                );

                SELECT CAST(SCOPE_IDENTITY() AS BIGINT);
            ";

            using var connection = _connectionFactory.CreateConnection();

            return await connection.ExecuteScalarAsync<long>(sql, user);
        }

        // Update user information
        public async Task UpdateAsync(User user)
        {
            const string sql = @"
                UPDATE Users
                SET
                    FullName = @FullName,
                    Email = @Email,
                    ModifiedAt = SYSUTCDATETIME(),
                    ModifiedBy = @ModifiedBy
                WHERE Id = @Id
                AND IsDeleted = 0;
            ";

            using var connection = _connectionFactory.CreateConnection();

            await connection.ExecuteAsync(sql, user);
        }

        // Update password
        public async Task UpdatePasswordAsync(
            long userId,
            string newPasswordHash)
        {
            const string sql = @"
                UPDATE Users
                SET
                    PasswordHash = @PasswordHash,
                    ModifiedAt = SYSUTCDATETIME()
                WHERE Id = @Id
                AND IsDeleted = 0;
            ";

            using var connection = _connectionFactory.CreateConnection();

            await connection.ExecuteAsync(
                sql,
                new
                {
                    Id = userId,
                    PasswordHash = newPasswordHash
                }
            );
        }

        // Update user status
        public async Task UpdateStatusAsync(
            long userId,
            bool isActive,
            string? modifiedBy = null)
        {
            const string sql = @"
                UPDATE Users
                SET
                    IsActive = @IsActive,
                    ModifiedAt = SYSUTCDATETIME(),
                    ModifiedBy = @ModifiedBy
                WHERE Id = @Id
                AND IsDeleted = 0;
            ";

            using var connection = _connectionFactory.CreateConnection();

            await connection.ExecuteAsync(
                sql,
                new
                {
                    Id = userId,
                    IsActive = isActive,
                    ModifiedBy = modifiedBy
                }
            );
        }

        // Soft delete user
        public async Task SoftDeleteAsync(
            long userId,
            string? modifiedBy = null)
        {
            const string sql = @"
                UPDATE Users
                SET
                    IsDeleted = 1,
                    IsActive = 0,
                    ModifiedAt = SYSUTCDATETIME(),
                    ModifiedBy = @ModifiedBy
                WHERE Id = @Id
                AND IsDeleted = 0;
            ";

            using var connection = _connectionFactory.CreateConnection();

            await connection.ExecuteAsync(
                sql,
                new
                {
                    Id = userId,
                    ModifiedBy = modifiedBy
                }
            );
        }
    }
}
