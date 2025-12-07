using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace DAO
{
    public class HomeroomAssignmentDAO
    {
        // Lấy tất cả phân công GVCN
        public static DataTable GetAllAssignments()
        {
            string query = @"
                SELECT 
                    h.assign_id,
                    h.class_id,
                    c.class_name,
                    h.teacher_id,
                    u.fullname AS teacher_name,
                    h.year_id,
                    y.name AS year_name,
                    h.assigned_date
                FROM homeroom_assignments h
                JOIN classes c ON h.class_id = c.class_id
                JOIN users u ON h.teacher_id = u.user_id
                JOIN academic_years y ON h.year_id = y.year_id
                ORDER BY h.assigned_date DESC";

            return DbConnect.ExecuteQuery(query); // giữ nguyên ExecuteQuery nếu không cần tham số
        }

        // Thêm mới phân công GVCN
        public static bool AddAssignment(DTO.HomeroomAssignmentDTO dto)
        {
            string query = @"
                INSERT INTO homeroom_assignments (class_id, teacher_id, year_id, assigned_date) 
                VALUES (@class, @teacher, @year, @date)";

            MySqlParameter[] parameters = {
                new MySqlParameter("@class", dto.ClassId),
                new MySqlParameter("@teacher", dto.TeacherId),
                new MySqlParameter("@year", dto.YearId),
                new MySqlParameter("@date", dto.AssignedDate)
            };

            return DbConnect.ExecuteNonQuery(query, parameters) > 0;
        }

        // Cập nhật phân công GVCN
        public static bool UpdateAssignment(DTO.HomeroomAssignmentDTO dto)
        {
            string query = @"
                UPDATE homeroom_assignments 
                SET class_id=@class, teacher_id=@teacher, year_id=@year, assigned_date=@date 
                WHERE assign_id=@id";

            MySqlParameter[] parameters = {
                new MySqlParameter("@class", dto.ClassId),
                new MySqlParameter("@teacher", dto.TeacherId),
                new MySqlParameter("@year", dto.YearId),
                new MySqlParameter("@date", dto.AssignedDate),
                new MySqlParameter("@id", dto.AssignId)
            };

            return DbConnect.ExecuteNonQuery(query, parameters) > 0;
        }

        // Xóa phân công GVCN
        public static bool DeleteAssignment(int id)
        {
            string query = "DELETE FROM homeroom_assignments WHERE assign_id=@id";
            MySqlParameter[] parameters = { new MySqlParameter("@id", id) };
            return DbConnect.ExecuteNonQuery(query, parameters) > 0;
        }
    }
}
