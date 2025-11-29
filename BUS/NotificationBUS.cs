using DAO;
using DTO;
using System;
using System.Data;
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

}
