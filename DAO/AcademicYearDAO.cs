using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAO
{
    public class AcademicYearDAO
    {
        public static List<AcademicYearDTO> GetAllYears()
        {
            List<AcademicYearDTO> list = new List<AcademicYearDTO>();
            string query = "SELECT year_id, name, start_date, end_date FROM academic_years";
            DataTable dt = DbConnect.ExecuteQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                var year = new AcademicYearDTO
                {
                    YearId = Convert.ToInt32(row["year_id"]),
                    Name = row["name"].ToString(),
                    StartDate = Convert.ToDateTime(row["start_date"]),
                    EndDate = Convert.ToDateTime(row["end_date"])
                };
                list.Add(year);
            }

            return list;
        }

        public static bool AddYear(AcademicYearDTO year)
        {
            string query = "INSERT INTO academic_years (name, start_date, end_date) VALUES (@param0, @param1, @param2)";
            int result = DbConnect.ExecuteNonQuery(query, new object[] { year.Name, year.StartDate, year.EndDate });
            return result > 0;
        }
       


        public static bool UpdateYear(AcademicYearDTO year)
        {
            string query = "UPDATE academic_years SET name=@param0, start_date=@param1, end_date=@param2 WHERE year_id=@param3";
            int result = DbConnect.ExecuteNonQuery(query, new object[] { year.Name, year.StartDate, year.EndDate, year.YearId });
            return result > 0;
        }

        public static bool DeleteYear(int yearId)
        {
            string query = "DELETE FROM academic_years WHERE year_id=@param0";
            int result = DbConnect.ExecuteNonQuery(query, new object[] { yearId });
            return result > 0;
        }
    }
}
