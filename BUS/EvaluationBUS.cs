using DAO;
using DTO;
using System;
using System.Collections.Generic;

namespace BUS
{
    public class EvaluationBUS
    {
        private EvaluationDAO dao = new EvaluationDAO();

        public List<StudentEvaluationDTO> GetClassList(int teacherId, int semesterId)
        {
            return dao.GetListForEvaluation(teacherId, semesterId);
        }

        public bool SaveEvaluation(int studentId, int classId, int semesterId, string conduct, string comment)
        {
            return dao.SaveEvaluation(studentId, classId, semesterId, conduct, comment);
        }

        public string GetLockStatus(int semesterId)
        {
            var duration = dao.GetSemesterDuration(semesterId);
            if (duration == null) return "Unknown";

            DateTime now = DateTime.Now;
            DateTime deadline = duration.EndDate.AddDays(7);

            if (now < duration.StartDate)
            {
                return "Future";
            }

            if (now > deadline)
            {
                return "Past";
            }

            return "Open";
        }

        public bool IsEvaluationLocked(int semesterId)
        {
            string status = GetLockStatus(semesterId);
            return status != "Open";
        }
    }
}