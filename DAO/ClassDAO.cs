using DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace DAO
{
    public static class ClassDAO
    {
        // 1. Lấy danh sách Lớp kèm thông tin GVCN và Năm học
        public static List<ClassDTO> GetAllClasses()
        {
            var list = new List<ClassDTO>();
            // Query: Lấy lớp và JOIN để lấy thông tin phân công mới nhất (AssignId lớn nhất)
            string query = @"
                SELECT c.class_id, c.class_name, c.grade_id,
                       ha.assign_id, ha.teacher_id, ha.year_id,
                       u.fullname AS teacher_name, ay.name AS year_name
                FROM classes c
                LEFT JOIN (
                    SELECT class_id, MAX(assign_id) as max_id
                    FROM homeroom_assignments
                    GROUP BY class_id
                ) latest ON c.class_id = latest.class_id
                LEFT JOIN homeroom_assignments ha ON latest.max_id = ha.assign_id
                LEFT JOIN teachers t ON ha.teacher_id = t.teacher_id
                LEFT JOIN users u ON t.user_id = u.user_id
                LEFT JOIN academic_years ay ON ha.year_id = ay.year_id
                ORDER BY c.class_name";

            using (var conn = DbConnect.GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new ClassDTO
                        {
                            Id = reader.GetInt32("class_id"),
                            ClassName = reader.GetString("class_name"),
                            GradeId = reader.GetInt32("grade_id"),
                            // Xử lý null nếu lớp chưa có phân công
                            AssignId = reader.IsDBNull(reader.GetOrdinal("assign_id")) ? 0 : reader.GetInt32("assign_id"),
                            TeacherId = reader.IsDBNull(reader.GetOrdinal("teacher_id")) ? 0 : reader.GetInt32("teacher_id"),
                            TeacherName = reader.IsDBNull(reader.GetOrdinal("teacher_name")) ? "" : reader.GetString("teacher_name"),
                            YearId = reader.IsDBNull(reader.GetOrdinal("year_id")) ? 0 : reader.GetInt32("year_id"),
                            YearName = reader.IsDBNull(reader.GetOrdinal("year_name")) ? "" : reader.GetString("year_name")
                        });
                    }
                }
            }
            return list;
        }

        // 2. Thêm lớp và TRẢ VỀ ID (Quan trọng để thêm phân công ngay sau đó)
        public static int AddClassReturnId(ClassDTO c)
        {
            // Tách ra làm 2 lệnh riêng biệt để an toàn tuyệt đối
            string insertQuery = "INSERT INTO classes (class_name, grade_id) VALUES (@name, @grade)";
            string selectIdQuery = "SELECT LAST_INSERT_ID()";

            using (var conn = DbConnect.GetConnection())
            {
                conn.Open();

                // Bước 1: Insert
                using (var cmd = new MySqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@name", c.ClassName);
                    cmd.Parameters.AddWithValue("@grade", c.GradeId);
                    cmd.ExecuteNonQuery();
                }

                // Bước 2: Lấy ID vừa tạo
                using (var cmd = new MySqlCommand(selectIdQuery, conn))
                {
                    // ExecuteScalar trả về object, convert an toàn sang int
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        // 3. Cập nhật thông tin cơ bản của lớp
        public static void UpdateClass(ClassDTO c)
        {
            string query = "UPDATE classes SET class_name = @name, grade_id = @grade WHERE class_id = @id";
            using (var conn = DbConnect.GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", c.ClassName);
                    cmd.Parameters.AddWithValue("@grade", c.GradeId);
                    cmd.Parameters.AddWithValue("@id", c.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 4. Xóa lớp
        public static void DeleteClass(int id)
        {
            // Xóa phân công trước (nếu DB chưa set Cascade)
            string delAssign = "DELETE FROM homeroom_assignments WHERE class_id = @id";
            string delClass = "DELETE FROM classes WHERE class_id = @id";
            using (var conn = DbConnect.GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(delAssign, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                using (var cmd = new MySqlCommand(delClass, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // --- HÀM HỖ TRỢ COMBOBOX ---

        // 5. Lấy danh sách Giáo viên
        public static List<ComboItemDTO> GetListTeachers()
        {
            var list = new List<ComboItemDTO>();
            string query = "SELECT t.teacher_id, u.fullname FROM teachers t JOIN users u ON t.user_id = u.user_id";
            using (var conn = DbConnect.GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new ComboItemDTO { Id = reader.GetInt32("teacher_id"), Name = reader.GetString("fullname") });
                    }
                }
            }
            return list;
        }

        // 6. Lấy danh sách Năm học
        public static List<ComboItemDTO> GetListYears()
        {
            var list = new List<ComboItemDTO>();
            string query = "SELECT year_id, name FROM academic_years ORDER BY year_id DESC";
            using (var conn = DbConnect.GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new ComboItemDTO { Id = reader.GetInt32("year_id"), Name = reader.GetString("name") });
                    }
                }
            }
            return list;
        }
    }
}