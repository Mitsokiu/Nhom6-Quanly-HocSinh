using System;

namespace DTO
{
    public class AttendanceDTO
    {
        public int StudentId { get; set; }
        public string StudentCode { get; set; }
        public string StudentName { get; set; }
        public string Gender { get; set; }
        public int AttendanceId { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }
        public int ClassId { get; set; }
    }
}