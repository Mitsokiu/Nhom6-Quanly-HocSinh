using DTO;
using DAO;
using System.Collections.Generic;

namespace BUS
{
    public class GVBM_TKB_BUS
    {
        private GVBM_TKB_DAO dao;

        public GVBM_TKB_BUS()
        {
            dao = new GVBM_TKB_DAO();
        }
        // Lấy TKB theo teacherID và semesterID
        public List<GVBM_TKB_DTO> GetTimetableByTeacher(int teacherID, int semesterID)
        {
            return dao.GetTimetableByTeacher(teacherID, semesterID);
        }
    }
}
