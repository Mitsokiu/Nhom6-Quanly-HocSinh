using System.Windows.Forms;
using System.Drawing;

namespace GUI.UserControls
{
    partial class UC_HocSinh_ChiTietThongBao
    {
        private System.ComponentModel.IContainer components = null;

        // Controls
        private Label lblBack;
        private Panel pnlCard; // Cái khung trắng
        private Label lblTitle;
        private PictureBox picUser;
        private Label lblSender;
        private PictureBox picCalendar;
        private Label lblDate;
        private Panel pnlDivider;
        private Label lblContent;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblBack = new Label();
            this.pnlCard = new Panel();
            this.lblTitle = new Label();
            this.picUser = new PictureBox();
            this.lblSender = new Label();
            this.picCalendar = new PictureBox();
            this.lblDate = new Label();
            this.pnlDivider = new Panel();
            this.lblContent = new Label();

            this.pnlCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCalendar)).BeginInit();
            this.SuspendLayout();

            // 
            // UC_HocSinh_ChiTietThongBao
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = Color.FromArgb(245, 247, 250); // Nền xám nhạt
            this.Controls.Add(this.pnlCard);
            this.Controls.Add(this.lblBack);
            this.Padding = new Padding(40, 30, 40, 30);
            this.Size = new Size(1100, 700);

            // 
            // lblBack (Nút quay lại)
            // 
            this.lblBack.Text = "←  Quay lại danh sách";
            this.lblBack.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblBack.ForeColor = Color.FromArgb(73, 80, 87);
            this.lblBack.Cursor = Cursors.Hand;
            this.lblBack.AutoSize = true;
            this.lblBack.Location = new Point(40, 20);
            this.lblBack.Click += new System.EventHandler(this.btnBack_Click);

            // 
            // pnlCard (Khung trắng chứa nội dung)
            // 
            this.pnlCard.BackColor = Color.White;
            this.pnlCard.Location = new Point(40, 60);
            this.pnlCard.Size = new Size(1020, 600);
            this.pnlCard.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            // Các control con của card
            this.pnlCard.Controls.Add(this.lblTitle);
            this.pnlCard.Controls.Add(this.picUser);
            this.pnlCard.Controls.Add(this.lblSender);
            this.pnlCard.Controls.Add(this.picCalendar);
            this.pnlCard.Controls.Add(this.lblDate);
            this.pnlCard.Controls.Add(this.pnlDivider);
            this.pnlCard.Controls.Add(this.lblContent);

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(33, 37, 41);
            this.lblTitle.Location = new Point(40, 40);
            this.lblTitle.MaximumSize = new Size(940, 0); // Tự xuống dòng
            this.lblTitle.Text = "Tiêu đề thông báo";

            // 
            // picUser (Icon người)
            // 
            this.picUser.Size = new Size(20, 20);
            this.picUser.Location = new Point(50, 130);
            this.picUser.BackColor = Color.Gray; // Placeholder màu xám (thay ảnh sau)

            // 
            // lblSender
            // 
            this.lblSender.AutoSize = true;
            this.lblSender.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblSender.ForeColor = Color.FromArgb(33, 37, 41);
            this.lblSender.Location = new Point(80, 128);
            this.lblSender.Text = "Người gửi";

            // 
            // picCalendar (Icon lịch)
            // 
            this.picCalendar.Size = new Size(20, 20);
            this.picCalendar.Location = new Point(300, 130);
            this.picCalendar.BackColor = Color.Gray; // Placeholder

            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new Font("Segoe UI", 11F);
            this.lblDate.ForeColor = Color.FromArgb(108, 117, 125);
            this.lblDate.Location = new Point(330, 128);
            this.lblDate.Text = "15 tháng 5, 2024";

            // 
            // pnlDivider (Đường kẻ ngang mờ)
            // 
            this.pnlDivider.BackColor = Color.FromArgb(233, 236, 239);
            this.pnlDivider.Size = new Size(940, 1);
            this.pnlDivider.Location = new Point(40, 170);
            this.pnlDivider.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // 
            // lblContent (Nội dung chính)
            // 
            this.lblContent.AutoSize = true;
            this.lblContent.Font = new Font("Segoe UI", 12F); // Font to dễ đọc
            this.lblContent.ForeColor = Color.FromArgb(33, 37, 41);
            this.lblContent.Location = new Point(40, 200);
            this.lblContent.MaximumSize = new Size(940, 0); // Quan trọng: Tự động xuống dòng
            this.lblContent.Text = "Nội dung chi tiết thông báo...";

            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCalendar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}