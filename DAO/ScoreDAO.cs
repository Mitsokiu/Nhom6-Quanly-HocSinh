using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAO
{
    public class ScoreDAO
    {

        public DataTable GetScoresDataTable(int assignId)
        {
            string query = @"
        SELECT 
            sc.score_id,                 -- Thêm cột score_id
            s.student_id,
            u.fullname AS StudentName,
            c.class_name AS ClassName,
            sc.score_type AS ScoreType,
            sc.score_value AS ScoreValue
        FROM student_class sclass
        INNER JOIN students s ON sclass.student_id = s.student_id
        INNER JOIN users u ON s.user_id = u.user_id
        INNER JOIN classes c ON sclass.class_id = c.class_id
        LEFT JOIN scores sc 
            ON s.student_id = sc.student_id 
           AND sc.assign_id = @param0
        WHERE sclass.class_id = (SELECT class_id FROM teacher_assignments WHERE assign_id = @param0)
        ORDER BY c.class_name, u.fullname, sc.score_type;
    ";

            object[] parameters = new object[] { assignId };
            return DbConnect.ExecuteQuery(query, parameters);
        }

        public void UpsertScore(int studentId, int assignId, string scoreType, float scoreValue)
        {
            string query = @"
        INSERT INTO scores(student_id, assign_id, score_type, score_value)
        VALUES (?, ?, ?, ?)
        ON DUPLICATE KEY UPDATE score_value = ?;
    ";

            object[] parameters = new object[]
            {
        studentId,
        assignId,
        scoreType,
        scoreValue,
        scoreValue   // cho ON DUPLICATE KEY UPDATE
            };

            DbConnect.ExecuteNonQuery(query, parameters);
        }



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
