using Microsoft.Extensions.Configuration;
using MySqlConnector;

namespace IGotUScraper.Infrastructure.Base
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public MySqlConnection CreatePelandoDbConnection()
        {
            return new MySqlConnection(_configuration.GetConnectionString("pelandodb"));
        }
    }
}
