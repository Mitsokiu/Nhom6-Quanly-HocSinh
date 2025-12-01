using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
public class NotificationBUS
{
    public static bool Add(NotificationDTO n)
    {
        return NotificationDAO.Insert(n);
    }

    public static bool Edit(NotificationDTO n)
    {
        return NotificationDAO.Update(n);
    }

    public static bool Remove(int id)
    {
        return NotificationDAO.Delete(id);
    }

    // Lấy toàn bộ danh sách
    public static DataTable GetAll()
    {
        return NotificationDAO.GetAll();
    }

    public static NotificationDTO GetLatest()
    {
        DataRow row = NotificationDAO.GetLatestNotification();
        if (row == null) return null;

        return new NotificationDTO
        {
            Id = Convert.ToInt32(row["id"]),
            TargetRole = row["target_role"].ToString(),
            Title = row["title"].ToString(),
            Message = row["message"].ToString(),
            CreatedAt = Convert.ToDateTime(row["created_at"])
        };


    }

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

    public List<NotificationDTO> GetMyNotifications(int senderId)
    {
        return dao.GetNotificationsBySender(senderId);
    }
    public bool DeleteNotification(int id)
    {
        return dao.DeleteNotification(id);
    }
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
