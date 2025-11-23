using DAO;
using DTO;
using System.Collections.Generic;

namespace BUS
{
    public class SemesterBUS
    {   
        private SemesterDAO dao = new SemesterDAO();
        public List<SemesterDTO> GetAllSemesters()
        {
            return dao.GetAllSemesters();
        }
    }
}