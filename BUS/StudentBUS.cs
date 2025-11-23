using DAO;

namespace BUS
{
    public class StudentBUS
    {   
        private StudentDAO dao = new StudentDAO();
        public int GetClassIdByUserId(int userId)
        {
            return dao.GetClassIdByUserId(userId);
        }
    }
}