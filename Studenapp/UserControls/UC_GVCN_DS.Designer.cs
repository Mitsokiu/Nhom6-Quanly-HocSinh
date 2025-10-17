namespace Studenapp.UserControls
{
    partial class UC_GVCN_DS
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            textBox1 = new TextBox();
            dataGridView1 = new DataGridView();
            Stt = new DataGridViewTextBoxColumn();
            Hoten = new DataGridViewTextBoxColumn();
            NgaySinh = new DataGridViewTextBoxColumn();
            GioiTinh = new DataGridViewTextBoxColumn();
            SdtPhuHuynh = new DataGridViewTextBoxColumn();
            HanhKiem = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 33);
            label1.Name = "label1";
            label1.Size = new Size(51, 25);
            label1.TabIndex = 0;
            label1.Text = "Lớp :";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(116, 33);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 31);
            textBox1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Stt, Hoten, NgaySinh, GioiTinh, SdtPhuHuynh, HanhKiem });
            dataGridView1.Location = new Point(320, 31);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(951, 600);
            dataGridView1.TabIndex = 2;
            // 
            // Stt
            // 
            Stt.HeaderText = "STT";
            Stt.MinimumWidth = 8;
            Stt.Name = "Stt";
            Stt.Width = 150;
            // 
            // Hoten
            // 
            Hoten.HeaderText = "Họ và Tên";
            Hoten.MinimumWidth = 8;
            Hoten.Name = "Hoten";
            Hoten.Width = 150;
            // 
            // NgaySinh
            // 
            NgaySinh.HeaderText = "Ngày Sinh";
            NgaySinh.MinimumWidth = 8;
            NgaySinh.Name = "NgaySinh";
            NgaySinh.Width = 150;
            // 
            // GioiTinh
            // 
            GioiTinh.HeaderText = "Giới Tính";
            GioiTinh.MinimumWidth = 8;
            GioiTinh.Name = "GioiTinh";
            GioiTinh.Width = 150;
            // 
            // SdtPhuHuynh
            // 
            SdtPhuHuynh.HeaderText = "SĐT Phụ Huynh";
            SdtPhuHuynh.MinimumWidth = 8;
            SdtPhuHuynh.Name = "SdtPhuHuynh";
            SdtPhuHuynh.Width = 150;
            // 
            // HanhKiem
            // 
            HanhKiem.HeaderText = "Hạnh Kiểm";
            HanhKiem.MinimumWidth = 8;
            HanhKiem.Name = "HanhKiem";
            HanhKiem.Width = 150;
            // 
            // UC_GVCN_DS
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridView1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "UC_GVCN_DS";
            Size = new Size(1288, 649);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Stt;
        private DataGridViewTextBoxColumn Hoten;
        private DataGridViewTextBoxColumn NgaySinh;
        private DataGridViewTextBoxColumn GioiTinh;
        private DataGridViewTextBoxColumn SdtPhuHuynh;
        private DataGridViewTextBoxColumn HanhKiem;
    }
}
