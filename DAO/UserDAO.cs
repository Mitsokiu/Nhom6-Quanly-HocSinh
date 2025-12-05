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
                                Avatar = reader["avatar"] != DBNull.Value ? reader.GetString("avatar") : "",
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

        public bool CheckLogin(string username, string password)
        {
            UserDTO user = GetUserByUsername(username);
            if (user == null) return false;
            return user.Password.Trim() == password.Trim();
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
                string sql = @"
            UPDATE users SET 
                fullname = @fullname,
                email = @email,
                phone = @phone,
                avatar = @avatar,
                role_id = @role";

                if (!string.IsNullOrEmpty(user.Password))
                    sql += ", password = @password";

                sql += " WHERE user_id = @userId";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@fullname", user.Fullname ?? "");
                    cmd.Parameters.AddWithValue("@email", user.Email ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@phone", user.Phone ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@avatar", user.Avatar ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@role", user.RoleName);
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

                string sql = @"
            INSERT INTO users(username, password, fullname, email, phone, avatar, role_id, created_at)
            VALUES (@username, @password, @fullname, @email, @phone, @avatar, @role, NOW())";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@username", user.Username);
                    cmd.Parameters.AddWithValue("@password", string.IsNullOrEmpty(user.Password) ? "123456" : user.Password);
                    cmd.Parameters.AddWithValue("@fullname", user.Fullname);
                    cmd.Parameters.AddWithValue("@email", user.Email ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@phone", user.Phone ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@avatar", user.Avatar ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@role", user.RoleName);

                    if (cmd.ExecuteNonQuery() == 0) return false;
                }

                int newUserId = 0;
                using (var cmd = new MySqlCommand("SELECT LAST_INSERT_ID()", conn))
                    newUserId = Convert.ToInt32(cmd.ExecuteScalar());

                // Insert vào bảng con theo role
                if (user.RoleName == "student")
                {
                    using (var cmd = new MySqlCommand("INSERT INTO students(user_id) VALUES(@uid)", conn))
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

        public bool CheckPasswordById(int userId, string oldPassword)
        public UserDTO GetUserById(int userId)
        {
            using (var conn = DbConnect.GetConnection())
            {
                conn.Open();
                string query = "SELECT password FROM users WHERE user_id = @userId";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    var result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        string currentPass = result.ToString();
                        return currentPass == oldPassword;
                    }
                    return false;
                }
            }
        }

        public bool UpdatePassword(int userId, string newPassword)
        {
            using (var conn = DbConnect.GetConnection())
            {
                conn.Open();
                string query = "UPDATE users SET password = @password WHERE user_id = @userId";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@password", newPassword);
                    cmd.Parameters.AddWithValue("@userId", userId);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
                string query = "SELECT * FROM users WHERE user_id = @userId";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new UserDTO
                            {
                                UserId = reader.GetInt32("user_id"),
                                Username = reader.GetString("username"),
                                Fullname = reader.GetString("fullname"),
                                RoleName = reader["role_id"] != DBNull.Value ? reader.GetString("role_id") : "",
                                Password = reader.GetString("password"),
                                Email = reader["email"] != DBNull.Value ? reader.GetString("email") : "",
                                Phone = reader["phone"] != DBNull.Value ? reader.GetString("phone") : "",
                                Avatar = reader["avatar"] != DBNull.Value ? reader.GetString("avatar") : "",
                                CreatedAt = reader["created_at"] != DBNull.Value ? reader.GetDateTime("created_at") : DateTime.MinValue
                            };
                        }
                    }
                }
            }
            return null;
        }

    }
}
