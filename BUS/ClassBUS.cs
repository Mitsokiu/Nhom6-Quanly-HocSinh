using DAO;
using DTO;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace BUS
{
    public  class ClassBUS
    {
        public static void AddClass(ClassDTO c) => ClassDAO.AddClass(c);
        public static void UpdateClass(ClassDTO c) => ClassDAO.UpdateClass(c);
        public static void DeleteClass(int id) => ClassDAO.DeleteClass(id);
        public static List<ClassDTO> GetAllClasses() => ClassDAO.GetAllClasses();
        public static  DataTable GetClassesByYear(int yearId) => ClassDAO.GetClassesByYear(yearId);
    }
}

