using System;

namespace DTO
{
    public class HomeroomAssignmentDTO
    {
        public int AssignId { get; set; }
        public int ClassId { get; set; }
        public int TeacherId { get; set; }
        public int YearId { get; set; }
        public DateTime AssignedDate { get; set; }
    }
}
