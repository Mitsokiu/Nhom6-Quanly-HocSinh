using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAO
{
    public class ScoreDAO
    {
        public DataTable GetRawScoreData(int studentId, int semesterId)
        {
            string query = @"SELECT sub.name AS SubjectName,
                                    sc.score_type,
                                    sc.score_value
                             FROM scores sc
                             JOIN teacher_assignments ta ON sc.assign_id = ta.assign_id
                             JOIN subjects sub ON ta.subject_id = sub.subject_id
                             WHERE sc.student_id = @param0
                             AND ta.semester_id = @param1";
            return DbConnect.ExecuteQuery(query, new object[] { studentId, semesterId });
        }
    }
}