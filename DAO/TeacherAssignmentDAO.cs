using System;
using System.Data;
using DAO;
using DTO;

namespace DAO
{
    public class TeacherAssignmentDAO
    {
        public static DataTable GetAllAssignments()
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


        public static bool AddAssignment(TeacherAssignmentDTO dto)
        {
            string query = "INSERT INTO teacher_assignments (teacher_id, subject_id, class_id, semester_id, periods) VALUES (@param0,@param1,@param2,@param3,@param4)";
            int result = DbConnect.ExecuteNonQuery(query, new object[] { dto.TeacherId, dto.SubjectId, dto.ClassId, dto.SemesterId, dto.Periods });
            return result > 0;
        }

        public static bool UpdateAssignment(TeacherAssignmentDTO dto)
        {
            string query = "UPDATE teacher_assignments SET teacher_id=@param0, subject_id=@param1, class_id=@param2, semester_id=@param3, periods=@param4 WHERE assign_id=@param5";
            int result = DbConnect.ExecuteNonQuery(query, new object[] { dto.TeacherId, dto.SubjectId, dto.ClassId, dto.SemesterId, dto.Periods, dto.AssignId });
            return result > 0;
        }

        public static bool DeleteAssignment(int assignId)
        {
            string query = "DELETE FROM teacher_assignments WHERE assign_id=@param0";
            int result = DbConnect.ExecuteNonQuery(query, new object[] { assignId });
            return result > 0;
        }
    }
}
