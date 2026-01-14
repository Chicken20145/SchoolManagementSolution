using System.Data;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.DAL.Core
{
    public static class DbHelper
    {
        public static async Task<DataTable> QueryAsync(string sql, params MySqlParameter[] parameters)
        {
            using var conn = DbConnectionFactory.CreateConnection();
            await conn.OpenAsync();

            using var cmd = new MySqlCommand(sql, conn);
            if (parameters?.Length > 0) cmd.Parameters.AddRange(parameters);

            using var reader = await cmd.ExecuteReaderAsync();
            var dt = new DataTable();
            dt.Load(reader);
            return dt;
        }

        public static async Task<int> ExecuteAsync(string sql, params MySqlParameter[] parameters)
        {
            using var conn = DbConnectionFactory.CreateConnection();
            await conn.OpenAsync();

            using var cmd = new MySqlCommand(sql, conn);
            if (parameters?.Length > 0) cmd.Parameters.AddRange(parameters);

            return await cmd.ExecuteNonQueryAsync();
        }

        public static async Task<object?> ScalarAsync(string sql, params MySqlParameter[] parameters)
        {
            using var conn = DbConnectionFactory.CreateConnection();
            await conn.OpenAsync();

            using var cmd = new MySqlCommand(sql, conn);
            if (parameters?.Length > 0) cmd.Parameters.AddRange(parameters);

            return await cmd.ExecuteScalarAsync();
        }

        // Legacy overloads for connection-first approach
        public static async Task<int> ExecuteAsync(
            MySqlConnection conn,
            string sql,
            IEnumerable<MySqlParameter>? parameters = null,
            MySqlTransaction? tx = null)
        {
            using var cmd = new MySqlCommand(sql, conn, tx);
            if (parameters != null)
                cmd.Parameters.AddRange(parameters.ToArray());

            return await cmd.ExecuteNonQueryAsync();
        }

        public static async Task<List<T>> QueryAsync<T>(
            MySqlConnection conn,
            string sql,
            Func<MySqlDataReader, T> map,
            IEnumerable<MySqlParameter>? parameters = null,
            MySqlTransaction? tx = null)
        {
            using var cmd = new MySqlCommand(sql, conn, tx);
            if (parameters != null)
                cmd.Parameters.AddRange(parameters.ToArray());

            using var reader = await cmd.ExecuteReaderAsync();
            var list = new List<T>();
            while (await reader.ReadAsync())
                list.Add(map(reader));

            return list;
        }

        public static async Task<object?> ScalarAsync(
            MySqlConnection conn,
            string sql,
            IEnumerable<MySqlParameter>? parameters = null,
            MySqlTransaction? tx = null)
        {
            using var cmd = new MySqlCommand(sql, conn, tx);
            if (parameters != null)
                cmd.Parameters.AddRange(parameters.ToArray());

            return await cmd.ExecuteScalarAsync();
        }
    }
}
