using Build_flow_Saas.api.Interfaces;
using Build_flow_Saas.api.Interfaces.IRepository;
using Build_flow_Saas.api.Models.Entities;
using Dapper;

namespace Build_flow_Saas.api.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public UserRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }
       
        public async Task<User?> GetByIdAsync(long userId)
        {
            const string sql = @"SELECT * FROM Users WHERE Id = @UserId AND IsDeleted = 0";

            using var connection = _dbConnectionFactory.CreateConnection();
            return await connection.QuerySingleOrDefaultAsync<User>(sql, new { UserId = userId });
        }

        public async Task<User?> GetByIdAsync(long userId)
        {
            const string query = @"SELECT *
                                    FROM Users
                                    WHERE UserId = @UserId
                                      AND IsDeleted = 0;";

            using var connection = _dbConnectionFactory.CreateConnection();

            return await connection.QuerySingleOrDefaultAsync<User>(
                query,
                new { UserId = userId }
            );
        }

        // Get User By Email
        public async Task<User?> GetByEmailAsync(string email)
        {
            const string query = @"
            SELECT *
            FROM Users
            WHERE Email = @Email
              AND IsDeleted = 0;";

            using var connection = _dbConnectionFactory.CreateConnection();

            return await connection.QuerySingleOrDefaultAsync<User>(
                query,
                new { Email = email }
            );
        }

        // Create User
        public async Task<long> CreateAsync(User user)
        {
            const string query = @"INSERT INTO Users
                                (FullName, Email,PasswordHash,IsActive,CreatedAt,CreatedBy,IsDeleted)
                                VALUES
                                (@FullName, @Email, @PasswordHash, @CreatedAt, @CreatedBy,0 );

            SELECT CAST(SCOPE_IDENTITY() AS BIGINT);";

            using var connection = _dbConnectionFactory.CreateConnection();

            return await connection.ExecuteScalarAsync<long>(
                query,
                user
            );
        }

        // Update User
        public async Task<bool> UpdateAsync(User user)
        {
            const string query = @"UPDATE Users SET
                                    FullName = @FullName,
                                    Email = @Email,
                                    ModifiedAt = @ModifiedAt,
                                    ModifiedBy = @ModifiedBy
                                WHERE UserId = @UserId
                                  AND IsDeleted = 0;";

            using var connection = _dbConnectionFactory.CreateConnection();

            var rowsAffected = await connection.ExecuteAsync( query,user);

            return rowsAffected > 0;
        }
    }
}
