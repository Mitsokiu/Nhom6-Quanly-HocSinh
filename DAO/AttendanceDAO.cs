using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAO
{
    public class AttendanceDAO
    {
        public List<AttendanceDTO> GetAttendanceList(int teacherId, DateTime date, int semesterId)
        {
            List<AttendanceDTO> list = new List<AttendanceDTO>();
            string dateStr = date.ToString("yyyy-MM-dd");

            string query = @"
                SELECT 
                    s.student_id,
                    CONCAT('HS', LPAD(s.student_id, 6, '0')) AS StudentCode,
                    u.fullname AS StudentName,
                    s.gender,
                    c.class_id,
                    c.class_name,
                    att.attendance_id,
                    IFNULL(att.status, 'present') AS Status,
                    IFNULL(att.note, '') AS Note

                FROM homeroom_assignments ha
                
                JOIN semesters sem ON sem.semester_id = @param0 AND ha.year_id = sem.year_id
                
                JOIN classes c ON ha.class_id = c.class_id
                
                JOIN student_class sc ON sc.class_id = c.class_id AND sc.school_year_id = sem.year_id
                JOIN students s ON sc.student_id = s.student_id
                JOIN users u ON s.user_id = u.user_id

                LEFT JOIN attendance att ON att.student_id = s.student_id AND att.date = @param1

                WHERE ha.teacher_id = @param2 -- TeacherID
                ORDER BY SUBSTRING_INDEX(u.fullname, ' ', -1) ASC";

            DataTable dt = DbConnect.ExecuteQuery(query, new object[] { semesterId, dateStr, teacherId });

            foreach (DataRow row in dt.Rows)
            {
                AttendanceDTO dto = new AttendanceDTO();
                dto.StudentId = Convert.ToInt32(row["student_id"]);
                dto.StudentCode = row["StudentCode"].ToString();
                dto.StudentName = row["StudentName"].ToString();
                dto.Gender = row["gender"].ToString();
                dto.ClassId = Convert.ToInt32(row["class_id"]);

                dto.AttendanceId = row["attendance_id"] != DBNull.Value ? Convert.ToInt32(row["attendance_id"]) : 0;
                dto.Status = row["Status"].ToString();
                dto.Note = row["Note"].ToString();
                dto.Date = date;
                list.Add(dto);
            }
            return list;
        }

        public bool SaveAttendance(int studentId, int classId, DateTime date, string status, string note)
        {
            string query = @"
                INSERT INTO attendance (student_id, class_id, date, status, note)
                VALUES (@param0, @param1, @param2, @param3, @param4)
                ON DUPLICATE KEY UPDATE 
                    status = @param3, 
                    note = @param4";

            return DbConnect.ExecuteNonQuery(query, new object[] {
                studentId,
                classId,
                date.ToString("yyyy-MM-dd"),
                status,
                note
            }) > 0;
        }

        public string GetClassName(int teacherId, int semesterId)
        {
            string query = @"
                SELECT c.class_name 
                FROM homeroom_assignments ha
                JOIN semesters sem ON sem.semester_id = @param0 AND ha.year_id = sem.year_id
                JOIN classes c ON ha.class_id = c.class_id
                WHERE ha.teacher_id = @param1";

            DataTable dt = DbConnect.ExecuteQuery(query, new object[] { semesterId, teacherId });

            if (dt.Rows.Count > 0) return dt.Rows[0]["class_name"].ToString();
            return "...";
        }

        public DataTable GetStudentHistory(int studentId)
        {
            string query = @"
                SELECT 
                DATE_FORMAT(date, '%d/%m/%Y') AS DateFormatted,
                CASE 
                    WHEN status = 'absent_permit' THEN 'Nghỉ có phép'
                    WHEN status = 'absent_no_permit' THEN 'Nghỉ không phép'
                    WHEN status = 'late' THEN 'Đi trễ'
                    ELSE 'Có mặt'
                END AS StatusVietnamese, note
                FROM attendance 
                WHERE student_id = @param0 
                AND status != 'present' 
                ORDER BY date DESC 
                LIMIT 5";

            return DbConnect.ExecuteQuery(query, new object[] { studentId });
        }

        public bool DeleteAttendance(int studentId, DateTime date)
        {
            string query = "DELETE FROM attendance WHERE student_id = @param0 AND date = @param1";
            return DbConnect.ExecuteNonQuery(query, new object[] { studentId, date.ToString("yyyy-MM-dd") }) > 0;
        }

        public DataTable GetDailyAbsenceList(int teacherId, int semesterId, DateTime date)
        {
            string query = @"
                SELECT 
                    u.fullname AS StudentName,
                    CONCAT('HS', LPAD(s.student_id, 6, '0')) AS StudentCode,
                CASE 
                    WHEN att.status = 'absent_permit' THEN 'Nghỉ có phép'
                    WHEN att.status = 'absent_no_permit' THEN 'Nghỉ không phép'
                    WHEN att.status = 'late' THEN 'Đi trễ'
                    ELSE 'Có mặt'
                END AS StatusVietnamese, att.note
                FROM homeroom_assignments ha
                JOIN semesters sem ON sem.semester_id = @param0 AND ha.year_id = sem.year_id
                JOIN classes c ON ha.class_id = c.class_id
                JOIN student_class sc ON sc.class_id = c.class_id AND sc.school_year_id = sem.year_id
                JOIN students s ON sc.student_id = s.student_id
                JOIN users u ON s.user_id = u.user_id
                JOIN attendance att ON att.student_id = s.student_id 
        
                WHERE ha.teacher_id = @param1 
                    AND att.date = @param2
                    AND att.status != 'present' -- Chỉ lấy Vắng hoặc Trễ
        
                ORDER BY att.attendance_id DESC";

            return DbConnect.ExecuteQuery(query, new object[] { semesterId, teacherId, date.ToString("yyyy-MM-dd") });
        }
    }
}