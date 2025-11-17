using DAO;
using DTO;
using System.Collections.Generic;

namespace BUS
{
    public class UserBUS
    {
        private UserDAO dao = new UserDAO();


        public bool Login(string username, string password)
        {
            return dao.CheckLogin(username, password);
        }

        public UserDTO GetUserInfo(string username)
        {

            return dao.GetUserByUsername(username);
        }

        public List<UserDTO> GetAllUsers()
        {
            return dao.GetAllUsers();
        }

        public bool UpdateUser(UserDTO user)
        {
            return dao.UpdateUser(user);
        }

        public bool DeleteUser(int userId)
        {
            return dao.DeleteUser(userId);
        }

        public bool AddUser(UserDTO user)
        {
            return dao.AddUserFull(user);
        }

        public List<UserDTO> SearchUsers(string keyword)
        {
            return dao.SearchUsers(keyword);
        }

        public static List<UserDTO> GetAllTeachers()
        {
            return UserDAO.GetAllTeachers();
        }



    }
}
