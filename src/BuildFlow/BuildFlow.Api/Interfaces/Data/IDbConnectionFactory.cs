using System.Data;

namespace BuildFlow.Api.Interfaces.Data
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
