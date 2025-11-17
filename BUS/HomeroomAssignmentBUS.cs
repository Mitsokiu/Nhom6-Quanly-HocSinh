using System.Data;

namespace BUS
{
    public class HomeroomAssignmentBUS
    {
        public static DataTable GetAllAssignments() => DAO.HomeroomAssignmentDAO.GetAllAssignments();

        public static bool AddAssignment(DTO.HomeroomAssignmentDTO dto) => DAO.HomeroomAssignmentDAO.AddAssignment(dto);

        public static bool UpdateAssignment(DTO.HomeroomAssignmentDTO dto) => DAO.HomeroomAssignmentDAO.UpdateAssignment(dto);

        public static bool DeleteAssignment(int id) => DAO.HomeroomAssignmentDAO.DeleteAssignment(id);
    }
}
