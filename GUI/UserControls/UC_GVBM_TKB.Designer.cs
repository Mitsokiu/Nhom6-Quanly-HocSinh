using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI.UserControls
{
    partial class UC_GVBM_TKB
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        private void InitializeComponent()
        {
            // Thiết lập màu sắc và font hiện đại
            System.Drawing.Color primaryColor = System.Drawing.Color.FromArgb(52, 152, 219); // Blue
            System.Drawing.Color backColor = System.Drawing.Color.WhiteSmoke;
            System.Drawing.Font headerFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            System.Drawing.Font labelFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            this.panel1 = new System.Windows.Forms.Panel();
            this.labelHeader = new System.Windows.Forms.Label(); // Thêm label tiêu đề
            this.label7 = new System.Windows.Forms.Label();
            this.cbBoxnamhoc = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxhk = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Day = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Class = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sub = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Period = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Room = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();

            // 
            // UC_GVBM_TKB (User Control chính)
            // 
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "UC_GVBM_TKB";
            this.Size = new System.Drawing.Size(1219, 837);
            this.BackColor = backColor; // Đặt màu nền chung

            // 
            // panel1 (Chứa các controls lọc)
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.BackColor = System.Drawing.Color.White; // Nền trắng để nổi bật
            this.panel1.Controls.Add(this.labelHeader); // Thêm tiêu đề
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cbBoxnamhoc);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.comboBoxhk);
            this.panel1.Location = new System.Drawing.Point(10, 18); // Vị trí mới
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 643); // Chiều rộng cố định
            this.panel1.TabIndex = 0;

            // 
            // labelHeader (Tiêu đề lớn)
            // 
            this.labelHeader.Font = headerFont;
            this.labelHeader.ForeColor = primaryColor;
            this.labelHeader.Location = new System.Drawing.Point(12, 15);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(270, 30);
            this.labelHeader.Text = "📅 THỜI KHÓA BIỂU";
            this.labelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // label7 (Năm Học)
            // 
            this.label7.Location = new System.Drawing.Point(15, 70); // Vị trí mới
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 23);
            this.label7.TabIndex = 18;
            this.label7.Text = "Năm Học:";
            this.label7.Font = labelFont;

            // 
            // cbBoxnamhoc
            // 
            this.cbBoxnamhoc.Location = new System.Drawing.Point(120, 65); // Vị trí mới
            this.cbBoxnamhoc.Name = "cbBoxnamhoc";
            this.cbBoxnamhoc.Size = new System.Drawing.Size(167, 28);
            this.cbBoxnamhoc.TabIndex = 19;
            this.cbBoxnamhoc.Text = "Chọn Năm Học..."; // Placeholder
            this.cbBoxnamhoc.SelectedIndexChanged += new System.EventHandler(this.CbBoxnamhoc_SelectedIndexChanged);

            // 
            // label5 (Học Kỳ)
            // 
            this.label5.Location = new System.Drawing.Point(15, 120); // Vị trí mới
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 16;
            this.label5.Text = "Học Kỳ:";
            this.label5.Font = labelFont;

            // 
            // comboBoxhk
            // 
            this.comboBoxhk.Location = new System.Drawing.Point(120, 115); // Vị trí mới
            this.comboBoxhk.Name = "comboBoxhk";
            this.comboBoxhk.Size = new System.Drawing.Size(164, 28);
            this.comboBoxhk.TabIndex = 17;
            this.comboBoxhk.Text = "Chọn Học Kỳ..."; // Placeholder
            this.comboBoxhk.SelectedIndexChanged += new System.EventHandler(this.ComboBoxhk_SelectedIndexChanged);
            // 
            // panel2 (Chứa DataGridView)
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Location = new System.Drawing.Point(323, 18);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(890, 643); // Mở rộng chiều ngang
            this.panel2.TabIndex = 1;

            // 
            // dataGridView1 (Bảng TKB)
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Day,
            this.Class,
            this.Sub,
            this.Period,
            this.Room});
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(880, 625); // Điều chỉnh kích thước
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.BorderStyle = BorderStyle.None; // Xóa border
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = primaryColor; // Đổi màu header
            this.dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Font = labelFont;
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LightCyan; // Phân biệt dòng

            // 
            // Day
            // 
            this.Day.HeaderText = "Thứ";
            this.Day.MinimumWidth = 8;
            this.Day.Name = "Day";
            this.Day.Width = 100; // Điều chỉnh độ rộng

            // 
            // Class
            // 
            this.Class.HeaderText = "Lớp";
            this.Class.MinimumWidth = 8;
            this.Class.Name = "Class";
            this.Class.Width = 150;

            // 
            // Sub
            // 
            this.Sub.HeaderText = "Môn Học";
            this.Sub.MinimumWidth = 8;
            this.Sub.Name = "Sub";
            this.Sub.Width = 200; // Mở rộng cho tên môn học

            // 
            // Period
            // 
            this.Period.HeaderText = "Tiết Dạy";
            this.Period.MinimumWidth = 8;
            this.Period.Name = "Period";
            this.Period.Width = 100;

            // 
            // Room
            // 
            this.Room.HeaderText = "Phòng Học";
            this.Room.MinimumWidth = 8;
            this.Room.Name = "Room";
            this.Room.Width = 120;

            // 
            // Kết thúc
            // 
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label7;
        private ComboBox cbBoxnamhoc;
        private Label label5;
        private ComboBox comboBoxhk;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Day;
        private DataGridViewTextBoxColumn Class;
        private DataGridViewTextBoxColumn Sub;
        private DataGridViewTextBoxColumn Period;
        private DataGridViewTextBoxColumn Room;
        private Label labelHeader; // Thêm label mới
    }
}