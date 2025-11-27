using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace BUS
{
    public class StudentBUS
    {
        private StudentDAO dao = new StudentDAO();

        public int GetClassIdByUserId(int userId) => dao.GetClassIdByUserId(userId);
        public List<StudentDTO> GetAllStudents() => dao.GetStudents();
        public List<StudentDTO> SearchStudents(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword) || keyword == "Tìm kiếm học sinh...")
                return GetAllStudents();
            return dao.SearchStudents(keyword);
        }

        public bool AddStudent(StudentDTO s, out string error)
        {
            if (!ValidateStudent(s, out error)) return false;
            return dao.AddStudent(s);
        }

        public bool UpdateStudent(StudentDTO s, out string error)
        {
            if (!ValidateStudent(s, out error)) return false;
            return dao.UpdateStudent(s);
        }

        public bool DeleteStudent(int id) => dao.DeleteStudent(id);
        public DataTable GetClassList() => dao.GetAllClasses();
        public DataTable GetYearList() => dao.GetAllYears();

        private bool ValidateStudent(StudentDTO s, out string error)
        {
            error = "";

            if (string.IsNullOrWhiteSpace(s.FullName))
            { error = "Vui lòng nhập họ tên học sinh!"; return false; }

            if (string.IsNullOrWhiteSpace(s.Address))
            { error = "Vui lòng nhập địa chỉ!"; return false; }

            if (string.IsNullOrWhiteSpace(s.Gender) || (s.Gender != "Male" && s.Gender != "Female"))
            { error = "Vui lòng chọn giới tính!"; return false; }

            if (s.ClassID <= 0)
            { error = "Vui lòng chọn lớp!"; return false; }

            if (s.YearID <= 0)
            { error = "Vui lòng chọn năm học!"; return false; }

            if (s.DateOfBirth.Date > DateTime.Now.Date)
            { error = "Ngày sinh không được là ngày trong tương lai!"; return false; }

            int age = DateTime.Now.Year - s.DateOfBirth.Year;
            if (DateTime.Now < s.DateOfBirth.AddYears(age)) age--;
            if (age < 10 || age > 18)
            { error = "Độ tuổi học sinh không phù hợp (10-18 tuổi)!"; return false; }

            bool hasFather = !string.IsNullOrWhiteSpace(s.FatherName);
            bool hasMother = !string.IsNullOrWhiteSpace(s.MotherName);

            if (!hasFather && !hasMother)
            { error = "Vui lòng nhập thông tin ít nhất một phụ huynh (cha hoặc mẹ)!"; return false; }

            if (hasFather)
            {
                if (string.IsNullOrWhiteSpace(s.FatherPhone)) { error = "Vui lòng nhập số điện thoại của cha!"; return false; }
                if (string.IsNullOrWhiteSpace(s.FatherJob)) { error = "Vui lòng nhập nghề nghiệp của cha!"; return false; }
            }

            if (hasMother)
            {
                if (string.IsNullOrWhiteSpace(s.MotherPhone)) { error = "Vui lòng nhập số điện thoại của mẹ!"; return false; }
                if (string.IsNullOrWhiteSpace(s.MotherJob)) { error = "Vui lòng nhập nghề nghiệp của mẹ!"; return false; }
            }

            return true;
        }
    }
}