using DAO;
using DTO;
using System.Collections.Generic;
using System.Linq;

namespace BUS
{
    public class GradeBUS
    {
        private readonly GradeDAO _gradeDAO;

        public GradeBUS()
        {
            _gradeDAO = new GradeDAO();
        }

        public List<GradeDTO> GetListGrade()
        {
            return _gradeDAO.GetListGrade();
        }

        // --- THÊM LOGIC ---
        public bool Add(GradeDTO g)
        {
            if (string.IsNullOrWhiteSpace(g.Name)) return false;
            // Check trùng
            if (GetListGrade().Any(x => x.Name.ToLower() == g.Name.Trim().ToLower())) return false;

            return _gradeDAO.Insert(g);
        }

        public bool Update(GradeDTO g)
        {
            if (g.Id <= 0 || string.IsNullOrWhiteSpace(g.Name)) return false;
            return _gradeDAO.Update(g);
        }

        public bool Delete(int id)
        {
            if (id <= 0) return false;
            return _gradeDAO.Delete(id);
        }
    }
}