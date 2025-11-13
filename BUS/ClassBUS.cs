using System.Collections.Generic;
using DTO;

namespace BUS
{
    public class ClassBUS
    {
        private List<ClassDTO> classes = new List<ClassDTO>();

        public List<ClassDTO> GetAllClasses() => classes;

        public bool AddClass(ClassDTO c)
        {
            classes.Add(c);
            return true;
        }

        public bool UpdateClass(ClassDTO c)
        {
            var existing = classes.Find(x => x.Id == c.Id);
            if (existing == null) return false;
            existing.Khoi = c.Khoi;
            existing.Lop = c.Lop;
            existing.GVCN = c.GVCN;
            return true;
        }

        public bool DeleteClass(string id)
        {
            var existing = classes.Find(x => x.Id == id);
            if (existing == null) return false;
            classes.Remove(existing);
            return true;
        }
    }
}
