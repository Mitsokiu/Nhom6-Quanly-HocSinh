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

        public bool CreateNotification(int senderId, string title, string message, out string errorMessage)
        {
            if (!Validate(title, message, out errorMessage)) return false;

            NotificationDTO noti = new NotificationDTO
            {
                SenderId = senderId,
                TargetRole = "student", // Mặc định gửi cho học sinh
                Title = title,
                Message = message
            };
            return dao.AddNotification(noti);
        }

        public bool UpdateNotification(int id, string title, string message, out string errorMessage)
        {
            if (!Validate(title, message, out errorMessage)) return false;

            NotificationDTO noti = new NotificationDTO { Id = id, Title = title, Message = message };
            return dao.UpdateNotification(noti);
        }

        public bool DeleteNotification(int id)
        {
            return dao.DeleteNotification(id);
        }

        // Lấy danh sách của GV đang đăng nhập
        public List<NotificationDTO> GetMyNotifications(int senderId)
        {
            return dao.GetNotificationsBySender(senderId);
        }

        // Lấy danh sách hiển thị cho học sinh (FIX LỖI THIẾU HÀM)
        public List<NotificationDTO> GetNotificationsForStudent()
        {
            return dao.GetNotificationsByTargetRole("student");
        }

        // Chức năng tìm kiếm (FIX LỖI THIẾU HÀM)
        public List<NotificationDTO> FilterNotifications(List<NotificationDTO> source, string keyword)
        {
            if (source == null || source.Count == 0) return new List<NotificationDTO>();

            if (string.IsNullOrWhiteSpace(keyword) || keyword.Trim() == "Tìm kiếm thông báo...")
                return source;

            keyword = keyword.Trim().ToLower();

            // Tìm theo tiêu đề hoặc nội dung
            return source.Where(x => x.Title.ToLower().Contains(keyword) ||
                                     x.Message.ToLower().Contains(keyword)).ToList();
        }

        // Tương thích ngược nếu code cũ còn gọi tên hàm này
        public List<NotificationDTO> SearchNotifications(List<NotificationDTO> source, string keyword)
        {
            return FilterNotifications(source, keyword);
        }

        private bool Validate(string title, string message, out string error)
        {
            error = "";
            if (string.IsNullOrWhiteSpace(title) || title == "Nhập tiêu đề...")
            {
                error = "Tiêu đề không được để trống!";
                return false;
            }
            if (title.Length > 255)
            {
                error = "Tiêu đề quá dài!";
                return false;
            }
            if (string.IsNullOrWhiteSpace(message))
            {
                error = "Nội dung không được để trống!";
                return false;
            }
            return true;
        }
    }
}
