using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace StockMarket.Helper
{
    public class DBConnection
    {
        private  IDbConnection _connection;
        private IConfiguration _configuration;
        public DBConnection(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IDbConnection Connection
        {
            get
            {
                if (_connection == null)
                    _connection = new NpgsqlConnection(_configuration.GetConnectionString("PostgresConnectionString"));
                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();
                return _connection;
            }
        }

        public void CloseConnection()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
                _connection.Close();
        }
    }
}
