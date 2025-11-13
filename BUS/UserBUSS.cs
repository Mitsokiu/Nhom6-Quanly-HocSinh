using DAO;
using DTO;
using System.Collections.Generic;

namespace BUS
{
    public class UserBUS
    {
        private UserDAO userDAO = new UserDAO();

        // Kiểm tra login
        public bool Login(string username, string password)
        {
            UserDTO user = new UserDTO
            {
                Username = username,
                Password = password
            };
            return userDAO.CheckLogin(user);
        }

        // Lấy thông tin user khi login thành công
        public UserDTO GetUserInfo(string username)
        {
            return userDAO.GetUserInfo(username);
        }


        public bool AddUser(UserDTO user)
        {
            return userDAO.AddUser(user);
        }

        public List<UserDTO> GetAllUsers()
        {
            return userDAO.GetAllUsers();
        }

        // trong UserBUS
        public bool UpdateUser(UserDTO user)
        {
            return userDAO.UpdateUser(user); // gọi DAO để update DB
        }

        public bool DeleteUser(string username)
        {
            return userDAO.DeleteUser(username); // gọi DAO để xóa user theo username
        }

    }
}
