using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BUS
{
    public class NotificationBUS
    {
        private NotificationDAO dao = new NotificationDAO();

        public bool CreateNotification(int senderId, string targetRole, string title, string message, out string errorMessage)
        {
            errorMessage = "";

            if (string.IsNullOrWhiteSpace(title) || title == "Nhập tiêu đề...")
            {
                errorMessage = "Tiêu đề thông báo không được để trống!";
                return false;
            }

            if (title.Length > 200)
            {
                errorMessage = "Tiêu đề quá dài (tối đa 200 ký tự).";
                return false;
            }

            if (string.IsNullOrWhiteSpace(message))
            {
                errorMessage = "Nội dung thông báo không được để trống!";
                return false;
            }

            if (string.IsNullOrEmpty(targetRole))
            {
                errorMessage = "Vui lòng chọn đối tượng gửi (Lớp học hoặc Toàn trường).";
                return false;
            }

            NotificationDTO noti = new NotificationDTO
            {
                SenderId = senderId,
                TargetRole = targetRole,
                Title = title,
                Message = message
            };

            bool result = dao.AddNotification(noti);

            if (!result)
            {
                errorMessage = "Lỗi kết nối cơ sở dữ liệu. Không thể thêm thông báo.";
            }

            return result;
        }

        public List<NotificationDTO> GetMyNotifications(int senderId)
        {
            return dao.GetNotificationsBySender(senderId);
        }

        public List<NotificationDTO> GetNotificationsForStudent()
        {
            return dao.GetNotificationsByRole("student");
        }

        public List<NotificationDTO> FilterNotifications(List<NotificationDTO> allList, string filterType)
        {
            if (string.IsNullOrEmpty(filterType) || filterType == "Tất cả")
            {
                return allList;
            }

            if (filterType == "Nhà trường")
            {
                return allList.Where(n => n.SenderRole == "admin").ToList();
            }

            if (filterType == "Giáo viên")
            {
                return allList.Where(n => n.SenderRole == "gvcn" || n.SenderRole == "gvbm").ToList();
            }

            return allList;
        }
    }
}