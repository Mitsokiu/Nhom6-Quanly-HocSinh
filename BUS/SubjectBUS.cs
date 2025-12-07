using DAO;
using DTO;
using System.Collections.Generic;
using System.Linq;

namespace BUS
{
    public class SubjectBUS
    {
        private SubjectDAO dao = new SubjectDAO();

        public List<SubjectDTO> GetAll()
        {
            return dao.GetAll();
        }

        public bool Add(SubjectDTO s)
        {
            if (string.IsNullOrWhiteSpace(s.SubjectName)) return false;

            // Check trùng tên
            var list = GetAll();
            if (list.Any(x => x.SubjectName.ToLower() == s.SubjectName.Trim().ToLower())) return false;

            return dao.Insert(s);
        }

        public bool Update(SubjectDTO s)
        {
            if (s.SubjectId <= 0 || string.IsNullOrWhiteSpace(s.SubjectName)) return false;
            return dao.Update(s);
        }

        public bool Delete(int id)
        {
            if (id <= 0) return false;
            return dao.Delete(id);
        }
    }
}