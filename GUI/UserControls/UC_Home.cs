using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.UserControls
{
    public partial class UC_Home : UserControl
    {
        // =============================================================
        // HÀM HELPER GIẢ ĐỊNH CHO MỤC ĐÍCH BIÊN DỊCH
        // =============================================================
        public class Notification
        {
            public string Title { get; set; }
            public string Message { get; set; }
            public DateTime CreatedAt { get; set; }
        }
        public static class NotificationBUS
        {
            public static Notification GetLatest()
            {
                // Trả về thông báo giả định mới nhất
                return new Notification
                {
                    Title = "Thông Báo Quan Trọng Về Lịch Học",
                    Message = "Lịch học tuần này đã được cập nhật. Vui lòng kiểm tra email và trang thông báo chính thức để biết chi tiết thay đổi.",
                    CreatedAt = DateTime.Now.Date.AddHours(10).AddMinutes(30)
                };
            }
        }
        // =============================================================

        public UC_Home()
        {
            InitializeComponent();
            // Hàm cũ được gọi
            LoadLatestNotification();
        }

        private void UC_Home_Load(object sender, EventArgs e)
        {
            // Không cần làm gì ở đây
        }

        private void LoadLatestNotification()
        {
            var n = NotificationBUS.GetLatest();
            if (n != null)
            {
                // Gán dữ liệu vào các label cũ
                labeltitle.Text = n.Title;
                labelmes.Text = n.Message;
                labeldate.Text = n.CreatedAt.ToString("dd/MM/yyyy HH:mm");
            }
            else
            {
                // Hiển thị thông báo không có dữ liệu
                labeltitle.Text = "Không có thông báo mới";
                labelmes.Text = "Hiện không có thông báo nào được tìm thấy.";
                labeldate.Text = "";
            }
        }

    }
}