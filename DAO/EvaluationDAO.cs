using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAO
{
    public class EvaluationDAO
    {
        public List<StudentEvaluationDTO> GetListForEvaluation(int teacherId, int semesterId)
        {
            List<StudentEvaluationDTO> list = new List<StudentEvaluationDTO>();



            string query = @"
                SELECT 
                    s.student_id,
                    CONCAT('HS', LPAD(s.student_id, 3, '0')) AS StudentCode,
                    u_student.fullname AS FullName,
                    
                    IFNULL(eval.conduct, 'Tốt') AS Conduct, 
                    
                    IFNULL(eval.teacher_comment, '') AS TeacherComment, c.class_id,

                    CASE WHEN eval.student_id IS NOT NULL THEN 1 ELSE 0 END AS IsSaved
                FROM homeroom_assignments ha
                
                JOIN semesters sem ON sem.semester_id = @param0 
                                   AND ha.year_id = sem.year_id
                
                JOIN classes c ON ha.class_id = c.class_id
                
                JOIN student_class sc ON sc.class_id = c.class_id 
                                      AND sc.school_year_id = sem.year_id
                JOIN students s ON sc.student_id = s.student_id
                JOIN users u_student ON s.user_id = u_student.user_id
                
                LEFT JOIN student_evaluations eval ON eval.student_id = s.student_id 
                                                  AND eval.semester_id = @param0
                                                  AND eval.class_id = c.class_id
                                                  
                WHERE ha.teacher_id = @param1
                ORDER BY SUBSTRING_INDEX(u_student.fullname, ' ', -1) ASC";

            DataTable dt = DbConnect.ExecuteQuery(query, new object[] { semesterId, teacherId });

            foreach (DataRow row in dt.Rows)
            {
                StudentEvaluationDTO dto = new StudentEvaluationDTO();

                dto.StudentId = Convert.ToInt32(row["student_id"]);
                dto.StudentCode = row["StudentCode"].ToString();
                dto.FullName = row["FullName"].ToString();

                dto.Conduct = row["Conduct"].ToString();
                dto.TeacherComment = row["TeacherComment"].ToString();

                dto.ClassId = Convert.ToInt32(row["class_id"]);
                dto.IsSaved = Convert.ToInt32(row["IsSaved"]) == 1;

                list.Add(dto);
            }

            return list;
        }

        public bool SaveEvaluation(int studentId, int classId, int semesterId, string conduct, string comment)
        {
            string query = @"
                INSERT INTO student_evaluations (student_id, class_id, semester_id, conduct, teacher_comment)
                VALUES (@param0, @param1, @param2, @param3, @param4)
                ON DUPLICATE KEY UPDATE 
                    conduct = @param3, 
                    teacher_comment = @param4";

            return DbConnect.ExecuteNonQuery(query, new object[] { studentId, classId, semesterId, conduct, comment }) > 0;
        }

        public SemesterDurationDTO GetSemesterDuration(int semesterId)
        {
            string query = "SELECT start_date, end_date FROM semesters WHERE semester_id = @param0";
            DataTable dt = DbConnect.ExecuteQuery(query, new object[] { semesterId });

            if (dt.Rows.Count > 0)
            {
                return new SemesterDurationDTO
                {
                    StartDate = Convert.ToDateTime(dt.Rows[0]["start_date"]),
                    EndDate = Convert.ToDateTime(dt.Rows[0]["end_date"])
                };
            }
            return null;
        }
    }
}