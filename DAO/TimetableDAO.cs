using System;
using System.Collections.Generic;
using System.Data;

namespace DAO
{
    public class TimetableDAO
    {
        private static TimetableDAO instance;

        public static TimetableDAO Instance
        {
            get { if (instance == null) instance = new TimetableDAO(); return instance; }
            private set { instance = value; }
        }

        private TimetableDAO() { }

        // Lấy thời khóa biểu theo ID Lớp và ID Học kỳ
        public List<DTO.TimetableDTO> GetTimetableByClass(int classId, int semesterId)
        {
            List<DTO.TimetableDTO> list = new List<DTO.TimetableDTO>();

            // --- SỬA LỖI TẠI ĐÂY ---
            // DbConnect.ExecuteQuery tự động đặt tên tham số là @param0, @param1 theo thứ tự mảng truyền vào.
            // Vì vậy ta phải đổi @classId -> @param0, @semesterId -> @param1

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
                WHERE t.class_id = @param0 AND t.semester_id = @param1";

            // Truyền tham số: classId (là @param0), semesterId (là @param1)
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