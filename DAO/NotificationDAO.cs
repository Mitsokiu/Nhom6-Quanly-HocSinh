using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAO
{
    public class NotificationDAO
    {
        private DbConnect db = new DbConnect();

        // Thêm mới
        public bool AddNotification(NotificationDTO noti)
        {
            string query = @"INSERT INTO notifications (sender_id, target_role, title, message, created_at) 
                             VALUES (@param0, @param1, @param2, @param3, NOW())";
            // Lưu ý: NOW() là hàm lấy giờ của MySQL, nếu dùng SQL Server thì sửa thành GETDATE()
            return DbConnect.ExecuteNonQuery(query, new object[] { noti.SenderId, noti.TargetRole, noti.Title, noti.Message }) > 0;
        }

        // Cập nhật
        public bool UpdateNotification(NotificationDTO noti)
        {
            string query = @"UPDATE notifications SET title = @param0, message = @param1 WHERE id = @param2";
            return DbConnect.ExecuteNonQuery(query, new object[] { noti.Title, noti.Message, noti.Id }) > 0;
        }

        // Xóa
        public bool DeleteNotification(int id)
        {
            string query = "DELETE FROM notifications WHERE id = @param0";
            return DbConnect.ExecuteNonQuery(query, new object[] { id }) > 0;
        }

        // Lấy danh sách gửi bởi GV (senderId)
        public List<NotificationDTO> GetNotificationsBySender(int senderId)
        {
            List<NotificationDTO> list = new List<NotificationDTO>();
            string query = @"SELECT n.id, n.title, n.message, n.created_at, n.target_role, u.fullname AS SenderName 
                             FROM notifications n 
                             JOIN users u ON n.sender_id = u.user_id
                             WHERE n.sender_id = @param0 
                             ORDER BY n.created_at DESC";

            DataTable data = DbConnect.ExecuteQuery(query, new object[] { senderId });

            foreach (DataRow row in data.Rows)
            {
                NotificationDTO item = new NotificationDTO();
                item.Id = Convert.ToInt32(row["id"]);
                item.Title = row["title"].ToString();
                item.Message = row["message"].ToString();
                item.CreatedAt = Convert.ToDateTime(row["created_at"]);
                item.TargetRole = row["target_role"].ToString();
                item.SenderName = row["SenderName"].ToString();

                list.Add(item);
            }
            return list;
        }
        // Lấy danh sách cho Học sinh (TargetRole = 'student')
        // Hàm này phục vụ cho BUS: GetNotificationsForStudent
        public List<NotificationDTO> GetNotificationsByTargetRole(string role)
        {
            List<NotificationDTO> list = new List<NotificationDTO>();
            string query = @"SELECT n.id, n.title, n.message, n.created_at, n.target_role, u.fullname AS SenderName 
                             FROM notifications n 
                             JOIN users u ON n.sender_id = u.user_id
                             WHERE n.target_role = @param0 
                             ORDER BY n.created_at DESC";

            DataTable data = DbConnect.ExecuteQuery(query, new object[] { role });

            foreach (DataRow row in data.Rows)
            {
                NotificationDTO item = new NotificationDTO();
                item.Id = Convert.ToInt32(row["id"]);
                item.Title = row["title"].ToString();
                item.Message = row["message"].ToString();
                item.CreatedAt = Convert.ToDateTime(row["created_at"]);
                item.TargetRole = row["target_role"].ToString();
                item.SenderName = row["SenderName"].ToString();

                list.Add(item);
            }
            return list;
        }
    }
}
