using DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

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

        // Kiểm tra lớp theo tên và grade_id
        public static bool ExistsClass(string className, int gradeId)
        {
            string sql = "SELECT COUNT(*) FROM classes WHERE class_name=@param0 AND grade_id=@param1";
            object[] parameters = { className, gradeId };
            DataTable dt = DbConnect.ExecuteQuery(sql, parameters);
            if (dt.Rows.Count > 0)
            {
                int count = Convert.ToInt32(dt.Rows[0][0]);
                return count > 0;
            }
            return false;
        }
        public  static DataTable GetClassesByYear(int yearId)
        {
            string sql = @"
                SELECT DISTINCT c.class_id, c.class_name
                FROM classes c
                JOIN student_class sc ON sc.class_id = c.class_id
                WHERE sc.school_year_id = @param0";

            return DbConnect.ExecuteQuery(sql, new object[] { yearId });
        }

    }
}
