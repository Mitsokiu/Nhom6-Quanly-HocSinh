using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI.UserControls
{
    partial class UC_Admin_Class_KhoiLop
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.textMa = new System.Windows.Forms.TextBox();
            this.textKhoi = new System.Windows.Forms.TextBox();
            this.textLop = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_them = new System.Windows.Forms.Button();
            this.btn_sua = new System.Windows.Forms.Button();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Khoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textMa
            // 
            this.textMa.Location = new System.Drawing.Point(105, 36);
            this.textMa.Name = "textMa";
            this.textMa.Size = new System.Drawing.Size(100, 26);
            this.textMa.TabIndex = 0;
            // 
            // textKhoi
            // 
            this.textKhoi.Location = new System.Drawing.Point(105, 91);
            this.textKhoi.Name = "textKhoi";
            this.textKhoi.Size = new System.Drawing.Size(100, 26);
            this.textKhoi.TabIndex = 2;
            // 
            // textLop
            // 
            this.textLop.Location = new System.Drawing.Point(105, 143);
            this.textLop.Name = "textLop";
            this.textLop.Size = new System.Drawing.Size(100, 26);
            this.textLop.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(29, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 1;
            this.label4.Text = "Mã";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(29, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Khối";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(29, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Lớp";
            // 
            // btn_them
            // 
            this.btn_them.Location = new System.Drawing.Point(6, 347);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(75, 23);
            this.btn_them.TabIndex = 8;
            this.btn_them.Text = "Thêm";
            // 
            // btn_sua
            // 
            this.btn_sua.Location = new System.Drawing.Point(158, 347);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Size = new System.Drawing.Size(75, 23);
            this.btn_sua.TabIndex = 9;
            this.btn_sua.Text = "Sửa";
            // 
            // btn_xoa
            // 
            this.btn_xoa.Location = new System.Drawing.Point(297, 347);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(75, 23);
            this.btn_xoa.TabIndex = 10;
            this.btn_xoa.Text = "Xóa";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeight = 34;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Khoi,
            this.Lop});
            this.dataGridView1.Location = new System.Drawing.Point(421, 13);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(523, 379);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "Mã";
            this.ID.MinimumWidth = 8;
            this.ID.Name = "ID";
            this.ID.Width = 150;
            // 
            // Khoi
            // 
            this.Khoi.HeaderText = "Khối";
            this.Khoi.MinimumWidth = 8;
            this.Khoi.Name = "Khoi";
            this.Khoi.Width = 150;
            // 
            // Lop
            // 
            this.Lop.HeaderText = "Lớp";
            this.Lop.MinimumWidth = 8;
            this.Lop.Name = "Lop";
            this.Lop.Width = 150;
            // 
            // UC_Admin_Class_KhoiLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textMa);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textKhoi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textLop);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_them);
            this.Controls.Add(this.btn_sua);
            this.Controls.Add(this.btn_xoa);
            this.Controls.Add(this.dataGridView1);
            this.Name = "UC_Admin_Class_KhoiLop";
            this.Size = new System.Drawing.Size(1260, 404);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private TextBox textMa, textKhoi, textLop;
        private Label label4, label1, label3;
        private Button btn_them, btn_sua, btn_xoa;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Khoi;
        private DataGridViewTextBoxColumn Lop;
    }
}
