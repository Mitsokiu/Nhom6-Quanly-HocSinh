using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class StudentDAO
    {
        private DbConnect db = new DbConnect();

        // Hàm lấy ClassID từ UserID
        public int GetClassIdByUserId(int userID)
        {
            string query = @"SELECT sc.class_id
                FROM student_class sc
                JOIN students s ON sc.student_id = s.student_id
                WHERE s.user_id = @param0
                ORDER BY sc.id DESC LIMIT 1";
            DataTable data = DbConnect.ExecuteQuery(query, new object[] { userID });
            if(data.Rows.Count > 0)
            {
                return Convert.ToInt32(data.Rows[0]["class_id"]);
            }
            return -1; // Trả về -1 nếu không tìm thấy
        }

        // Hàm lấy StudentID từ UserID
        public int GetStudentIdByUserId(int userID)
        {
            String query = "SELECT student_id FROM students WHERE user_id = @param0";
            DataTable data = DbConnect.ExecuteQuery(query, new object[] { userID });
            if(data.Rows.Count > 0)
                return (int)data.Rows[0]["student_id"];
            return -1;
        }

        public DataTable GetStudentMainInfo(int userId)
        {
            string query = @"
                SELECT 
                    s.student_id, u.fullname, u.email, u.phone, 
                    s.dob, s.gender, s.address, 
                    c.class_name, ay.name AS school_year,
                    teacher.fullname AS gvcn_name, teacher.phone AS gvcn_phone
                FROM users u
                JOIN students s ON u.user_id = s.user_id
                LEFT JOIN student_class sc ON s.student_id = sc.student_id
                LEFT JOIN classes c ON sc.class_id = c.class_id
                LEFT JOIN academic_years ay ON sc.school_year_id = ay.year_id
                LEFT JOIN homeroom_assignments ha ON c.class_id = ha.class_id AND ha.year_id = ay.year_id
                LEFT JOIN users teacher ON ha.teacher_id = teacher.user_id
                WHERE u.user_id = @param0
                ORDER BY ay.start_date DESC 
                LIMIT 1";

            return DbConnect.ExecuteQuery(query, new object[] { userId });
        }

        public DataTable GetStudentParents(int studentId)
        {
            string query = @"
                SELECT 
                    p_user.fullname, p_user.phone, p_user.email, 
                    p.job, sp.relation
                FROM student_parent sp
                JOIN parents p ON sp.parent_id = p.parent_id
                JOIN users p_user ON p.user_id = p_user.user_id
                WHERE sp.student_id = @param0";

            return DbConnect.ExecuteQuery(query, new object[] { studentId });
        }
    }
}
