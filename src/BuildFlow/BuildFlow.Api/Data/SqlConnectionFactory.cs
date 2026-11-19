using BuildFlow.Api.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BuildFlow.Api.Data
{
    public class SqlConnectionFactory : IDbConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public SqlConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection CreateConnection()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Database connection string not found.");
            }

            return new SqlConnection(connectionString);
        }
    }
}
