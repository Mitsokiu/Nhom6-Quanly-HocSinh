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

        // [CŨ - Giữ lại nếu muốn dùng cho cách Lưu tất cả]
        public bool SaveEvaluation(StudentEvaluationDTO dto, int semesterId)
        {
            return dao.SaveEvaluation(dto.StudentId, dto.ClassId, semesterId, dto.Conduct, dto.TeacherComment);
        }

        // [MỚI - THÊM HÀM NÀY] Để phục vụ cho Form Sửa Chi Tiết (FormXetHanhKiem)
        public bool SaveEvaluation(int studentId, int classId, int semesterId, string conduct, string comment)
        {
            // Gọi thẳng xuống DAO
            return dao.SaveEvaluation(studentId, classId, semesterId, conduct, comment);
        }

        public bool IsEvaluationLocked(int semesterId)
        {
            DateTime endDate = dao.GetSemesterEndDate(semesterId);
            DateTime deadline = endDate.AddDays(7);

            if (DateTime.Now > deadline)
            {
                return true;
            }
            return false;
        }
    }
}