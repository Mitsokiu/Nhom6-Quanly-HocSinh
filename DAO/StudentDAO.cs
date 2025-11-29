using DTO;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace DAO
{
    public class StudentDAO
    {
        public static DataTable GetStudents(int yearId, int classId)
        {
            DataTable dt = new DataTable();
            using (var conn = DbConnect.GetConnection())
            {
                conn.Open();
                string sql = @"
            SELECT 
                s.student_id AS Id,
                u.fullname AS Ten,
                s.dob AS 'Ngay Sinh',
                s.gender AS 'Gioi Tinh',
                s.address AS DiaChi,
                c.class_name AS Lop

            FROM students s
            JOIN users u ON u.user_id = s.user_id
            LEFT JOIN student_class sc
                   ON sc.student_id = s.student_id 
                  AND sc.school_year_id = @year_id
            LEFT JOIN classes c 
                   ON c.class_id = sc.class_id
        ";

                if (classId > 0)
                    sql += " WHERE sc.class_id = @class_id";

                sql += " ORDER BY u.fullname";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@year_id", yearId);
                    if (classId > 0)
                        cmd.Parameters.AddWithValue("@class_id", classId);

                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public static bool UpdateStudent(StudentDTO student)
        {
            try
            {
                using (var conn = DbConnect.GetConnection())
                {
                    conn.Open();

                    // 1. Cập nhật thông tin cơ bản
                    string sqlStudent = @"
                UPDATE students s
                JOIN users u ON s.user_id = u.user_id
                SET u.fullname = @Ten,
                    s.dob = @NgaySinh,
                    s.gender = @GioiTinh,
                    s.address = @DiaChi
                WHERE s.student_id = @Id
            ";

                    using (var cmd = new MySqlCommand(sqlStudent, conn))
                    {
                        cmd.Parameters.AddWithValue("@Ten", student.Ten);
                        cmd.Parameters.AddWithValue("@NgaySinh", student.NgaySinh);
                        cmd.Parameters.AddWithValue("@GioiTinh", student.GioiTinh);
                        cmd.Parameters.AddWithValue("@DiaChi", student.DiaChi ?? "");
                        cmd.Parameters.AddWithValue("@Id", student.Id);
                        cmd.ExecuteNonQuery();
                    }

                    // 2. Cập nhật lớp (student_class)
                    if (student.ClassId > 0 && student.YearId > 0)
                    {
                        string sqlClass = @"
                    INSERT INTO student_class (student_id, class_id, school_year_id)
                    VALUES (@Id, @ClassId, @YearId)
                    ON DUPLICATE KEY UPDATE class_id = @ClassId
                ";

                        using (var cmdClass = new MySqlCommand(sqlClass, conn))
                        {
                            cmdClass.Parameters.AddWithValue("@Id", student.Id);
                            cmdClass.Parameters.AddWithValue("@ClassId", student.ClassId);
                            cmdClass.Parameters.AddWithValue("@YearId", student.YearId);
                            cmdClass.ExecuteNonQuery();
                        }
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi cập nhật: " + ex.Message);
                return false;
            }
        }




    }
}
