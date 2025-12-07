using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAO
{
    public class SemesterDAO
    {
        public static bool AddSemester(int yearId, string name, DateTime startDate, DateTime endDate)
        {
            string query = "INSERT INTO semesters (year_id, name, start_date, end_date) VALUES (@param0, @param1, @param2, @param3)";
            int result = DbConnect.ExecuteNonQuery(query, new object[] { yearId, name, startDate, endDate });
            return result > 0;
        }

        public List<SemesterDTO> GetAllSemesters()
        {
            List<SemesterDTO> list = new List<SemesterDTO>();
            string query = @"
                SELECT s.semester_id, s.name, s.year_id, s.start_date, s.end_date, 
                       y.name AS YearName 
                FROM semesters s
                JOIN academic_years y ON s.year_id = y.year_id
                ORDER BY s.start_date DESC";

            DataTable data = DbConnect.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                list.Add(new SemesterDTO
                {
                    SemesterId = (int)row["semester_id"],
                    SemesterName = row["name"].ToString(),
                    YearId = (int)row["year_id"],

                    YearName = row["YearName"].ToString(),

                    StartDate = Convert.ToDateTime(row["start_date"]),
                    EndDate = Convert.ToDateTime(row["end_date"])
                });
            }
            return list;
        }

        public List<SemesterDTO> GetSemestersByYearId(int yearId)
        {
            List<SemesterDTO> list = new List<SemesterDTO>();

            string query = $@"
        SELECT s.semester_id, s.name, s.year_id, s.start_date, s.end_date,
               y.name AS YearName
        FROM semesters s
        JOIN academic_years y ON s.year_id = y.year_id
        WHERE s.year_id = {yearId}
        ORDER BY s.start_date DESC";

            DataTable data = DbConnect.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                list.Add(new SemesterDTO
                {
                    SemesterId = (int)row["semester_id"],
                    SemesterName = row["name"].ToString(),
                    YearId = (int)row["year_id"],
                    YearName = row["YearName"].ToString(),
                    StartDate = Convert.ToDateTime(row["start_date"]),
                    EndDate = Convert.ToDateTime(row["end_date"])
                });
            }

            return list;
        }




    }
}
