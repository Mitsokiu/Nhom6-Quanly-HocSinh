using DAO;
using DTO;
using System.Collections.Generic;

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
    }
}