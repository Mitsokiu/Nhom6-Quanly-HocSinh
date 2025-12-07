using System;
using System.Data;
using DTO;
using DAO;

namespace DAO
{
    public class TeacherAssignmentDAO
    {
        // ============================================================
        // Lấy tất cả phân công
        // ============================================================
        public static DataTable GetAllAssignments()
        {
            try
            {
                string query = @"
                    SELECT 
                        ta.assign_id,
                        ta.class_id,
                        c.class_name,
                        ta.subject_id,
                        s.name AS subject_name,
                        ta.teacher_id,
                        u.fullname AS teacher_name,
                        ta.semester_id,
                        sem.name AS semester_name,
                        ta.periods
                    FROM teacher_assignments ta
                    JOIN classes c ON ta.class_id = c.class_id
                    JOIN subjects s ON ta.subject_id = s.subject_id
                    JOIN users u ON ta.teacher_id = u.user_id
                    JOIN semesters sem ON ta.semester_id = sem.semester_id;
                ";

                return DbConnect.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tải danh sách phân công: " + ex.Message);
            }
        }

        // ============================================================
        // Thêm phân công
        // ============================================================
        public static bool AddAssignment(TeacherAssignmentDTO dto)
        {
            try
            {
                string query = @"
                    INSERT INTO teacher_assignments 
                    (teacher_id, subject_id, class_id, semester_id, periods) 
                    VALUES (@param0,@param1,@param2,@param3,@param4)
                ";

                int result = DbConnect.ExecuteNonQuery(query,
                    new object[]
                    {
                        dto.TeacherId,
                        dto.SubjectId,
                        dto.ClassId,
                        dto.SemesterId,
                        dto.Periods
                    });

                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm phân công: " + ex.Message);
            }
        }

        // ============================================================
        // Cập nhật phân công
        // ============================================================
        public static bool UpdateAssignment(TeacherAssignmentDTO dto)
        {
            try
            {
                string query = @"
                    UPDATE teacher_assignments 
                    SET teacher_id=@param0, 
                        subject_id=@param1, 
                        class_id=@param2, 
                        semester_id=@param3, 
                        periods=@param4 
                    WHERE assign_id=@param5
                ";

                int result = DbConnect.ExecuteNonQuery(query,
                    new object[]
                    {
                        dto.TeacherId,
                        dto.SubjectId,
                        dto.ClassId,
                        dto.SemesterId,
                        dto.Periods,
                        dto.AssignId
                    });

                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật phân công: " + ex.Message);
            }
        }

        // ============================================================
        // Xóa phân công
        // ============================================================
        public static bool DeleteAssignment(int assignId)
        {
            try
            {
                string query = "DELETE FROM teacher_assignments WHERE assign_id=@param0";

                int result = DbConnect.ExecuteNonQuery(query, new object[] { assignId });

                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa phân công: " + ex.Message);
            }
        }

        // ============================================================
        // Lấy phân công theo học kỳ
        // ============================================================
        public static DataTable GetAssignmentsBySemester(int semesterId)
        {
            try
            {
                string sql = $@"
                    SELECT 
                        a.assign_id,
                        a.class_id,
                        a.subject_id,
                        a.teacher_id,
                        a.semester_id,
                        a.periods,
                        c.class_name,
                        s.name AS subject_name,
                        u.fullname AS teacher_name,
                        sem.name AS semester_name,
                        ay.year_id
                    FROM teacher_assignments a
                    JOIN classes c ON a.class_id = c.class_id
                    JOIN subjects s ON a.subject_id = s.subject_id
                    JOIN users u ON a.teacher_id = u.user_id
                    JOIN semesters sem ON a.semester_id = sem.semester_id
                    JOIN academic_years ay ON sem.year_id = ay.year_id
                    WHERE a.semester_id = {semesterId}
                    ORDER BY c.class_name, s.name
                ";

                return DbConnect.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tải phân công theo học kỳ: " + ex.Message);
            }
        }

       
    }
}
