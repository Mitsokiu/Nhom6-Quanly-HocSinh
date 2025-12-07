using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ScoreDTO
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string ScoreType { get; set; }
        public float? ScoreValue { get; set; }
        public int? ScoreId { get; set; }
        public string ClassName { get; set; }
    }
}
