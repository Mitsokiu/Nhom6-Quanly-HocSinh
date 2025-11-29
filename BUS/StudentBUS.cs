using DAO;
using DTO;
using System.Data;

namespace BUS
{
    public class StudentBUS
    {
        public static DataTable GetStudents(int yearId, int classId)
        {
            return StudentDAO.GetStudents(yearId, classId);
        }
        public static bool UpdateStudent(StudentDTO student)
        {
            return DAO.StudentDAO.UpdateStudent(student);
        }
    }
}
