using System;

namespace DTO
{
    public class StudentDTO
    {
        public int StudentID { get; set; }
        public int UserID { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } 
        public string Address { get; set; }
        public string Avatar { get; set; }

        public int ClassID { get; set; }
        public int YearID { get; set; } 
        public string ClassName { get; set; }
        public string AcademicYear { get; set; } 

        public string FatherName { get; set; }
        public string FatherPhone { get; set; }
        public string FatherJob { get; set; }

        public string MotherName { get; set; }
        public string MotherPhone { get; set; }
        public string MotherJob { get; set; }

        public string GuardianName { get; set; }
        public string GuardianPhone { get; set; }
        public string GuardianJob { get; set; }
        public string GuardianRelation { get; set; }


        public string DobDisplay => DateOfBirth.ToString("dd/MM/yyyy");

        public string StudentCode => "HS" + StudentID.ToString("D3");

        public string GenderDisplay => (Gender == "Male") ? "Nam" : "Nữ";
    }
}