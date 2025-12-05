using System;

namespace DTO
{
    public class StudentProfileDTO
    {
        public int StudentId { get; set; }
        public string StudentCode { get; set; }
        public string FullName { get; set; }
        public string Avatar { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public string ClassName { get; set; }
        public string SchoolYear { get; set; }
        public string TeacherName { get; set; }
        public string TeacherPhone { get; set; }

        public string FatherName { get; set; }
        public string FatherPhone { get; set; }
        public string FatherJob { get; set; }
        public string FatherEmail { get; set; }

        public string MotherName { get; set; }
        public string MotherPhone { get; set; }
        public string MotherJob { get; set; }
        public string MotherEmail { get; set; }
    }
}