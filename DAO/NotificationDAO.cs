using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAO
{
    public class NotificationDAO
    {
        private DbConnect db = new DbConnect();

        public bool AddNotification(NotificationDTO noti)
        {
            string query = @"
                INSERT INTO notifications (sender_id, target_role, title, message, created_at) 
                VALUES (@param0, @param1, @param2, @param3, NOW())";

            int result = DbConnect.ExecuteNonQuery(query, new object[] {
                noti.SenderId,
                noti.TargetRole,
                noti.Title,
                noti.Message
            });

            return result > 0;
        }

        public List<NotificationDTO> GetNotificationsBySender(int senderId)
        {
            List<NotificationDTO> list = new List<NotificationDTO>();
            string query = @"
                SELECT n.id, n.title, n.message, n.created_at, n.target_role,
                       u.fullname AS SenderName 
                FROM notifications n
                JOIN users u ON n.sender_id = u.user_id
                WHERE n.sender_id = @param0
                ORDER BY n.created_at DESC";

            DataTable data = DbConnect.ExecuteQuery(query, new object[] { senderId });

            foreach (DataRow row in data.Rows)
            {
                list.Add(new NotificationDTO
                {
                    Id = Convert.ToInt32(row["id"]),
                    Title = row["title"].ToString(),
                    Message = row["message"].ToString(),
                    CreatedAt = Convert.ToDateTime(row["created_at"]),
                    TargetRole = row["target_role"].ToString(),
                    SenderName = row["SenderName"].ToString()
                });
            }
            return list;
        }

        public List<NotificationDTO> GetNotificationsByRole(string targetRole)
        {
            List<NotificationDTO> list = new List<NotificationDTO>();
            string query = @"
                SELECT n.id, n.title, n.message, n.created_at, 
                       u.fullname AS SenderName, u.role_id AS SenderRole
                FROM notifications n
                JOIN users u ON n.sender_id = u.user_id
                WHERE n.target_role = @param0 OR n.target_role = 'all'
                ORDER BY n.created_at DESC";

            DataTable data = DbConnect.ExecuteQuery(query, new object[] { targetRole });

            foreach (DataRow row in data.Rows)
            {
                list.Add(new NotificationDTO
                {
                    Id = Convert.ToInt32(row["id"]),
                    Title = row["title"].ToString(),
                    Message = row["message"].ToString(),
                    CreatedAt = Convert.ToDateTime(row["created_at"]),
                    SenderName = row["SenderName"].ToString(),
                    SenderRole = row["SenderRole"].ToString()
                });
            }
            return list;
        }
    }
}