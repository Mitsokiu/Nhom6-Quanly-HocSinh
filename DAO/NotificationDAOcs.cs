using System;
using System.Data;
using MySql.Data.MySqlClient;
using DTO;

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

    }
}
