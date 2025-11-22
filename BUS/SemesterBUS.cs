using DAO;
using DTO;
using System.Collections.Generic;

namespace BUS
{
    public class SemesterBUS
    {
        public List<SemesterDTO> GetAllSemesters()
        {
            return SemesterDAO.Instance.GetAllSemesters();
        }
    }
}