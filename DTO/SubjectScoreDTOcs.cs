using System;

namespace DTO
{
    public class SubjectScoreDTO
    {
        public string SubjectName { get; set; }
        public float? OralScore { get; set; }
        public float? FifteenMinScore { get; set; }
        public float? OnePeriodScore { get; set; }
        public float? FinalScore { get; set; }
        public float? AverageScore { get; set; }
    }
}