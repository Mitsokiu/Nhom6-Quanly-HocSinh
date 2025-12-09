using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
   public class ScoreBUS
    {
        private ScoreDAO dao = new ScoreDAO();
        private StudentDAO studentDAO = new StudentDAO();
        private ScoreDAO scoreDAO = new ScoreDAO();
        public List<SubjectScoreDTO> GetScoresData(int userId, int semesterId)
        {
            int studentId = studentDAO.GetStudentIdByUserId(userId);
            if (studentId == -1) return new List<SubjectScoreDTO>();

            DataTable rawData = scoreDAO.GetRawScoreData(studentId, semesterId);

            List<SubjectScoreDTO> diemHS = new List<SubjectScoreDTO>();
            var groupedData = rawData.AsEnumerable().GroupBy(row => row.Field<string>("SubjectName"));

            foreach (var group in groupedData)
            {
                SubjectScoreDTO subjectScoreDTO = new SubjectScoreDTO();
                subjectScoreDTO.SubjectName = group.Key;

                foreach (var row in group)
                {
                    string type = row["score_type"].ToString();
                    float val = Convert.ToSingle(row["score_value"]);

                    if (type == "oral") subjectScoreDTO.OralScore = val;
                    else if (type == "quiz15") subjectScoreDTO.FifteenMinScore = val;
                    else if (type == "quiz45" || type == "midterm") subjectScoreDTO.OnePeriodScore = val;
                    else if (type == "final") subjectScoreDTO.FinalScore = val;
                }

                subjectScoreDTO.AverageScore = CalculateAverage(subjectScoreDTO);

                diemHS.Add(subjectScoreDTO);
            }
            return diemHS;
        }

        public List<ScoreDTO> GetScoresByAssignment(int assignId)
        {
            DataTable dt = dao.GetScoresDataTable(assignId);

            List<ScoreDTO> scores = new List<ScoreDTO>();
            foreach (DataRow row in dt.Rows)
            {
                scores.Add(new ScoreDTO
                {
                    StudentId = Convert.ToInt32(row["student_id"]),
                    StudentName = row["StudentName"].ToString(),
                    ClassName = row["ClassName"].ToString(),

                    ScoreType = row["ScoreType"]?.ToString(),
                    ScoreValue = row["ScoreValue"] != DBNull.Value ? (float?)Convert.ToSingle(row["ScoreValue"]) : null
                });
            }
            return scores;
        }

        public void UpdateScore(int studentId, int assignId, string scoreType, float scoreValue)
        {
            dao.UpsertScore(studentId, assignId, scoreType, scoreValue);
        }

        private float? CalculateAverage(SubjectScoreDTO diem)
        {
            float tongDiem = 0;
            int tongHeSo = 0;

            if (diem.OralScore.HasValue)
            {
                tongDiem += diem.OralScore.Value * 1;
                tongHeSo += 1;
            }
            if (diem.FifteenMinScore.HasValue)
            {
                tongDiem += diem.FifteenMinScore.Value * 1;
                tongHeSo += 1;
            }
            if (diem.OnePeriodScore.HasValue)
            {
                tongDiem += diem.OnePeriodScore.Value * 2;
                tongHeSo += 2;
            }
            if (diem.FinalScore.HasValue)
            {
                tongDiem += diem.FinalScore.Value * 3;
                tongHeSo += 3;
            }

            if (tongHeSo == 0) return null;

            return (float)Math.Round(tongDiem / tongHeSo, 1);
        }
    }
}
