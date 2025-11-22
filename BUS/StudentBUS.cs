using DAO;

namespace BUS
{
    public class StudentBUS
    {
        public int GetClassIdByUserId(int userId)
        {
            return StudentDAO.Instance.GetClassIdByUserId(userId);
        }
    }
}