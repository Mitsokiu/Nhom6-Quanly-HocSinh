using System;
using System.Data;
using System.Windows.Forms;


namespace DAO
{
    public class TeacherDAO
    {
        public int GetCurrentYearId()
        {
            string sql = "SELECT year_id FROM academic_years WHERE @param0 BETWEEN start_date AND end_date";
            DataTable dt = DbConnect.ExecuteQuery(sql, new object[] { DateTime.Today });

            if (dt.Rows.Count > 0)
                return Convert.ToInt32(dt.Rows[0]["year_id"]);

            return -1; 
        }
        //public int GetCurrentYearId()
        //{
        //    string sql = "SELECT year_id FROM academic_years WHERE start_date <= @param0 AND end_date >= @param0";
        //    DataTable dt = DbConnect.ExecuteQuery(sql, new object[] { DateTime.Today });

        //    if (dt.Rows.Count > 0 && dt.Rows[0]["year_id"] != DBNull.Value)
        //        return Convert.ToInt32(dt.Rows[0]["year_id"]);

        //    return -1; // Không tìm thấy năm học phù hợp
        //}


        public int GetHomeroomClassId(int teacherUserId)
        {
           
            //int yearId = GetCurrentYearId();
            int yearId = 1;
            if (yearId == -1) return -1;

            string sql = @"SELECT class_id 
                           FROM homeroom_assignments 
                           WHERE teacher_id = @param0 AND year_id = @param1";

            DataTable dt = DbConnect.ExecuteQuery(sql, new object[] { teacherUserId, yearId });

            return dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0]["class_id"]) : -1;
        }

        public DataTable GetHomeroomClass(int teacherUserId)
        {
            int classId = GetHomeroomClassId(teacherUserId);
           
            if (classId <= 0) return new DataTable();

            string sql = "SELECT class_id, class_name FROM classes WHERE class_id = @param0";
            return DbConnect.ExecuteQuery(sql, new object[] { classId });
        }

        public DataTable GetCurrentAcademicYear()
        {
            string sql = "SELECT year_id, name FROM academic_years WHERE @param0 BETWEEN start_date AND end_date";
            return DbConnect.ExecuteQuery(sql, new object[] { DateTime.Today });
        }


        public DataTable GetHomeroomClassByTeacherAndYear(int teacherUserId, int yearId)
        {
            if (yearId <= 0) return new DataTable();

            string sql = @"
                SELECT c.class_id, c.class_name
                FROM homeroom_assignments ha
                INNER JOIN classes c ON ha.class_id = c.class_id
                WHERE ha.teacher_id = @param0 AND ha.year_id = @param1
                LIMIT 1";

            DataTable dt = DbConnect.ExecuteQuery(sql, new object[] { teacherUserId, yearId });
            return dt;
        }
    }


}