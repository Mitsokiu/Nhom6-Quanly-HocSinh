using DAO;
using DTO;
using System;

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

    }
}
