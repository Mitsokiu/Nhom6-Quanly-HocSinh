using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BUS
{
    public static class ClassBUS
    {
        // 1. Validate thông tin lớp
        private static void ValidateClass(ClassDTO c, bool isUpdate)
        {
            if (c.ClassName != null) c.ClassName = c.ClassName.Trim();
            if (string.IsNullOrWhiteSpace(c.ClassName)) throw new ArgumentException("Tên lớp không được để trống!");
            if (c.ClassName.Length > 50) throw new ArgumentException("Tên lớp quá dài!");

            // Check trùng tên
            List<ClassDTO> list = ClassDAO.GetAllClasses();
            bool exists = isUpdate
                ? list.Any(x => x.ClassName.Equals(c.ClassName, StringComparison.OrdinalIgnoreCase) && x.GradeId == c.GradeId && x.Id != c.Id)
                : list.Any(x => x.ClassName.Equals(c.ClassName, StringComparison.OrdinalIgnoreCase) && x.GradeId == c.GradeId);

            if (exists) throw new ArgumentException($"Lớp '{c.ClassName}' đã tồn tại trong khối này!");
        }

        // 2. Validate thông tin phân công
        private static void ValidateAssignment(int classId, int teacherId, int yearId)
        {
            // Bắt buộc chọn cả 2 hoặc không chọn gì cả
            if ((teacherId > 0 && yearId <= 0) || (teacherId <= 0 && yearId > 0))
                throw new ArgumentException("Vui lòng chọn đầy đủ Giáo viên và Năm học để phân công!");

            // Check GV bận: 1 GV không thể chủ nhiệm 2 lớp trong cùng 1 năm
            if (teacherId > 0 && yearId > 0)
            {
                List<ClassDTO> list = ClassDAO.GetAllClasses();
                var busy = list.FirstOrDefault(x => x.TeacherId == teacherId && x.YearId == yearId && x.Id != classId);
                if (busy != null)
                    throw new ArgumentException($"Giáo viên này đang chủ nhiệm lớp {busy.ClassName} trong năm học đã chọn!");
            }
        }

        // 3. Thêm lớp + Phân công
        public static void AddClass(ClassDTO c, int teacherId, int yearId)
        {
            ValidateClass(c, false);
            ValidateAssignment(0, teacherId, yearId);

            // Gọi DAO thêm lớp
            int newId = ClassDAO.AddClassReturnId(c);

            // Gọi BUS Phân công (của bạn) thêm phân công
            if (teacherId > 0 && yearId > 0)
            {
                var assign = new HomeroomAssignmentDTO { ClassId = newId, TeacherId = teacherId, YearId = yearId, AssignedDate = DateTime.Now };
                HomeroomAssignmentBUS.AddAssignment(assign);
            }
        }

        // 4. Sửa lớp + Phân công
        public static void UpdateClass(ClassDTO c, int teacherId, int yearId, int assignId)
        {
            ValidateClass(c, true);
            ValidateAssignment(c.Id, teacherId, yearId);

            ClassDAO.UpdateClass(c);

            if (teacherId > 0 && yearId > 0)
            {
                var assign = new HomeroomAssignmentDTO { AssignId = assignId, ClassId = c.Id, TeacherId = teacherId, YearId = yearId, AssignedDate = DateTime.Now };

                if (assignId > 0) HomeroomAssignmentBUS.UpdateAssignment(assign); // Update nếu đã có
                else HomeroomAssignmentBUS.AddAssignment(assign); // Add nếu chưa có
            }
        }

        public static void DeleteClass(int id) => ClassDAO.DeleteClass(id);
        public static List<ClassDTO> GetAllClasses() => ClassDAO.GetAllClasses();

        // Pass-through calls cho ComboBox
        public static List<ComboItemDTO> GetListTeachers() => ClassDAO.GetListTeachers();
        public static List<ComboItemDTO> GetListYears() => ClassDAO.GetListYears();
    }
}