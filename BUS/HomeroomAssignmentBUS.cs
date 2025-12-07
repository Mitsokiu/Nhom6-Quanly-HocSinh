using DAO;
using System;
using System.Data;

namespace BUS
{
    public class HomeroomAssignmentBUS
    {
        public static DataTable GetAllAssignments()
        {
            return DAO.HomeroomAssignmentDAO.GetAllAssignments();
        }

        public static void AddAssignment(DTO.HomeroomAssignmentDTO dto)
        {
            try
            {
                bool result = DAO.HomeroomAssignmentDAO.AddAssignment(dto);
                if (!result)
                    throw new Exception("Không thể thêm phân công GVCN.");
            }
            catch (Exception ex)
            {
                // Ném lỗi lên UI để hiển thị
                throw new Exception(ex.Message);
            }
        }

        // Lấy phân công theo năm
        public static DataTable GetAssignmentsByYear(int yearId)
        {
            return HomeroomAssignmentDAO.GetAssignmentsByYear(yearId);
        }
        public static void UpdateAssignment(DTO.HomeroomAssignmentDTO dto)
        {
            try
            {
                bool result = DAO.HomeroomAssignmentDAO.UpdateAssignment(dto);
                if (!result)
                    throw new Exception("Không thể cập nhật phân công GVCN.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteAssignment(int id)
        {
            try
            {
                bool result = DAO.HomeroomAssignmentDAO.DeleteAssignment(id);
                if (!result)
                    throw new Exception("Không thể xóa phân công GVCN.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
