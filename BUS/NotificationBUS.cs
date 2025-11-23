using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class NotificationBUS
    {
        private NotificationDAO dao = new NotificationDAO();

        public List<NotificationDTO> GetNotificationsForStudent()
        {
            return dao.GetNotificationsByRole("student");
        }

        // Hàm lọc dữ liệu theo ComboBox
        public List<NotificationDTO> FilterNotifications(List<NotificationDTO> allList, string filterType)
        {
            if (string.IsNullOrEmpty(filterType) || filterType == "Tất cả")
            {
                return allList;
            }

            if (filterType == "Nhà trường")
            {
                // Lọc những thông báo từ Admin
                return allList.Where(n => n.SenderRole == "admin").ToList();
            }

            if (filterType == "Giáo viên")
            {
                // Lọc những thông báo từ GVCN hoặc GVBM
                return allList.Where(n => n.SenderRole == "gvcn" || n.SenderRole == "gvbm").ToList();
            }

            return allList;
        }

        public NotificationDTO GetDetail(int id)
        {
            return dao.GetNotificationById(id);
        }
    }
}
