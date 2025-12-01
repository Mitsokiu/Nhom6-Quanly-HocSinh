using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAO
{
    public class TimetableDAO
    {
        private DbConnect db = new DbConnect();

        public List<TimetableDTO> GetTimetableByClass(int classID, int semesterID)
        {
            List<TimetableDTO> list = new List<TimetableDTO>();
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
            DataTable data = DbConnect.ExecuteQuery(query, new object[] { classID, semesterID });
            foreach (DataRow row in data.Rows)
            {
                list.Add(new TimetableDTO
                {
                    SubjectName = row["SubjectName"].ToString(),
                    TeacherName = row["TeacherName"].ToString(),
                    Room = row["room"].ToString(),
                    Day = row["day"].ToString(),
                    Period = (int)row["period"]
                });
            }
            return list;
        }
    }
}