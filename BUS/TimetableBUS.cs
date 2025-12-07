using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace BUS
{
    /// <summary>
    /// TimetableBUS - lớp trung gian giữa GUI và DAO.
    /// Phiên bản chuẩn hoá, kiểm tra tham số trước khi gọi DAO.
    /// </summary>
    public class TimetableBUS
    {
        private TimetableDAO dao = new TimetableDAO();


    public List<TimetableDTO> GetTimetableByClass(int classID, int semesterID)
        {
            if (classID <= 0 || semesterID <= 0) return new List<TimetableDTO>();
            return dao.GetTimetableByClass(classID, semesterID);
        }

        // Trả về toàn bộ TKB cho 1 học kỳ (không phân năm)
        public static DataTable GetTimetable(int semesterId)
        {
            if (semesterId <= 0) return new DataTable();
            return TimetableDAO.GetTimetable(semesterId);
        }

        public static bool Insert(TimetableDTO dto)
        {
            if (dto == null) return false;
            return TimetableDAO.Insert(dto);
        }

        public static bool Update(TimetableDTO dto)
        {
            if (dto == null) return false;
            return TimetableDAO.Update(dto);
        }

        public static bool Delete(int id)
        {
            if (id <= 0) return false;
            return TimetableDAO.Delete(id);
        }

        public static bool IsClassBusy(int classId, int semesterId, string day, int period)
        {
            if (classId <= 0 || semesterId <= 0 || string.IsNullOrEmpty(day) || period <= 0) return false;
            return TimetableDAO.IsClassBusy(classId, semesterId, day, period);
        }

        public static bool IsTeacherBusy(int teacherId, int semesterId, string day, int period)
        {
            if (teacherId <= 0 || semesterId <= 0 || string.IsNullOrEmpty(day) || period <= 0) return false;
            return TimetableDAO.IsTeacherBusy(teacherId, semesterId, day, period);
        }

        /// <summary>
        /// Tạo nhanh (mỗi phân công 1 dòng) — giữ tương thích với code cũ.
        /// Trả về số row affected (int).
        /// </summary>
        public int GenerateTimetableFromAssignment(int yearId, int semesterId)
        {
            if (yearId <= 0 || semesterId <= 0) return 0;
            return dao.GenerateTimetableFromAssignment(yearId, semesterId);
        }

        /// <summary>
        /// Tạo thời khoá biểu đầy đủ, phân bổ tiết theo phân công, tránh trùng lớp/GV.
        /// Đây là hàm chính nên GUI nên gọi hàm này để có TKB "đúng".
        /// </summary>
        public void CreateTimetable(int yearId, int semesterId)
        {
            if (yearId <= 0 || semesterId <= 0)
                throw new ArgumentException("Vui lòng chọn Năm học và Học kỳ hợp lệ trước khi tạo TKB.");

            // Mặc định room = "A1", periodMax = 7 (có thể sửa)
            dao.CreateTimetable(yearId, semesterId, "A1", 7, new string[] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" });
        }

        /// <summary>
        /// Lấy TKB theo năm + học kỳ (dùng để load vào DataGridView hiển thị).
        /// </summary>
        public DataTable GetTimetableForSemester(int yearId, int semesterId)
        {
            if (yearId <= 0 || semesterId <= 0) return new DataTable();
            return dao.GetTimetableByYearSemester(yearId, semesterId);
        }







        public DataTable GetTimetableByTeacherAndSemester(int teacherId, int semesterId)
        {
            TimetableDAO dao = new TimetableDAO();
            return dao.GetTimetableByTeacherAndSemester(teacherId, semesterId);
        }


        public static void CreateTimetableFromGrid(DataGridView grid)
        {
            // Xóa dữ liệu cũ
            TimetableDAO.DeleteAllTimetable();

            foreach (DataGridViewRow row in grid.Rows)
            {
                if (row.IsNewRow) continue;

                int classId = Convert.ToInt32(row.Cells["class_id"].Value);
                int subjectId = Convert.ToInt32(row.Cells["subject_id"].Value);
                int teacherId = Convert.ToInt32(row.Cells["teacher_id"].Value);
                int semesterId = Convert.ToInt32(row.Cells["semester_id"].Value);
                int periods = Convert.ToInt32(row.Cells["periods"].Value);

                for (int i = 1; i <= periods; i++)
                {
                    string day = GetDayByIndex(i);
                    TimetableDAO.AddTimetable(classId, subjectId, teacherId, semesterId, day, i);
                }
            }
        }

        private static string GetDayByIndex(int index)
        {
            string[] days = { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
            return days[(index - 1) % days.Length];
        }


    }


}
