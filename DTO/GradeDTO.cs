using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    internal class GradeDTO
    {
        public int GradeId { get; set; }
        public string GradeName { get; set; }

        public GradeDTO() { }

        public GradeDTO(int gradeId, string gradeName)
        {
            GradeId = gradeId;
            GradeName = gradeName;
        }
    }
}
