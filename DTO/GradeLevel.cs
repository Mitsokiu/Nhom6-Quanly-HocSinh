using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GradeLevel
    {
        public int GradeId { get; set; }
        public string GradeName { get; set; }

        public ICollection<Class> Classes { get; set; }
    }
}
