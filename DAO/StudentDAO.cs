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
    }
}
