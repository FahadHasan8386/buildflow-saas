using System.Data;

namespace Build_flow_Saas.api.Interfaces
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
