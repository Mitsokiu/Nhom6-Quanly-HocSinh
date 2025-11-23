using System;

namespace DTO
{
    public class SemesterDTO
    {
        public int SemesterId { get; set; }
        public int YearId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
