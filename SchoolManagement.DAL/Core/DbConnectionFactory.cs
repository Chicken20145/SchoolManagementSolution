using System;
using MySqlConnector;
using System.Configuration;

namespace SchoolManagement.DAL.Core
{
    public static class DbConnectionFactory
    {
        public static MySqlConnection CreateConnection()
        {
            var cs = ConfigurationManager.ConnectionStrings["SchoolDb"]?.ConnectionString;
            if (string.IsNullOrWhiteSpace(cs))
            {
                throw new InvalidOperationException("Missing connection string 'SchoolDb' in configuration.");
            }
            return new MySqlConnection(cs);
        }

        public static MySqlConnection CreateConnection(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentException("Connection string is null or empty", nameof(connectionString));
            }

            return new MySqlConnection(connectionString);
        }
    }
}
