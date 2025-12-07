using DAO;
using DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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

        public bool CheckPasswordById(int userId, string oldPassword)
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
        //public bool AddUserFull(UserDTO user)
        //{
        //    using (var conn = DbConnect.GetConnection())
        //    {
        //        conn.Open();

        //        // 1. Insert vào bảng users
        //        string sql = @"
        //    INSERT INTO users(username, password, fullname, email, phone, role_id, created_at)
        //    VALUES (@username, @password, @fullname, @email, @phone, @role, NOW())";

        //        using (var cmd = new MySqlCommand(sql, conn))
        //        {
        //            cmd.Parameters.AddWithValue("@username", user.Username);
        //            cmd.Parameters.AddWithValue("@password", user.Password);
        //            cmd.Parameters.AddWithValue("@fullname", user.Fullname);
        //            cmd.Parameters.AddWithValue("@email", user.Email);
        //            cmd.Parameters.AddWithValue("@phone", user.Phone);
        //            cmd.Parameters.AddWithValue("@role", user.RoleName);

        //            if (cmd.ExecuteNonQuery() == 0)
        //                return false;
        //        }

        //        // 2. Lấy user_id vừa tạo
        //        int newUserId = 0;
        //        using (var cmd = new MySqlCommand("SELECT LAST_INSERT_ID()", conn))
        //        {
        //            newUserId = Convert.ToInt32(cmd.ExecuteScalar());
        //        }

        //        // 3. Insert theo role
        //        if (user.RoleName == "student")
        //        {
        //            string ssql = "INSERT INTO students(user_id) VALUES(@uid)";
        //            using (var cmd = new MySqlCommand(ssql, conn))
        //            {
        //                cmd.Parameters.AddWithValue("@uid", newUserId);
        //                cmd.ExecuteNonQuery();
        //            }
        //        }
        //        else if (user.RoleName == "gvbm" || user.RoleName == "gvcn")
        //        {
        //            string ssql = "INSERT INTO teachers(user_id) VALUES(@uid)";
        //            using (var cmd = new MySqlCommand(ssql, conn))
        //            {
        //                cmd.Parameters.AddWithValue("@uid", newUserId);
        //                cmd.ExecuteNonQuery();
        //            }
        //        }
        //        else if (user.RoleName == "parent")
        //        {
        //            string ssql = "INSERT INTO parents(user_id) VALUES(@uid)";
        //            using (var cmd = new MySqlCommand(ssql, conn))
        //            {
        //                cmd.Parameters.AddWithValue("@uid", newUserId);
        //                cmd.ExecuteNonQuery();
        //            }
        //        }

        //        return true;
        //    }
        //}
        public bool AddUserFull(UserDTO user)
        {
            try
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
                        cmd.Parameters.AddWithValue("@username", user.Username);
                        cmd.Parameters.AddWithValue("@password", user.Password);
                        cmd.Parameters.AddWithValue("@fullname", user.Fullname);
                        cmd.Parameters.AddWithValue("@email", user.Email);
                        cmd.Parameters.AddWithValue("@phone", user.Phone);
                        cmd.Parameters.AddWithValue("@role", user.RoleName);

                        cmd.ExecuteNonQuery();
                    }
                }

                else if (user.RoleName == "gvbm" || user.RoleName == "gvcn")
                {
                    string ssql = "INSERT INTO teachers(user_id) VALUES(@uid)";
                    using (var cmd = new MySqlCommand(ssql, conn))
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
            catch (MySqlException ex)
            {
                // Bắt lỗi MySQL cụ thể để thông báo thân thiện hơn.
                switch (ex.Number)
                {
                    case 1062: // Duplicate entry
                        MessageBox.Show("Tên đăng nhập đã tồn tại. Vui lòng chọn tên khác.");
                        break;

                    case 1048: // Column cannot be null
                        MessageBox.Show("Bạn chưa nhập đủ các trường bắt buộc.");
                        break;

                    case 1452: // Foreign key fails
                        MessageBox.Show("Dữ liệu liên quan chưa tồn tại hoặc không hợp lệ.");
                        break;

                    default:
                        MessageBox.Show("Lỗi MySQL: " + ex.Message);
                        break;
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message);
                return false;
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

        public UserDTO GetUserById(int userId)
{
        using (var conn = DbConnect.GetConnection())
        {
        conn.Open();
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
        public UserDTO GetUserById(int userId)
        {
            using (var conn = DbConnect.GetConnection())
            {
                conn.Open();
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

        public static int GetTotalUsers()
        {
            string sql = "SELECT COUNT(*) FROM users";
            return Convert.ToInt32(DbConnect.ExecuteScalar(sql));
        }

        public static int GetTotalStudents()
        {
            string sql = "SELECT COUNT(*) FROM users WHERE role_id = 'student'";
            return Convert.ToInt32(DbConnect.ExecuteScalar(sql));
        }

        public static int GetTotalTeachers()
        {
            string sql = @"
        SELECT COUNT(*) 
        FROM users 
        WHERE role_id = 'gvcn' OR role_id = 'gvbm'
    ";

            return Convert.ToInt32(DbConnect.ExecuteScalar(sql));
        }
        public static int GetTotalGVCN()
        {
            string sql = @"
        SELECT COUNT(*) 
        FROM users 
        WHERE role_id = 'gvcn'
    ";
            return Convert.ToInt32(DbConnect.ExecuteScalar(sql));
        }

        public static int GetTotalGVBM()
        {
            string sql = @"
        SELECT COUNT(*) 
        FROM users 
        WHERE role_id = 'gvbm'
    ";
            return Convert.ToInt32(DbConnect.ExecuteScalar(sql));
        }

        public List<StudentDTO> GetStudentStatsByDate()
        {
            var list = new List<StudentDTO>();

            using (var conn = DbConnect.GetConnection())
            {
                conn.Open();

                string sql = @"
            SELECT DATE(created_at) AS ngay, COUNT(*) AS so_luong
            FROM users
            WHERE role_id = 'student'
            GROUP BY DATE(created_at)
            ORDER BY DATE(created_at) ASC";

                using (var cmd = new MySqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new StudentDTO
                        {
                            CreatedDate = reader.GetDateTime("ngay"),
                            Count = reader.GetInt32("so_luong")
                        });
                    }
                }
            }

            return list;
        }


    }
}
