using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace BUS
{
    public class AttendanceBUS
    {
        private AttendanceDAO dao = new AttendanceDAO();

        public List<AttendanceDTO> GetAttendanceList(int teacherId, DateTime date, int semesterId)
        {
            return dao.GetAttendanceList(teacherId, date, semesterId);
        }

        public bool SaveAttendance(int studentId, int classId, DateTime date, string status, string note)
        {
            return dao.SaveAttendance(studentId, classId, date, status, note);
        }

        public string GetClassName(int teacherId, int semesterId)
        {
            return dao.GetClassName(teacherId, semesterId);
        }

        public System.Data.DataTable GetStudentHistory(int studentId)
        {
            return dao.GetStudentHistory(studentId);
        }

        public bool DeleteAttendance(int studentId, DateTime date)
        {
            return dao.DeleteAttendance(studentId, date);
        }

        public DataTable GetDailyAbsenceList(int teacherId, int semesterId, DateTime date)
        {
            return dao.GetDailyAbsenceList(teacherId, semesterId, date);
        }

        public bool IsAttendanceLocked(DateTime date)
        {
            if (date.Date > DateTime.Now.Date) return true;

            TimeSpan difference = DateTime.Now.Date - date.Date;
            if (difference.TotalDays > 7)
            {
                return true;
            }

            return false;
        }
    }
}