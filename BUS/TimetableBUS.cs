using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class TimetableBUS
    {
        private TimetableDAO dao = new TimetableDAO();

        public List<TimetableDTO> GetTimetableByClass(int classID, int semesterID)
        {
            return dao.GetTimetableByClass(classID, semesterID);
        }
    }
}
