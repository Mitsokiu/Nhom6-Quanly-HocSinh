using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class NotificationDAO
    {
        private DbConnect db = new DbConnect();

        public List<NotificationDTO> GetNotificationsByRole(string targetRole)
        {
            List<NotificationDTO> list = new List<NotificationDTO>();

            // Logic: Lấy thông báo gửi riêng cho role ĐÓ hoặc gửi cho ALL (toàn trường)
            // Sắp xếp: Mới nhất lên đầu (DESC)
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
