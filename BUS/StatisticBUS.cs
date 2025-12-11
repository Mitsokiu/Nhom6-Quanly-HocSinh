using DAO;
using System.Data;

namespace BUS
{
    public class StatisticBUS
    {
        private StatisticDAO dao = new StatisticDAO();

        // Cơ cấu
        public int GetTotalStudents() => dao.GetTotalStudents();
        public int GetTotalTeachers() => dao.GetTotalTeachers();
        public int GetTotalClasses() => dao.GetTotalClasses();
        public DataTable GetStudentStats(string criteria)
        {
            if (criteria == "Thống kê HS theo giới tính") return dao.GetStudentStatsByGender();
            if (criteria == "Thống kê HS theo khối") return dao.GetStudentStatsByGrade();
            if (criteria == "Thống kê HS theo lớp") return dao.GetStudentStatsByClass();
            return new DataTable();
        }

        // Điểm số [CẬP NHẬT]
        public DataTable GetGradeLevels() => dao.GetAllGradeLevels();
        public DataTable GetSemesters() => dao.GetAllSemesters(); // Trả về DataTable có cột 'semester_display'

        // Nhận vào ID thay vì Name
        public DataTable GetOverallAverageScoreDistribution(int gradeId, int semId) => dao.GetOverallAverageScoreDistribution(gradeId, semId);
        public DataTable GetTopTenStudentsByAvgScore(int gradeId, int semId) => dao.GetTopTenStudentsByAvgScore(gradeId, semId);

        // --- HỌC PHÍ ---

        public DataTable GetTuitionSummary(int semId, int gradeId) => dao.GetTuitionSummary(semId, gradeId);

        public DataTable GetTuitionCountStatus(int semId, int gradeId) => dao.GetTuitionCountStatus(semId, gradeId);

        public DataTable GetUnpaidStudents(int semId, int gradeId) => dao.GetUnpaidStudents(semId, gradeId);
    }
}