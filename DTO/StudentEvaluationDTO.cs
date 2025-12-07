using System;

namespace DTO
{
    public class StudentEvaluationDTO
    {
        public string StudentCode { get; set; }  
        public string FullName { get; set; }     
        public string Conduct { get; set; }
        public string TeacherComment { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public bool IsSaved { get; set; }
    }
}