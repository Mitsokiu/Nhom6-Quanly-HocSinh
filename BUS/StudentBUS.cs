using DAO;
using DTO;
using System.Data;
using System;

namespace BUS
{
    public class StudentBUS
    {   
        private StudentDAO dao = new StudentDAO();
        public int GetClassIdByUserId(int userId)
        {
            return dao.GetClassIdByUserId(userId);
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
    }
}