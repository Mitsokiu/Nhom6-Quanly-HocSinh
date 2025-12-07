using DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace DAO
{
    public static class ClassDAO
    {
        public static void AddClass(ClassDTO c)
        {
            string query = "INSERT INTO classes (class_name, grade_id) VALUES (@name, @grade)";

            using (var conn = DbConnect.GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", c.ClassName);
                    cmd.Parameters.AddWithValue("@grade", c.GradeId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

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

        public static void DeleteClass(int id)
        {
            string query = "DELETE FROM classes WHERE class_id = @id";

            using (var conn = DbConnect.GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<ClassDTO> GetAllClasses()
        {
            var list = new List<ClassDTO>();
            string query = "SELECT class_id, class_name, grade_id FROM classes";

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
                            GradeId = reader.GetInt32("grade_id")
                        });
                    }
                }
            }
            return list;
        }

        public static bool ExistsClass(string className, int gradeId)
        {
            string query = "SELECT COUNT(*) FROM classes WHERE class_name = @name AND grade_id = @grade";

            using (var conn = DbConnect.GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", className);
                    cmd.Parameters.AddWithValue("@grade", gradeId);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0; // true nếu đã tồn tại
                }
            }
        }

    }
}
