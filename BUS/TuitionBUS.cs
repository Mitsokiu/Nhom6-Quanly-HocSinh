using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class TuitionBUS
    {
        private TuitionDAO tuitionDAO = new TuitionDAO();
        private StudentDAO studentDAO = new StudentDAO();

        public List<TuitionDTO> GetTuitionByUser(int userID, int semesterID)
        {
            // 1. Từ UserID -> Tìm ra studentID
            int studentID = studentDAO.GetStudentIdByUserId(userID);    
            if (studentID == -1)
                return new List<TuitionDTO>(); // Trả về danh sách rỗng nếu không tìm thấy studentID
            
            // 2. Gọi DAO để lấy danh sách học phí
            return tuitionDAO.GetTuitionByStudentAndSemester(studentID, semesterID);
        }
    }
}
