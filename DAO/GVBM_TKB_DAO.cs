using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAO
{
    public class GVBM_TKB_DAO
    {
        private DbConnect db = new DbConnect();


        // Lấy TKB theo teacherID và semesterID
        public List<GVBM_TKB_DTO> GetTimetableByTeacher(int teacherID, int semesterID)
        {
            string query = @"
        SELECT 
            t.period AS Period,
            t.day AS Day,
            c.class_name AS ClassName,
            t.room AS Room
        FROM timetable t
        JOIN classes c ON t.class_id = c.class_id
        WHERE t.teacher_id = @param0 
          AND t.semester_id = @param1
        ORDER BY FIELD(t.day,'Mon','Tue','Wed','Thu','Fri','Sat'), t.period
    ";

            DataTable data = DbConnect.ExecuteQuery(query, new object[] { teacherID, semesterID });

            List<GVBM_TKB_DTO> list = new List<GVBM_TKB_DTO>();
            foreach (DataRow row in data.Rows)
            {
                list.Add(new GVBM_TKB_DTO
                {
                    Period = Convert.ToInt32(row["Period"]),
                    Day = row["Day"].ToString(),
                    ClassName = row["ClassName"].ToString(),
                    Room = row["Room"].ToString()
                });
            }
            return list;
        }

    }
}
