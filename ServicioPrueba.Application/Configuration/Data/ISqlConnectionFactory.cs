using System.Data;

namespace ServicioPrueba.Application.Configuration.Data
{
    public interface ISqlConnectionFactory
    {
        IDbConnection GetOpenConnection();
    }
}
