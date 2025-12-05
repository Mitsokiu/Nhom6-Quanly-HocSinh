using System;
using System.Data;

namespace DAO
{
    public class TeacherDAO
    {
        // 1. Lấy ID năm học hiện tại (Dựa vào ngày hôm nay)
        public int GetCurrentYearId()
        {
            string sql = "SELECT year_id FROM academic_years WHERE @param0 BETWEEN start_date AND end_date";
            DataTable dt = DbConnect.ExecuteQuery(sql, new object[] { DateTime.Today });

            if (dt.Rows.Count > 0)
                return Convert.ToInt32(dt.Rows[0]["year_id"]);

            return -1; // Không tìm thấy năm học phù hợp
        }

        // 2. Lấy ID lớp mà giáo viên đang chủ nhiệm trong năm học hiện tại
        public int GetHomeroomClassId(int teacherUserId)
        {
            int yearId = GetCurrentYearId();
            if (yearId == -1) return -1;

            string sql = @"SELECT class_id 
                           FROM homeroom_assignments 
                           WHERE teacher_id = @param0 AND year_id = @param1";

            DataTable dt = DbConnect.ExecuteQuery(sql, new object[] { teacherUserId, yearId });

            return dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0]["class_id"]) : -1;
        }

        // 3. Lấy thông tin lớp chủ nhiệm (để đổ vào ComboBox)
        public DataTable GetHomeroomClass(int teacherUserId)
        {
            int classId = GetHomeroomClassId(teacherUserId);
            // Nếu không chủ nhiệm lớp nào, trả về bảng rỗng
            if (classId <= 0) return new DataTable();

            string sql = "SELECT class_id, class_name FROM classes WHERE class_id = @param0";
            return DbConnect.ExecuteQuery(sql, new object[] { classId });
        }

        // 4. Lấy thông tin năm học hiện tại (để đổ vào ComboBox)
        public DataTable GetCurrentAcademicYear()
        {
            string sql = "SELECT year_id, name FROM academic_years WHERE @param0 BETWEEN start_date AND end_date";
            return DbConnect.ExecuteQuery(sql, new object[] { DateTime.Today });
        }
    }
}