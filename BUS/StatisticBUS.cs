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

        // Điểm số
        public DataTable GetSubjects() => dao.GetAllSubjects();
        public DataTable GetSemesters() => dao.GetAllSemesters();
        public DataTable GetAvgScoreByClass(string sub, string sem) => dao.GetAvgScoreByClass(sub, sem);
        public DataTable GetScoreDistribution(string sub, string sem) => dao.GetScoreDistribution(sub, sem);
        public DataTable GetTopStudents(string sub, string sem, bool isDesc) => dao.GetTopStudentScores(sub, sem, isDesc);

        // Học phí
        public DataTable GetTuitionStats(string sem) => dao.GetTuitionStats(sem);
    }
}