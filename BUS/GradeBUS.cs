using DAO;
using System.Data;

namespace BUS
{
    public class GradeBUS
    {
        public static DataTable GetAll()
        {
            return GradeDAO.GetAll();
        }
    }
}
