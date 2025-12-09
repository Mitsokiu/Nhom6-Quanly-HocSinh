using System;
using System.Data;

namespace DAO
{
    public class StatisticDAO
    {
        // --- PHẦN 1: CƠ CẤU (Cũ + Sửa tên cột nếu cần) ---
        public int GetTotalStudents() => Convert.ToInt32(DbConnect.ExecuteScalar("SELECT COUNT(*) FROM students"));
        public int GetTotalTeachers() => Convert.ToInt32(DbConnect.ExecuteScalar("SELECT COUNT(*) FROM users WHERE role_id IN ('gvcn', 'gvbm', 'teacher')"));
        public int GetTotalClasses() => Convert.ToInt32(DbConnect.ExecuteScalar("SELECT COUNT(*) FROM classes"));

        public DataTable GetStudentStatsByGender()
        {
            return DbConnect.ExecuteQuery("SELECT gender AS 'Danh Mục', COUNT(*) AS 'Số Lượng' FROM students GROUP BY gender");
        }

        public DataTable GetStudentStatsByClass()
        {
            string query = @"SELECT c.class_name AS 'Danh Mục', COUNT(sc.student_id) AS 'Số Lượng' 
                             FROM classes c LEFT JOIN student_class sc ON c.class_id = sc.class_id 
                             GROUP BY c.class_id, c.class_name ORDER BY c.class_name";
            return DbConnect.ExecuteQuery(query);
        }

        public DataTable GetStudentStatsByGrade()
        {
            string query = @"SELECT g.grade_name AS 'Danh Mục', COUNT(sc.student_id) AS 'Số Lượng' 
                             FROM grade_levels g JOIN classes c ON g.grade_id = c.grade_id 
                             LEFT JOIN student_class sc ON c.class_id = sc.class_id 
                             GROUP BY g.grade_id, g.grade_name ORDER BY g.grade_name";
            return DbConnect.ExecuteQuery(query);
        }

        // --- PHẦN 2: ĐIỂM SỐ (Mới) ---

        // 2.1. Điểm trung bình môn theo Lớp
        public DataTable GetAvgScoreByClass(string subjectName, string semesterName)
        {
            // Logic: Tính điểm trung bình của score_value (bỏ qua trọng số cho đơn giản demo, hoặc tính AVG trực tiếp)
            string query = @"
                SELECT c.class_name AS 'Lớp', AVG(s.score_value) AS 'Điểm TB'
                FROM scores s
                JOIN teacher_assignments ta ON s.assign_id = ta.assign_id
                JOIN classes c ON ta.class_id = c.class_id
                JOIN subjects sub ON ta.subject_id = sub.subject_id
                JOIN semesters sem ON ta.semester_id = sem.semester_id
                WHERE sub.name = @param0 AND sem.name = @param1
                GROUP BY c.class_name";
            return DbConnect.ExecuteQuery(query, new object[] { subjectName, semesterName });
        }

        // 2.2. Tỉ lệ phổ điểm (Yếu, TB, Khá, Giỏi)
        public DataTable GetScoreDistribution(string subjectName, string semesterName)
        {
            string query = @"
                SELECT 
                    SUM(CASE WHEN s.score_value < 5 THEN 1 ELSE 0 END) AS 'Dưới 5',
                    SUM(CASE WHEN s.score_value >= 5 AND s.score_value < 6.5 THEN 1 ELSE 0 END) AS '5 - 6.4',
                    SUM(CASE WHEN s.score_value >= 6.5 AND s.score_value < 8 THEN 1 ELSE 0 END) AS '6.5 - 7.9',
                    SUM(CASE WHEN s.score_value >= 8 THEN 1 ELSE 0 END) AS '8 - 10'
                FROM scores s
                JOIN teacher_assignments ta ON s.assign_id = ta.assign_id
                JOIN subjects sub ON ta.subject_id = sub.subject_id
                JOIN semesters sem ON ta.semester_id = sem.semester_id
                WHERE sub.name = @param0 AND sem.name = @param1";
            return DbConnect.ExecuteQuery(query, new object[] { subjectName, semesterName });
        }

        // 2.3. Top học sinh (Cao nhất/Thấp nhất)
        public DataTable GetTopStudentScores(string subjectName, string semesterName, bool isDesc)
        {
            string sort = isDesc ? "DESC" : "ASC";
            string query = $@"
                SELECT u.fullname AS 'Họ Tên', c.class_name AS 'Lớp', s.score_value AS 'Điểm', s.score_type AS 'Loại điểm'
                FROM scores s
                JOIN students stu ON s.student_id = stu.student_id
                JOIN users u ON stu.user_id = u.user_id
                JOIN teacher_assignments ta ON s.assign_id = ta.assign_id
                JOIN classes c ON ta.class_id = c.class_id
                JOIN subjects sub ON ta.subject_id = sub.subject_id
                JOIN semesters sem ON ta.semester_id = sem.semester_id
                WHERE sub.name = @param0 AND sem.name = @param1
                ORDER BY s.score_value {sort}
                LIMIT 5";
            return DbConnect.ExecuteQuery(query, new object[] { subjectName, semesterName });
        }

        // Helper: Lấy danh sách môn học và học kỳ để đổ vào ComboBox
        public DataTable GetAllSubjects() => DbConnect.ExecuteQuery("SELECT name FROM subjects");
        public DataTable GetAllSemesters() => DbConnect.ExecuteQuery("SELECT name FROM semesters");

        // --- PHẦN 3: HỌC PHÍ (Mới) ---
        public DataTable GetTuitionStats(string semesterName)
        {
            string query = @"
                SELECT status AS 'Trạng Thái', COUNT(*) AS 'Số Lượng', SUM(amount) AS 'Tổng Tiền'
                FROM tuition t
                JOIN semesters s ON t.semester_id = s.semester_id
                WHERE s.name = @param0
                GROUP BY status";
            return DbConnect.ExecuteQuery(query, new object[] { semesterName });
        }
    }
}