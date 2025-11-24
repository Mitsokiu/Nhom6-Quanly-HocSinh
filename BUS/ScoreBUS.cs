using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ScoreBUS
    {
        private ScoreDAO scoreDAO = new ScoreDAO();
        private StudentDAO studentDAO = new StudentDAO();
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

                // Lấy các đầu điểm (Parse dữ liệu từ SQL)
                foreach (var row in group)
                {
                    string type = row["score_type"].ToString();
                    float val = Convert.ToSingle(row["score_value"]);

                    if (type == "oral") subjectScoreDTO.OralScore = val;
                    else if (type == "quiz15") subjectScoreDTO.FifteenMinScore = val;
                    else if (type == "quiz45" || type == "midterm") subjectScoreDTO.OnePeriodScore = val;
                    else if (type == "final") subjectScoreDTO.FinalScore = val;
                }

                // 4. Tính Điểm Trung Bình
                subjectScoreDTO.AverageScore = CalculateAverage(subjectScoreDTO);

                diemHS.Add(subjectScoreDTO);
            }
            return diemHS;
        }

        private float? CalculateAverage(SubjectScoreDTO s)
        {
            float total = 0;
            int coeffSum = 0;

            if (s.OralScore.HasValue) { total += s.OralScore.Value * 1; coeffSum += 1; }
            if (s.FifteenMinScore.HasValue) { total += s.FifteenMinScore.Value * 1; coeffSum += 1; }
            if (s.OnePeriodScore.HasValue) { total += s.OnePeriodScore.Value * 2; coeffSum += 2; }
            if (s.FinalScore.HasValue) { total += s.FinalScore.Value * 3; coeffSum += 3; }

            if (coeffSum == 0) return null;
            return (float)Math.Round(total / coeffSum, 1);
        }

    }
}
