using System.Data;
using DTO;
using DAO;

namespace BUS
{
    public class TeacherAssignmentBUS
    {
        public static DataTable GetAllAssignments()
        {
            return TeacherAssignmentDAO.GetAllAssignments();
        }

        public static bool AddAssignment(TeacherAssignmentDTO dto)
        {
            return TeacherAssignmentDAO.AddAssignment(dto);
        }

        public static bool UpdateAssignment(TeacherAssignmentDTO dto)
        {
            return TeacherAssignmentDAO.UpdateAssignment(dto);
        }

        public static bool DeleteAssignment(int assignId)
        {
            return TeacherAssignmentDAO.DeleteAssignment(assignId);
        }
    }
}
