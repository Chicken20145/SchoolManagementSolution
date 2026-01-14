using System;
using System.Data;
using System.Threading.Tasks;
using MySqlConnector;
using SchoolManagement.DAL.Core;
using SchoolManagement.DAL.DAO.Interfaces;
using SchoolManagement.DTO;

namespace SchoolManagement.DAL.DAO.Implements
{
    public class UserDAO : IUserDAO
    {

        /// Login đơn giản với SHA2

        public async Task<UserDTO?> LoginAsync(string username, string password)
        {
            const string sql = @"
SELECT user_id, username, role
FROM users
WHERE username = @username
  AND password_hash = SHA2(@password, 256)
LIMIT 1;";

            try
            {
                System.Diagnostics.Debug.WriteLine($"[UserDAO] Login attempt: username={username}");
                
                var dt = await DbHelper.QueryAsync(sql,
                    new MySqlParameter("@username", username),
                    new MySqlParameter("@password", password)
                );

                System.Diagnostics.Debug.WriteLine($"[UserDAO] Query returned {dt.Rows.Count} rows");

                if (dt.Rows.Count == 0)
                {
                    // Debug: Check if user exists
                    var checkSql = "SELECT COUNT(*) as cnt FROM users WHERE username = @username";
                    var checkDt = await DbHelper.QueryAsync(checkSql,
                        new MySqlParameter("@username", username));
                    var userExists = Convert.ToInt32(checkDt.Rows[0]["cnt"]) > 0;
                    
                    System.Diagnostics.Debug.WriteLine($"[UserDAO] User exists: {userExists}");
                    
                    return null;
                }

                var r = dt.Rows[0];
                var user = new UserDTO
                {
                    UserId = Convert.ToInt32(r["user_id"]),
                    Username = Convert.ToString(r["username"]) ?? "",
                    Role = Convert.ToString(r["role"]) ?? ""
                };

                System.Diagnostics.Debug.WriteLine($"[UserDAO] Login success: {user.Username} ({user.Role})");
                
                return user;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[UserDAO] Error: {ex.Message}");
                throw;
            }
        }
    }
}
