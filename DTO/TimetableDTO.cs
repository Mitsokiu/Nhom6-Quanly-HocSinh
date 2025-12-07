using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TimetableDTO
    {
        public string SubjectName { get; set; }
        public string TeacherName { get; set; }
        public string Room { get; set; }
        public string Day { get; set; } 
        public int Period { get; set; } 
    }
}
