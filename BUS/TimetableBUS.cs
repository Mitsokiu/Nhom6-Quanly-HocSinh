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
        private static TimetableBUS instance;
        public static TimetableBUS Instance
        {
            get { if (instance == null) instance = new TimetableBUS(); return instance; }
            private set { instance = value; }
        }
        public TimetableBUS() { }
        public List<TimetableDTO> GetTimetable(int classId, int semesterId)
        {
            return TimetableDAO.Instance.GetTimetableByClass(classId, semesterId);
        }
    }
}
