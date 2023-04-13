using MySqlConnector;
using System.Data;

namespace IGotUScraper.Infrastructure.Base
{
    public interface IConnectionFactory
    {
        MySqlConnection CreatePelandoDbConnection();
    }
}
