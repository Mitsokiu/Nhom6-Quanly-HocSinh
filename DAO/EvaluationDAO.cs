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
                    
                    -- Nếu chưa chấm thì mặc định là 'Tốt', đã chấm thì lấy giá trị cũ
                    IFNULL(eval.conduct, 'Tốt') AS Conduct, 
                    
                    -- Nếu chưa nhận xét thì để trống
                    IFNULL(eval.teacher_comment, '') AS TeacherComment,
                    
                    c.class_id
                
                FROM homeroom_assignments ha
                
                -- 1. Xác định Năm học từ Học kỳ
                JOIN semesters sem ON sem.semester_id = @param0 
                                   AND ha.year_id = sem.year_id
                
                -- 2. Tìm lớp chủ nhiệm
                JOIN classes c ON ha.class_id = c.class_id
                
                -- 3. Tìm học sinh trong lớp đó (đúng năm học)
                JOIN student_class sc ON sc.class_id = c.class_id 
                                      AND sc.school_year_id = sem.year_id
                JOIN students s ON sc.student_id = s.student_id
                JOIN users u_student ON s.user_id = u_student.user_id
                
                -- 4. Lấy kết quả đánh giá cũ (nếu có)
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

        public DateTime GetSemesterEndDate(int semesterId)
        {
            string query = "SELECT end_date FROM semesters WHERE semester_id = @param0";
            object result = DbConnect.ExecuteScalar(query, new object[] { semesterId });
            if (result != null && result != DBNull.Value)
            {
                return Convert.ToDateTime(result);
            }
            return DateTime.MinValue;
        }
    }
}