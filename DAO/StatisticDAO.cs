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




        // --- PHẦN ĐIỂM SỐ (CẬP NHẬT) ---

        public DataTable GetAllGradeLevels() => DbConnect.ExecuteQuery("SELECT grade_id, grade_name FROM grade_levels");

        // [MỚI] Lấy danh sách Học kỳ kèm Năm học (Ví dụ: HK1 - 2024-2025)
        public DataTable GetAllSemesters()
        {
            string query = @"
                SELECT 
                    s.semester_id, 
                    CONCAT(s.name, ' - ', y.name) AS semester_display
                FROM semesters s
                JOIN academic_years y ON s.year_id = y.year_id
                ORDER BY y.start_date DESC, s.name ASC";
            return DbConnect.ExecuteQuery(query);
        }

        // [CẬP NHẬT] Lọc theo semester_id thay vì name
        public DataTable GetOverallAverageScoreDistribution(int gradeId, int semesterId)
        {
            string query = $@"
                WITH StudentAverages AS (
                    SELECT 
                        stu.student_id,
                        AVG(s.score_value) AS DTB
                    FROM scores s
                    JOIN students stu ON s.student_id = stu.student_id
                    JOIN student_class sc ON stu.student_id = sc.student_id
                    JOIN classes c ON sc.class_id = c.class_id
                    JOIN teacher_assignments ta ON s.assign_id = ta.assign_id
                    WHERE c.grade_id = @param0 AND ta.semester_id = @param1
                    GROUP BY stu.student_id
                )
                SELECT 
                    SUM(CASE WHEN sa.DTB < 5 THEN 1 ELSE 0 END) AS 'Dưới 5',
                    SUM(CASE WHEN sa.DTB >= 5 AND sa.DTB < 6.5 THEN 1 ELSE 0 END) AS '5 - 6.4',
                    SUM(CASE WHEN sa.DTB >= 6.5 AND sa.DTB < 8 THEN 1 ELSE 0 END) AS '6.5 - 7.9',
                    SUM(CASE WHEN sa.DTB >= 8 THEN 1 ELSE 0 END) AS '8 - 10'
                FROM StudentAverages sa";
            return DbConnect.ExecuteQuery(query, new object[] { gradeId, semesterId });
        }

        // [CẬP NHẬT] Lọc theo semester_id thay vì name
        public DataTable GetTopTenStudentsByAvgScore(int gradeId, int semesterId)
        {
            string query = $@"
                SELECT
                    u.fullname AS 'Họ Tên',
                    c.class_name AS 'Lớp',
                    ROUND(AVG(s.score_value), 2) AS 'DTB'
                FROM scores s
                JOIN students stu ON s.student_id = stu.student_id
                JOIN users u ON stu.user_id = u.user_id
                JOIN student_class sc ON stu.student_id = sc.student_id
                JOIN classes c ON sc.class_id = c.class_id
                JOIN grade_levels g ON c.grade_id = g.grade_id
                JOIN teacher_assignments ta ON s.assign_id = ta.assign_id
                WHERE g.grade_id = @param0 AND ta.semester_id = @param1
                GROUP BY u.fullname, c.class_name
                ORDER BY DTB DESC
                LIMIT 10";
            return DbConnect.ExecuteQuery(query, new object[] { gradeId, semesterId });
        }

        // Helper: Lấy danh sách môn học và học kỳ để đổ vào ComboBox
        public DataTable GetAllSubjects() => DbConnect.ExecuteQuery("SELECT name FROM subjects");

        // --- PHẦN HỌC PHÍ (CẬP NHẬT MỚI) ---

        // 1. Lấy tổng quan tài chính (CÓ LỌC THEO KHỐI)
        public DataTable GetTuitionSummary(int semesterId, int gradeId)
        {
            // Logic: Join các bảng để lọc theo grade_id
            string gradeCondition = gradeId == 0 ? "" : "AND g.grade_id = " + gradeId;

            string query = $@"
                SELECT 
                    SUM(t.amount) AS TotalReceivable,
                    SUM(CASE WHEN t.status = 'paid' THEN t.amount ELSE 0 END) AS TotalPaid,
                    SUM(CASE WHEN t.status = 'unpaid' THEN t.amount ELSE 0 END) AS TotalDebt
                FROM tuition t
                JOIN students s ON t.student_id = s.student_id
                JOIN student_class sc ON s.student_id = sc.student_id
                JOIN classes c ON sc.class_id = c.class_id
                JOIN grade_levels g ON c.grade_id = g.grade_id
                WHERE t.semester_id = @param0
                {gradeCondition}";

            return DbConnect.ExecuteQuery(query, new object[] { semesterId });
        }

        // 2. Lấy tỉ lệ biểu đồ (CÓ LỌC THEO KHỐI)
        public DataTable GetTuitionCountStatus(int semesterId, int gradeId)
        {
            string gradeCondition = gradeId == 0 ? "" : "AND g.grade_id = " + gradeId;

            string query = $@"
                SELECT 
                    t.status AS 'Trạng Thái', 
                    COUNT(*) AS 'Số Lượng'
                FROM tuition t
                JOIN students s ON t.student_id = s.student_id
                JOIN student_class sc ON s.student_id = sc.student_id
                JOIN classes c ON sc.class_id = c.class_id
                JOIN grade_levels g ON c.grade_id = g.grade_id
                WHERE t.semester_id = @param0
                {gradeCondition}
                GROUP BY t.status";

            return DbConnect.ExecuteQuery(query, new object[] { semesterId });
        }

        // 3. Danh sách nợ (Đã có lọc khối, giữ nguyên logic nhưng đảm bảo đồng nhất)
        public DataTable GetUnpaidStudents(int semesterId, int gradeId)
        {
            string gradeCondition = gradeId == 0 ? "" : "AND g.grade_id = " + gradeId;

            string query = $@"
                SELECT 
                    u.fullname AS 'Họ Tên',
                    c.class_name AS 'Lớp',
                    t.name AS 'Khoản Thu',
                    t.amount AS 'Số Tiền Nợ',
                    t.due_date AS 'Hạn Nộp'
                FROM tuition t
                JOIN students s ON t.student_id = s.student_id
                JOIN users u ON s.user_id = u.user_id
                JOIN student_class sc ON s.student_id = sc.student_id
                JOIN classes c ON sc.class_id = c.class_id
                JOIN grade_levels g ON c.grade_id = g.grade_id
                WHERE t.semester_id = @param0 
                  AND t.status = 'unpaid'
                  {gradeCondition}
                ORDER BY c.class_name, u.fullname";

            return DbConnect.ExecuteQuery(query, new object[] { semesterId });
        }
    }
}