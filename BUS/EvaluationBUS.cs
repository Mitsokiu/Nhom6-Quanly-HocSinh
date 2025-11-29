using DAO;
using DTO;
using System;
using System.Collections.Generic;

namespace BUS
{
    public class EvaluationBUS
    {
        private EvaluationDAO dao = new EvaluationDAO();

        // Lấy danh sách (Gọi từ GUI)
        public List<StudentEvaluationDTO> GetClassList(int teacherId, int semesterId)
        {
            return dao.GetListForEvaluation(teacherId, semesterId);
        }

        // Lưu đánh giá (Gọi từ GUI khi bấm nút Lưu)
        public bool SaveEvaluation(StudentEvaluationDTO dto, int semesterId)
        {
            // Gọi xuống DAO để lưu từng dòng
            return dao.SaveEvaluation(dto.StudentId, dto.ClassId, semesterId, dto.Conduct, dto.TeacherComment);
        }

        // Kiểm tra xem Học kỳ này đã "Khóa sổ" chưa
        public bool IsEvaluationLocked(int semesterId)
        {
            DateTime endDate = dao.GetSemesterEndDate(semesterId);

            // Logic: Cho phép sửa thêm 7 ngày sau khi học kỳ kết thúc
            // Ví dụ: Học kỳ hết thúc 31/12, thì đến 07/01 vẫn sửa được. Qua ngày đó thì khóa.
            DateTime deadline = endDate.AddDays(7);

            if (DateTime.Now > deadline)
            {
                return true; // Đã quá hạn -> KHÓA
            }
            return false; // Còn hạn -> MỞ
        }
    }
}