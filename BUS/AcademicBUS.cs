using DAO;
using DTO;
using System;
using System.Collections.Generic;

namespace BUS
{
    public class AcademicYearBUS
    {
        public static List<AcademicYearDTO> GetAllYears() => AcademicYearDAO.GetAllYears();

       
        public static bool AddYear(AcademicYearDTO year)
        {
            if (year.StartDate > year.EndDate)
                return false;

            // Thêm năm học
            bool success = AcademicYearDAO.AddYear(year);
            if (!success) return false;

            // Lấy id năm học vừa thêm
            var list = AcademicYearDAO.GetAllYears();
            int newYearId = list[list.Count - 1].YearId; // giả sử id lớn nhất là mới thêm

            // Chia làm 2 học kỳ
            TimeSpan totalDays = year.EndDate - year.StartDate;
            int halfDays = totalDays.Days / 2;

            DateTime midDate = year.StartDate.AddDays(halfDays);

            // Học kỳ 1
            SemesterDAO.AddSemester(newYearId,"HK1", year.StartDate, midDate);

            // Học kỳ 2
            SemesterDAO.AddSemester(newYearId,"HK2" ,midDate.AddDays(1), year.EndDate);

            return true;
        }

        public static bool UpdateYear(AcademicYearDTO year)
        {
            if (year.StartDate > year.EndDate) return false;
            return AcademicYearDAO.UpdateYear(year);
        }

        public static bool DeleteYear(int yearId) => AcademicYearDAO.DeleteYear(yearId);
    }
}
