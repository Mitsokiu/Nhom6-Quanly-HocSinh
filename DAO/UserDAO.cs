using DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace DAO
{
    public class UserDAO
    {
        // Kiểm tra đăng nhập
        public bool CheckLogin(UserDTO user)
        {
            string query = "SELECT COUNT(*) FROM users WHERE username=@user AND password=@pass";

            using (var conn = DbConnect.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@user", user.Username);
                cmd.Parameters.AddWithValue("@pass", user.Password);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        // Lấy thông tin user sau khi đăng nhập
        public UserDTO GetUserInfo(string username)
        {
            string query = @"SELECT u.user_id, u.username, u.fullname, u.email, u.phone, 
                                    u.created_at, u.role_id, r.role_name
                             FROM users u
                             LEFT JOIN roles r ON u.role_id = r.role_id
                             WHERE u.username=@user";

            using (var conn = DbConnect.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@user", username);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new UserDTO
                        {
                            UserId = reader.GetInt32("user_id"),
                            Username = reader.GetString("username"),
                            Fullname = reader["fullname"]?.ToString(),
                            Email = reader["email"]?.ToString(),
                            Phone = reader["phone"]?.ToString(),
                            CreatedAt = reader.GetDateTime("created_at"),
                            RoleId = reader.GetInt32("role_id"),
                            RoleName = reader["role_name"]?.ToString()
                        };
                    }
                    return null;
                }
            }
        }

        // Thêm người dùng
        public bool AddUser(UserDTO user)
        {
            string query = @"INSERT INTO users 
                             (username, password, fullname, email, phone, role_id, created_at) 
                             VALUES (@username, @password, @fullname, @email, @phone, @role_id, @created_at)";

            using (var conn = DbConnect.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.Parameters.AddWithValue("@fullname", user.Fullname ?? "");
                cmd.Parameters.AddWithValue("@email", user.Email ?? "");
                cmd.Parameters.AddWithValue("@phone", user.Phone ?? "");
                cmd.Parameters.AddWithValue("@role_id", user.RoleId);
                cmd.Parameters.AddWithValue("@created_at", DateTime.Now);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Lấy toàn bộ user
        public List<UserDTO> GetAllUsers()
        {
            List<UserDTO> users = new List<UserDTO>();
            string query = @"SELECT u.user_id, u.username, u.fullname, u.email, u.phone, 
                                    u.created_at, u.role_id, r.role_name
                             FROM users u
                             LEFT JOIN roles r ON u.role_id = r.role_id";

            using (var conn = DbConnect.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new UserDTO
                        {
                            UserId = reader.GetInt32("user_id"),
                            Username = reader.GetString("username"),
                            Fullname = reader["fullname"]?.ToString(),
                            Email = reader["email"]?.ToString(),
                            Phone = reader["phone"]?.ToString(),
                            CreatedAt = reader.GetDateTime("created_at"),
                            RoleId = reader.GetInt32("role_id"),
                            RoleName = reader["role_name"]?.ToString()
                        });
                    }
                }
            }
            return users;
        }

        // Cập nhật user
        public bool UpdateUser(UserDTO user)
        {
            string sql = @"UPDATE users 
                           SET password=@pass, fullname=@fullname, email=@email, 
                               phone=@phone, role_id=@role_id
                           WHERE username=@username";
            using (var conn = DbConnect.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@pass", user.Password);
                cmd.Parameters.AddWithValue("@fullname", user.Fullname);
                cmd.Parameters.AddWithValue("@email", user.Email);
                cmd.Parameters.AddWithValue("@phone", user.Phone);
                cmd.Parameters.AddWithValue("@role_id", user.RoleId);
                cmd.Parameters.AddWithValue("@username", user.Username);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Xóa user
        public bool DeleteUser(string username)
        {
            string sql = "DELETE FROM users WHERE username=@username";
            using (var conn = DbConnect.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@username", username);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
