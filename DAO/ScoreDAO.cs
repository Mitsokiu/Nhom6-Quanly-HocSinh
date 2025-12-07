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

        public DataTable GetScoresByAssignId(int assignId)
        {
            string query = "SELECT student_id, score_type, score_value FROM scores WHERE assign_id = @param0";
            return DbConnect.ExecuteQuery(query, new object[] { assignId });
        }

        public bool AddOrUpdateScore(ScoreDTO s)
        {
            string checkQuery = "SELECT COUNT(*) FROM scores WHERE student_id=@param0 AND assign_id=@param1 AND score_type=@param2";
            object result = DbConnect.ExecuteScalar(checkQuery, new object[] { s.StudentId, s.AssignId, s.ScoreType });

            int count = (result != null) ? Convert.ToInt32(result) : 0;

            if (count > 0)
            {
                string updateQuery = "UPDATE scores SET score_value=@param0 WHERE student_id=@param1 AND assign_id=@param2 AND score_type=@param3";
                return DbConnect.ExecuteNonQuery(updateQuery, new object[] { s.ScoreValue, s.StudentId, s.AssignId, s.ScoreType }) > 0;
            }
            else
            {
                string insertQuery = "INSERT INTO scores (student_id, assign_id, score_type, score_value) VALUES (@param0, @param1, @param2, @param3)";
                return DbConnect.ExecuteNonQuery(insertQuery, new object[] { s.StudentId, s.AssignId, s.ScoreType, s.ScoreValue }) > 0;
            }
        }
    }
}