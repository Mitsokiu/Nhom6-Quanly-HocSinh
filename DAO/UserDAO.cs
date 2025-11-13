using DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace DAO
{
    public class UserDAO
    {
        // Kiểm tra login bằng username và password
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

        // Lấy thông tin user đầy đủ khi login thành công
        public UserDTO GetUserInfo(string username)
        {
            string query = "SELECT id, username, email, full_name, phone, created_at, user_roles " +
                           "FROM users WHERE username=@user";

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
                            Id = reader.GetInt32("id"),
                            Username = reader.GetString("username"),
                            Email = reader.GetString("email"),
                            FullName = reader.GetString("full_name"),
                            Phone = reader.GetString("phone"),
                            CreatedAt = reader.GetDateTime("created_at"),
                            UserRoles = reader.GetString("user_roles")
                        };
                    }
                    else
                        return null;
                }
            }
        }

        public bool AddUser(UserDTO user)
        {
            string query = @"INSERT INTO users 
                             (username, password, email, full_name, phone, created_at, user_roles) 
                             VALUES (@username, @password, @email, @fullname, @phone, @created_at, @role)";

            using (var conn = DbConnect.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.Parameters.AddWithValue("@password", user.Password); // Nên hash sau này
                cmd.Parameters.AddWithValue("@email", user.Email);
                cmd.Parameters.AddWithValue("@fullname", user.FullName ?? "");
                cmd.Parameters.AddWithValue("@phone", user.Phone ?? "");
                cmd.Parameters.AddWithValue("@created_at", DateTime.Now);
                cmd.Parameters.AddWithValue("@role", user.UserRoles);

                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        public List<UserDTO> GetAllUsers()
        {
            List<UserDTO> users = new List<UserDTO>();
            string query = "SELECT username,password, full_name, email, phone, created_at, user_roles FROM users";

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
                            Username = reader.GetString("username"),
                            Password = reader.GetString("password"),
                            FullName = reader.GetString("full_name"),
                            Email = reader.GetString("email"),
                            Phone = reader.GetString("phone"),
                            CreatedAt = reader.GetDateTime("created_at"),
                            UserRoles = reader.GetString("user_roles")
                        });
                    }
                }
            }

            return users;
        }

        // trong UserDAO
        public bool UpdateUser(UserDTO user)
        {
            string sql = @"UPDATE users SET 
                           password=@pass, full_name=@fullname, email=@email, phone=@phone, 
                           user_roles=@role
                           WHERE username=@username";
            using (var conn = DbConnect.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@pass", user.Password);
                cmd.Parameters.AddWithValue("@fullname", user.FullName);
                cmd.Parameters.AddWithValue("@email", user.Email);
                cmd.Parameters.AddWithValue("@phone", user.Phone);
                cmd.Parameters.AddWithValue("@role", user.UserRoles);
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
