using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAO
{
    public class SemesterDAO
    {
        private static SemesterDAO instance;
        public static SemesterDAO Instance
        {
            get { if (instance == null) instance = new SemesterDAO(); return instance; }
        }
        private SemesterDAO() { }

        public List<SemesterDTO> GetAllSemesters()
        {
            List<SemesterDTO> list = new List<SemesterDTO>();
            string query = "SELECT semester_id, name, year_id FROM semesters ORDER BY start_date DESC";

            DataTable data = DbConnect.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                list.Add(new SemesterDTO
                {
                    SemesterId = (int)row["semester_id"],
                    SemesterName = row["name"].ToString(),
                    YearId = (int)row["year_id"]
                });
            }
            return list;
        }

        public static bool AddSemester(int yearId, string name, DateTime startDate, DateTime endDate)
        {
            string query = "INSERT INTO semesters (year_id, name, start_date, end_date) VALUES (@param0, @param1, @param2, @param3)";
            int result = DbConnect.ExecuteNonQuery(query, new object[] { yearId, name, startDate, endDate });
            return result > 0;
        }

    }
}
