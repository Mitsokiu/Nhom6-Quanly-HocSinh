using System;

namespace DTO
{
    public class StudentDTO
    {
        public int Id { get; set; }           // student_id
        public string Ten { get; set; }       // fullname
        public DateTime NgaySinh { get; set; } // dob
        public string GioiTinh { get; set; }  // gender
        public string Lop { get; set; }// class_name
        public string DiaChi { get; set; }
        public int ClassId { get; set; }  // class_id

        public int YearId { get; set; }

        public string GuardianName { get; set; }
        public string GuardianPhone { get; set; }
        public string GuardianJob { get; set; }
        public string GuardianRelation { get; set; }


        // Thông tin cá nhân (Map với bảng students & users)
        public int StudentID { get; set; }
        public int UserID { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } // "Male" hoặc "Female" từ DB
        public string Address { get; set; }
        public string Avatar { get; set; }

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

        public DateTime CreatedDate { get; set; }
        public int Count { get; set; }
    }

}
