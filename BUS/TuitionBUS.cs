using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace BUS
{
    public class TuitionBUS
    {
        private TuitionDAO dao = new TuitionDAO();

        public List<TuitionDTO> GetAllTuition()
        {
            return dao.GetAllTuition();
        }
        public List<TuitionDTO> GetAllTuitionKhoanThu()
        {
            return dao.GetAllTuitionKhoanThu();
        }

        public bool AddTuitionForAllStudents(string description, decimal amount, DateTime dueDate)
        {
            TuitionDTO tuition = new TuitionDTO { Description = description, Amount = amount, DueDate = dueDate };
            return dao.AddTuitionForAllStudents(tuition);
        }

        //public bool UpdateTuition(int tuitionId, string description, decimal amount, DateTime dueDate)
        //{
        //    TuitionDTO tuition = new TuitionDTO { TuitionId = tuitionId, Description = description, Amount = amount, DueDate = dueDate };
        //    return dao.UpdateTuition(tuition);
        //}

        //public bool DeleteTuition(int tuitionId)
        //{
        //    return dao.DeleteTuition(tuitionId);
        //}
        // Cập nhật tất cả học sinh có cùng khoản học phí
        public bool UpdateTuition(string oldDesc, decimal oldAmount, DateTime oldDueDate,
                               string newDesc, decimal newAmount, DateTime newDueDate)
        {
            return dao.UpdateTuition(oldDesc, oldAmount, oldDueDate, newDesc, newAmount, newDueDate);
        }

        // Xóa tất cả học sinh có cùng khoản học phí
        public bool DeleteTuition(string description, decimal amount, DateTime dueDate)
        {
            TuitionDTO t = new TuitionDTO
            {
                Description = description,
                Amount = amount,
                DueDate = dueDate
            };
            return dao.DeleteTuition(t);
        }

        public List<TuitionDTO> GetAllTuitionWithStudentInfo(int schoolYearId)
        {
            return dao.GetTuitionWithStudentInfo(schoolYearId);
        }

        // Cập nhật trạng thái học phí (paid/unpaid)
        public bool UpdateTuitionStatus(int tuitionId, string newStatus, DateTime? paidDate)
        {
            return dao.UpdateTuitionStatus(tuitionId, newStatus, paidDate);
        }

        public DataTable GetTuitionByYearAndClass(int yearId, int classId) => dao.GetTuitionByYearAndClass(yearId, classId);
        public bool UpdateStatus(int tuitionId, string status) => dao.UpdateStatus(tuitionId, status);


    }
}
