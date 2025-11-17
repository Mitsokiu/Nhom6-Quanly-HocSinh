using DAO;
using DTO;
using System.Collections.Generic;

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
            if (string.IsNullOrWhiteSpace(s.SubjectId) || string.IsNullOrWhiteSpace(s.SubjectName))
                return false;

            return dao.Insert(s);
        }

        public bool Update(SubjectDTO s)
        {
            if (string.IsNullOrWhiteSpace(s.SubjectId) || string.IsNullOrWhiteSpace(s.SubjectName))
                return false;

            return dao.Update(s);
        }

        public bool Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return false;

            return dao.Delete(id);
        }

        public static List<ClassDTO> GetAllClasses()
        {
            return ClassDAO.GetAllClasses();
        }
    }
}
