using DAO;
using System.Data;

namespace BUS
{
    public class TeacherBUS
    {
        private TeacherDAO dao = new TeacherDAO();

        public DataTable GetHomeroomClass(int teacherUserId)
        {
            return dao.GetHomeroomClass(teacherUserId);
        }

        public DataTable GetCurrentAcademicYear()
        {
            return dao.GetCurrentAcademicYear();
        }

        public int GetCurrentHomeroomClassId(int teacherUserId)
        {
            return dao.GetHomeroomClassId(teacherUserId);
        }

        public int GetCurrentYearId()
        {
            return dao.GetCurrentYearId();
        }

        public DataTable GetHomeroomClassByTeacherAndYear(int teacherUserId, int yearId)
        {
            if (teacherUserId <= 0 || yearId <= 0)
                return new DataTable(); // trả về rỗng nếu dữ liệu không hợp lệ

            return dao.GetHomeroomClassByTeacherAndYear(teacherUserId, yearId);
        }


    }
}