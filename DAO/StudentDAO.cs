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
        private static StudentDAO instance;
        public static StudentDAO Instance
        {
            get { if (instance == null) instance = new StudentDAO(); return instance; }
        }
        private StudentDAO() { }

        // Tìm ClassId dựa trên UserId của học sinh
        public int GetClassIdByUserId(int userId)
        {
            string query = @"
                SELECT sc.class_id 
                FROM student_class sc
                JOIN students s ON sc.student_id = s.student_id
                WHERE s.user_id = @param0
                ORDER BY sc.id DESC LIMIT 1";

            DataTable data = DbConnect.ExecuteQuery(query, new object[] { userId });

            if (data.Rows.Count > 0)
            {
                return Convert.ToInt32(data.Rows[0]["class_id"]);
            }
            return -1;
        }
    }
}
