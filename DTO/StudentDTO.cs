using System;

namespace DTO
{
    public class StudentDTO
    {
        // Thông tin cá nhân (Map với bảng students & users)
        public int StudentID { get; set; }
        public int UserID { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } // "Male" hoặc "Female" từ DB
        public string Address { get; set; }

        // Thông tin học tập (Map với bảng student_class -> classes)
        public int ClassID { get; set; }
        public int YearID { get; set; } // Thêm YearID để lưu ID năm học
        public string ClassName { get; set; }
        public string AcademicYear { get; set; } // Map với academic_years.name

        // Thông tin Phụ huynh (Lấy từ bảng student_parent -> parents -> users)
        public string FatherName { get; set; }
        public string FatherPhone { get; set; }
        public string FatherJob { get; set; }

        public string MotherName { get; set; }
        public string MotherPhone { get; set; }
        public string MotherJob { get; set; }

        // --- Các thuộc tính hiển thị (Read-only) ---

        // Hiển thị ngày sinh dạng dd/MM/yyyy
        public string DobDisplay => DateOfBirth.ToString("dd/MM/yyyy");

        // Hiển thị mã số học sinh có tiền tố HS (Ví dụ: HS001)
        public string StudentCode => "HS" + StudentID.ToString("D3");

        // Hiển thị giới tính tiếng Việt (Nếu DB lưu tiếng Anh)
        public string GenderDisplay => (Gender == "Male") ? "Nam" : "Nữ";
    }
}