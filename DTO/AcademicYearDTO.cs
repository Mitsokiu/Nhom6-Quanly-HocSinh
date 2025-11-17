// AcademicYearDTO.cs
using System;

namespace DTO
{
    public class AcademicYearDTO
    {
        public int YearId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}