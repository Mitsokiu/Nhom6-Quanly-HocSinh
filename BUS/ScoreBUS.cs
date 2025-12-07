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
                    else if (type == "ave") subjectScoreDTO.AverageScore = val;
                }

            

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
       
    }
}
