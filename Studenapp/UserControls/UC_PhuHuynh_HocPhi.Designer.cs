namespace Studenapp.UserControls
{
    partial class UC_PhuHuynh_HocPhi
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
            comboBox1 = new ComboBox();
            dataGridView1 = new DataGridView();
            KhoanThu = new DataGridViewTextBoxColumn();
            SoTien = new DataGridViewTextBoxColumn();
            DaThu = new DataGridViewTextBoxColumn();
            NgayThu = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "2022-2023", "2024-2025", "2025-2026" });
            comboBox1.Location = new Point(40, 22);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(182, 33);
            comboBox1.TabIndex = 0;
            comboBox1.Text = "Năm học";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { KhoanThu, SoTien, DaThu, NgayThu });
            dataGridView1.Location = new Point(42, 74);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(741, 494);
            dataGridView1.TabIndex = 1;
            // 
            // KhoanThu
            // 
            KhoanThu.HeaderText = "Khoản Thu";
            KhoanThu.MinimumWidth = 8;
            KhoanThu.Name = "KhoanThu";
            KhoanThu.Width = 150;
            // 
            // SoTien
            // 
            SoTien.HeaderText = "Số Tiền";
            SoTien.MinimumWidth = 8;
            SoTien.Name = "SoTien";
            SoTien.Width = 150;
            // 
            // DaThu
            // 
            DaThu.HeaderText = "Đã Thu";
            DaThu.MinimumWidth = 8;
            DaThu.Name = "DaThu";
            DaThu.Width = 150;
            // 
            // NgayThu
            // 
            NgayThu.HeaderText = "NgayThu";
            NgayThu.MinimumWidth = 8;
            NgayThu.Name = "NgayThu";
            NgayThu.Width = 150;
            // 
            // UC_PhuHuynh_HocPhi
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridView1);
            Controls.Add(comboBox1);
            Name = "UC_PhuHuynh_HocPhi";
            Size = new Size(820, 587);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox comboBox1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn KhoanThu;
        private DataGridViewTextBoxColumn SoTien;
        private DataGridViewTextBoxColumn DaThu;
        private DataGridViewTextBoxColumn NgayThu;
    }
}
