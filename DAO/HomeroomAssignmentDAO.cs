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
                WHERE u.role_id = 'gvcn'
                ORDER BY h.assigned_date DESC";

            return DbConnect.ExecuteQuery(query);
        }

        public static DataTable GetAssignmentsByYear(int yearId)
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
        WHERE u.role_id = 'gvcn' AND h.year_id = @yearId
        ORDER BY h.assigned_date DESC";

            using (var conn = DbConnect.GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@yearId", yearId);

                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        // Kiểm tra lớp đã có GVCN trong năm chưa
        public static bool IsClassAssigned(int classId, int yearId)
        {
            string sql = @"
                SELECT COUNT(*)
                FROM homeroom_assignments
                WHERE class_id=@param0 AND year_id=@param1";

            object result = DbConnect.ExecuteScalar(sql, new object[] { classId, yearId });
            return Convert.ToInt32(result) > 0;
        }

        // Thêm mới phân công GVCN
        public static bool AddAssignment(DTO.HomeroomAssignmentDTO dto)
        {
            if (IsClassAssigned(dto.ClassId, dto.YearId))
                throw new Exception("Lớp này đã có GVCN trong năm học này.");

            string query = @"
                INSERT INTO homeroom_assignments 
                (class_id, teacher_id, year_id, assigned_date) 
                VALUES (@param0, @param1, @param2, @param3)";

            return DbConnect.ExecuteNonQuery(query,
                new object[] { dto.ClassId, dto.TeacherId, dto.YearId, dto.AssignedDate }) > 0;
        }

        // Cập nhật phân công GVCN
        public static bool UpdateAssignment(DTO.HomeroomAssignmentDTO dto)
        {
            string check = @"
                SELECT COUNT(*)
                FROM homeroom_assignments
                WHERE class_id=@param0 AND year_id=@param1 AND assign_id<>@param2";

            object result = DbConnect.ExecuteScalar(check,
                new object[] { dto.ClassId, dto.YearId, dto.AssignId });

            if (Convert.ToInt32(result) > 0)
                throw new Exception("Lớp này đã có GVCN trong năm học này.");

            string query = @"
                UPDATE homeroom_assignments
                SET class_id=@param0, teacher_id=@param1, year_id=@param2, assigned_date=@param3
                WHERE assign_id=@param4";

            return DbConnect.ExecuteNonQuery(query,
                new object[] { dto.ClassId, dto.TeacherId, dto.YearId, dto.AssignedDate, dto.AssignId }) > 0;
        }

        // Xóa phân công
        public static bool DeleteAssignment(int id)
        {
            string query = "DELETE FROM homeroom_assignments WHERE assign_id=@param0";

            return DbConnect.ExecuteNonQuery(query, new object[] { id }) > 0;
        }
    }
}
