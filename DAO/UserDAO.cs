using DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace DAO
{
    public class UserDAO
    {
        public UserDTO GetUserByUsername(string username)
        {
            using (var conn = DbConnect.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM users WHERE username = @username";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new UserDTO
                            {
                                UserId = reader.GetInt32("user_id"),
                                Username = reader.GetString("username"),
                                Fullname = reader.GetString("fullname"),
                                RoleName = reader["role_id"] != DBNull.Value ? reader.GetString("role_id") : "", // dùng role_id trực tiếp
                                Password = reader.GetString("password"),
                                Email = reader["email"] != DBNull.Value ? reader.GetString("email") : "",
                                Phone = reader["phone"] != DBNull.Value ? reader.GetString("phone") : "",
                                CreatedAt = reader["created_at"] != DBNull.Value ? reader.GetDateTime("created_at") : DateTime.MinValue
                            };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        // File: DAO/UserDAO.cs
        public bool CheckLogin(string username, string password)
        {
            // 1. Tìm user trong DB
            UserDTO user = GetUserByUsername(username);

            // DEBUG: Kiểm tra xem có tìm thấy user không
            if (user == null)
            {
                System.Windows.Forms.MessageBox.Show($"Không tìm thấy tài khoản: {username} trong Database!", "Debug");
                return false;
            }

            // 2. Lấy mật khẩu từ DB và mật khẩu nhập vào
            string dbPass = user.Password.Trim();
            string inputPass = password.Trim();

            // DEBUG: So sánh mật khẩu (ẩn đi sau khi sửa xong lỗi nhé)
            // System.Windows.Forms.MessageBox.Show($"Pass trong DB: '{dbPass}'\nPass nhập vào: '{inputPass}'", "Debug So Sánh");

            // 3. So sánh
            if (dbPass == inputPass)
            {
                return true;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Tìm thấy User nhưng sai mật khẩu!", "Debug");
                return false;
            }
        }

        public List<UserDTO> GetAllUsers()
        {
            List<UserDTO> list = new List<UserDTO>();
            using (var conn = DbConnect.GetConnection())
            {
                conn.Open();
                string sql = @"
                    SELECT user_id, username, fullname, email, phone, password, created_at, role_id
                    FROM users";

                using (var cmd = new MySqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        UserDTO user = new UserDTO
                        {
                            UserId = reader.GetInt32("user_id"),
                            Username = reader.GetString("username"),
                            Fullname = reader["fullname"] != DBNull.Value ? reader.GetString("fullname") : "",
                            Email = reader["email"] != DBNull.Value ? reader.GetString("email") : "",
                            Phone = reader["phone"] != DBNull.Value ? reader.GetString("phone") : "",
                            Password = reader.GetString("password"),
                            CreatedAt = reader["created_at"] != DBNull.Value ? reader.GetDateTime("created_at") : DateTime.MinValue,
                            RoleName = reader["role_id"] != DBNull.Value ? reader.GetString("role_id") : "" // dùng role_id trực tiếp
                        };
                        list.Add(user);
                    }
                }
            }
            return list;
        }

        public bool UpdateUser(UserDTO user)
        {
            using (var conn = DbConnect.GetConnection())
            {
                conn.Open();
                string sql;

                if (!string.IsNullOrEmpty(user.Password))
                {
                    sql = @"
                        UPDATE users SET 
                            fullname = @fullname,
                            email = @email,
                            phone = @phone,
                            password = @password,
                            role_id = @role
                        WHERE user_id = @userId";
                }
                else
                {
                    sql = @"
                        UPDATE users SET 
                            fullname = @fullname,
                            email = @email,
                            phone = @phone,
                            role_id = @role
                        WHERE user_id = @userId";
                }

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@fullname", user.Fullname);
                    cmd.Parameters.AddWithValue("@email", user.Email);
                    cmd.Parameters.AddWithValue("@phone", user.Phone);
                    cmd.Parameters.AddWithValue("@role", user.RoleName); // truyền role_id
                    cmd.Parameters.AddWithValue("@userId", user.UserId);
                    if (!string.IsNullOrEmpty(user.Password))
                        cmd.Parameters.AddWithValue("@password", user.Password);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DeleteUser(int userId)
        {
            using (var conn = DbConnect.GetConnection())
            {
                conn.Open();

                // Xóa dữ liệu liên quan trong bảng students
                using (var cmd1 = new MySqlCommand("DELETE FROM students WHERE user_id = @userId", conn))
                {
                    cmd1.Parameters.AddWithValue("@userId", userId);
                    cmd1.ExecuteNonQuery();
                }

                string sql = "DELETE FROM users WHERE user_id = @userId";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }


        }
        public bool AddUserFull(UserDTO user)
        {
            using (var conn = DbConnect.GetConnection())
            {
                conn.Open();

                // 1. Insert vào bảng users
                string sql = @"
            INSERT INTO users(username, password, fullname, email, phone, role_id, created_at)
            VALUES (@username, @password, @fullname, @email, @phone, @role, NOW())";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@username", user.Username);
                    cmd.Parameters.AddWithValue("@password", user.Password);
                    cmd.Parameters.AddWithValue("@fullname", user.Fullname);
                    cmd.Parameters.AddWithValue("@email", user.Email);
                    cmd.Parameters.AddWithValue("@phone", user.Phone);
                    cmd.Parameters.AddWithValue("@role", user.RoleName);

                    if (cmd.ExecuteNonQuery() == 0)
                        return false;
                }

                // 2. Lấy user_id vừa tạo
                int newUserId = 0;
                using (var cmd = new MySqlCommand("SELECT LAST_INSERT_ID()", conn))
                {
                    newUserId = Convert.ToInt32(cmd.ExecuteScalar());
                }

                // 3. Insert theo role
                if (user.RoleName == "student")
                {
                    string ssql = "INSERT INTO students(user_id) VALUES(@uid)";
                    using (var cmd = new MySqlCommand(ssql, conn))
                    {
                        cmd.Parameters.AddWithValue("@uid", newUserId);
                        cmd.ExecuteNonQuery();
                    }
                }
                else if (user.RoleName == "gvbm" || user.RoleName == "gvcn")
                {
                    string ssql = "INSERT INTO teachers(user_id) VALUES(@uid)";
                    using (var cmd = new MySqlCommand(ssql, conn))
                    {
                        cmd.Parameters.AddWithValue("@uid", newUserId);
                        cmd.ExecuteNonQuery();
                    }
                }
                else if (user.RoleName == "parent")
                {
                    string ssql = "INSERT INTO parents(user_id) VALUES(@uid)";
                    using (var cmd = new MySqlCommand(ssql, conn))
                    {
                        cmd.Parameters.AddWithValue("@uid", newUserId);
                        cmd.ExecuteNonQuery();
                    }
                }

                return true;
            }
        }
        public List<UserDTO> SearchUsers(string keyword)
        {
            List<UserDTO> list = new List<UserDTO>();

            using (var conn = DbConnect.GetConnection())
            {
                conn.Open();

                string sql = @"
            SELECT u.user_id, u.username, u.fullname, u.email, u.phone,
                   u.password, u.created_at, u.role_id
            FROM users u
            WHERE u.username LIKE @kw
               OR u.fullname LIKE @kw
               OR u.email LIKE @kw
               OR u.phone LIKE @kw
        ";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");

                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            list.Add(new UserDTO
                            {
                                UserId = rd.GetInt32("user_id"),
                                Username = rd.GetString("username"),
                                Fullname = rd.GetString("fullname"),
                                Email = rd.GetString("email"),
                                Phone = rd.GetString("phone"),
                                Password = rd.GetString("password"),
                                CreatedAt = rd.GetDateTime("created_at"),
                                RoleName = rd.GetString("role_id")
                            });
                        }
                    }
                }
            }

            return list;
        }

        // Lấy danh sách tất cả giáo viên
        public static List<UserDTO> GetAllTeachers()
        {
            var list = new List<UserDTO>();
            string query = "SELECT user_id, fullname, username, role_name FROM users WHERE role_name = 'Teacher'";

            using (var conn = DbConnect.GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new UserDTO
                        {
                            UserId = reader.GetInt32("user_id"),
                            Fullname = reader.GetString("fullname"),
                            Username = reader.GetString("username"),
                            RoleName = reader.GetString("role_name")
                        });
                    }
                }
            }
            return list;
        }

    }
}
