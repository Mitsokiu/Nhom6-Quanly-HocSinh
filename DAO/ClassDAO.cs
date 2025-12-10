using DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

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

        // Trả về lớp kèm tên khối
        public static List<ClassDTO> GetAllClasses()
        {
            var list = new List<ClassDTO>();
            string query = @"
                SELECT c.class_id, c.class_name, c.grade_id, g.grade_name
                FROM classes c
                JOIN grade_levels g ON c.grade_id = g.grade_id
                ORDER BY g.grade_id, c.class_name
            ";

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
                            GradeName = reader.GetString("grade_name")
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

        public static DataTable GetClassesByYear(int yearId)
        {
            string sql = @"
                SELECT DISTINCT c.class_id, c.class_name
                FROM classes c
                JOIN student_class sc ON sc.class_id = c.class_id
                WHERE sc.school_year_id = @param0";

            return DbConnect.ExecuteQuery(sql, new object[] { yearId });
        }






        //public static void AddClass(ClassDTO c)
        //{
        //    using (var context = new SchoolDbContext())
        //    {
        //        var newClass = new Class
        //        {
        //            ClassName = c.ClassName,
        //            GradeId = c.GradeId
        //        };

        //        context.Classes.Add(newClass);
        //        context.SaveChanges();

        //        // Cập nhật Id vừa tạo về DTO nếu cần
        //        c.Id = newClass.ClassId;
        //    }
        //}








        public static List<ClassDTO> GetAllClass()
        {
            string query = @"
        SELECT c.class_id, c.class_name, c.grade_id, g.grade_name
        FROM classes c
        JOIN grade_levels g ON c.grade_id = g.grade_id
    ";

            DataTable dt = new DataTable();
            using (var conn = DbConnect.GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                using (var adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }

            // Dùng LINQ to Objects để chuyển DataTable sang List<ClassDTO> và sắp xếp
            var list = dt.AsEnumerable()
                         .Select(row => new ClassDTO
                         {
                             Id = row.Field<int>("class_id"),
                             ClassName = row.Field<string>("class_name"),
                             GradeId = row.Field<int>("grade_id"),
                             GradeName = row.Field<string>("grade_name")
                         })
                         .OrderBy(c => c.GradeId)
                         .ThenBy(c => c.ClassName)
                         .ToList();

            return list;
        }

    }
}
