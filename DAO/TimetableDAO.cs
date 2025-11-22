using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class TimetableDAO
    {
        private static TimetableDAO timetableDAO;
        public static TimetableDAO Instance
        {
            get { if (timetableDAO == null) timetableDAO = new TimetableDAO(); return timetableDAO; }
            private set { timetableDAO = value; }
        }

        public TimetableDAO() { }

        // Lấy thời khóa biểu theo ID Lớp và ID Học kỳ
        public List<DTO.TimetableDTO> GetTimetableByClass(int classId, int semesterId)
        {
            List<DTO.TimetableDTO> list = new List<DTO.TimetableDTO>();

            // Query join 3 bảng: timetable, subjects, users (để lấy tên GV)
            string query = @"
                SELECT 
                    s.name AS SubjectName, 
                    u.fullname AS TeacherName, 
                    t.room, 
                    t.day, 
                    t.period
                FROM timetable t
                JOIN subjects s ON t.subject_id = s.subject_id
                JOIN users u ON t.teacher_id = u.user_id
                WHERE t.class_id = @classId AND t.semester_id = @semesterId";

            DataTable data = DbConnect.ExecuteQuery(query, new object[] { classId, semesterId });

            foreach (DataRow row in data.Rows)
            {
                DTO.TimetableDTO item = new DTO.TimetableDTO();
                item.SubjectName = row["SubjectName"].ToString();
                item.TeacherName = row["TeacherName"].ToString();
                item.Room = row["room"].ToString();
                item.Day = row["day"].ToString(); 
                item.Period = (int)row["period"];

                list.Add(item);
            }

            return list;
        }
    }
}
