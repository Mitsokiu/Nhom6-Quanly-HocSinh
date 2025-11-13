using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{

    public class GradeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }    // tên khối
        public string Level { get; set; }   // level (ví dụ 10,11,12)
        public string gvcn { get; set; } // tên GVCN
    }

}
