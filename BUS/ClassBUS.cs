using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BUS
{
    public static class ClassBUS
    {
        // Cập nhật hàm Validate logic chặt chẽ hơn
        private static void ValidateClass(ClassDTO c, bool isUpdate)
        {
            // 1. Trim khoảng trắng đầu đuôi
            if (c.ClassName != null) c.ClassName = c.ClassName.Trim();

            // 2. Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(c.ClassName))
            {
                throw new ArgumentException("Tên lớp không được để trống!");
            }

            // 3. Kiểm tra độ dài
            if (c.ClassName.Length > 50)
            {
                throw new ArgumentException("Tên lớp quá dài (tối đa 50 ký tự)!");
            }

            // 4. Kiểm tra trùng lặp
            List<ClassDTO> allClasses = ClassDAO.GetAllClasses();
            bool exists = false;

            if (isUpdate)
            {
                // Khi sửa: Kiểm tra trùng tên + cùng khối + NHƯNG khác ID (không trùng chính nó)
                exists = allClasses.Any(x =>
                    x.ClassName.Equals(c.ClassName, StringComparison.OrdinalIgnoreCase) &&
                    x.GradeId == c.GradeId &&
                    x.Id != c.Id);
            }
            else
            {
                // Khi thêm: Kiểm tra trùng tên + cùng khối
                exists = allClasses.Any(x =>
                    x.ClassName.Equals(c.ClassName, StringComparison.OrdinalIgnoreCase) &&
                    x.GradeId == c.GradeId);
            }

            if (exists)
            {
                throw new ArgumentException($"Lớp '{c.ClassName}' đã tồn tại trong khối này!");
            }
        }

        public static void AddClass(ClassDTO c)
        {
            ValidateClass(c, false);
            ClassDAO.AddClass(c);
        }

        public static void UpdateClass(ClassDTO c)
        {
            ValidateClass(c, true);
            ClassDAO.UpdateClass(c);
        }

        public static void DeleteClass(int id)
        {
            if (id <= 0) throw new ArgumentException("Mã lớp không hợp lệ!");
            ClassDAO.DeleteClass(id);
        }

        public static List<ClassDTO> GetAllClasses()
        {
            return ClassDAO.GetAllClasses();
        }
    }
}