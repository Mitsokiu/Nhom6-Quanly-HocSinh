using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace BUS
{
    public class StudentBUS
    {
        public static DataTable GetStudents(int yearId, int classId)
        {
            return StudentDAO.GetStudents(yearId, classId);
        }

        public static DataTable GetStudentById(int studentId, int yearId)
        {
            return StudentDAO.GetStudentById(studentId, yearId);
        }

        public static bool UpdateStudent(StudentDTO student)
        {
            return DAO.StudentDAO.UpdateStudent(student);
        }
        private StudentDAO dao = new StudentDAO();
        public int GetClassIdByUserId(int userId)
        {
            return dao.GetClassIdByUserId(userId);
        }

       
        public List<StudentDTO> GetAllStudents() => dao.GetStudents();
        public List<StudentDTO> GetAllStudentss() => dao.GetStudentss();

        public StudentDTO GetStudentById(int studentId)
        {
            StudentDAO dao = new StudentDAO();
            return dao.GetStudentById(studentId);
        }

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
            return dao.UpdateStudents(s);
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

        public StudentProfileDTO GetStudentProfile(int userId)
        {
            StudentProfileDTO profile = new StudentProfileDTO();

            DataTable dtMain = dao.GetStudentMainInfo(userId);

            if (dtMain.Rows.Count > 0)
            {
                DataRow row = dtMain.Rows[0];
                int sId = Convert.ToInt32(row["student_id"]);

                profile.StudentId = sId;
                profile.StudentCode = "HS" + sId.ToString("D6");
                profile.FullName = row["fullname"].ToString();
                profile.Email = row["email"].ToString();
                profile.Phone = row["phone"].ToString();
                profile.Address = row["address"].ToString();

                string genderRaw = row["gender"].ToString();
                profile.Gender = (genderRaw == "Male") ? "Nam" : "Nữ";

                if (row["dob"] != DBNull.Value)
                    profile.DateOfBirth = Convert.ToDateTime(row["dob"]);

                profile.ClassName = row["class_name"].ToString();
                profile.SchoolYear = row["school_year"].ToString();

                profile.TeacherName = row["gvcn_name"].ToString();
                profile.TeacherPhone = row["gvcn_phone"].ToString();

                if (row.Table.Columns.Contains("avatar") && row["avatar"] != DBNull.Value)
                {
                    profile.Avatar = row["avatar"].ToString();
                }
                else
                {
                    profile.Avatar = "";
                }

                DataTable dtParents = dao.GetStudentParents(sId);
                foreach (DataRow pRow in dtParents.Rows)
                {
                    string relation = pRow["relation"].ToString().Trim();

                    if (relation.Equals("Cha", StringComparison.OrdinalIgnoreCase))
                    {
                        profile.FatherName = pRow["fullname"].ToString();
                        profile.FatherPhone = pRow["phone"].ToString();
                        profile.FatherEmail = pRow["email"].ToString();
                        profile.FatherJob = pRow["job"].ToString();
                    }
                    else if (relation.Equals("Mẹ", StringComparison.OrdinalIgnoreCase))
                    {
                        profile.MotherName = pRow["fullname"].ToString();
                        profile.MotherPhone = pRow["phone"].ToString();
                        profile.MotherEmail = pRow["email"].ToString();
                        profile.MotherJob = pRow["job"].ToString();
                    }
                }
            }
            return profile;
        }

        // Thêm hàm này vào lớp StudentBUS
        public static DataTable GetStudentCountByClass(int yearId)
        {
            // Gọi hàm từ StudentDAO để lấy dữ liệu thống kê
            return StudentDAO.GetStudentCountByClass(yearId);
        }
    }
}
