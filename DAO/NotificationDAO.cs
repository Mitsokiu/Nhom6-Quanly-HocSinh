using DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAO
{
    public class NotificationDAO
    {
        // Lấy toàn bộ danh sách thông báo
        public static DataTable GetAll()
        {
           
            string sql = "SELECT id, target_role, title, message, created_at FROM notifications ORDER BY created_at DESC";

            return DbConnect.ExecuteQuery(sql);
        }

        // Thêm thông báo
        public static bool Insert(NotificationDTO n)
        {
            string sql = @"INSERT INTO notifications 
                           (sender_id, target_role, title, message, created_at)
                           VALUES (@param0, @param1, @param2, @param3, NOW())";

            object[] parameters = { n.SenderId, n.TargetRole, n.Title, n.Message };
            return DbConnect.ExecuteNonQuery(sql, parameters) > 0;
        }

        // Sửa thông báo
        public static bool Update(NotificationDTO n)
        {
            string sql = @"UPDATE notifications SET 
                            target_role = @param0,
                            title = @param1,
                            message = @param2
                           WHERE id = @param3";

            object[] parameters = { n.TargetRole, n.Title, n.Message, n.Id };
            return DbConnect.ExecuteNonQuery(sql, parameters) > 0;
        }

        // Xoá thông báo
        public static bool Delete(int id)
        {
            string sql = "DELETE FROM notifications WHERE id = @param0";
            object[] parameters = { id };
            return DbConnect.ExecuteNonQuery(sql, parameters) > 0;
        }

        // Lấy thông báo theo role (teacher, student, parent, all)
        public static DataTable GetByRole(string role)
        {
            string sql = @"SELECT * FROM notifications 
                           WHERE target_role = @param0
                              OR target_role = 'all'
                           ORDER BY created_at DESC";

            object[] parameters = { role };
            return DbConnect.ExecuteQuery(sql, parameters);
        }

        // Lấy thông báo theo ID (dùng khi sửa)
        public static DataRow GetById(int id)
        {
            string sql = "SELECT * FROM notifications WHERE id = @param0";
            DataTable dt = DbConnect.ExecuteQuery(sql, new object[] { id });

            if (dt.Rows.Count > 0)
                return dt.Rows[0];
            return null;
        }

        public static DataRow GetLatestNotification()
        {
            string sql = "SELECT id, target_role, title, message, created_at FROM notifications ORDER BY created_at DESC LIMIT 1";
            DataTable dt = DbConnect.ExecuteQuery(sql);
            if (dt.Rows.Count > 0)
                return dt.Rows[0];
            return null;
        }
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

        // Thêm hàm lấy chi tiết theo ID
        public NotificationDTO GetNotificationById(int id)
        {
            string query = @"
                SELECT n.id, n.title, n.message, n.created_at, 
                        u.fullname AS SenderName, u.role_id AS SenderRole
                FROM notifications n
                JOIN users u ON n.sender_id = u.user_id
                WHERE n.id = @param0";

            DataTable data = DbConnect.ExecuteQuery(query, new object[] { id });

            if (data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                return new NotificationDTO
                {
                    Id = Convert.ToInt32(row["id"]),
                    Title = row["title"].ToString(),
                    Message = row["message"].ToString(),
                    CreatedAt = Convert.ToDateTime(row["created_at"]),
                    SenderName = row["SenderName"].ToString(),
                    SenderRole = row["SenderRole"].ToString()
                };
            }
            return null;
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
        // Xóa
        public bool DeleteNotification(int id)
        {
            string query = "DELETE FROM notifications WHERE id = @param0";
            return DbConnect.ExecuteNonQuery(query, new object[] { id }) > 0;
        }

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
