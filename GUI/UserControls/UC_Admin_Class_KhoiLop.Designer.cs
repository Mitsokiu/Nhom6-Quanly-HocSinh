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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label_Ma = new System.Windows.Forms.Label();
            this.label_Khoi = new System.Windows.Forms.Label();
            this.label_Lop = new System.Windows.Forms.Label();
            this.btn_them = new System.Windows.Forms.Button();
            this.btn_sua = new System.Windows.Forms.Button();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Khoi_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lop_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel_Input = new System.Windows.Forms.Panel();
            this.cbBoxGrade = new System.Windows.Forms.ComboBox();
            this.textMa = new System.Windows.Forms.TextBox();
            this.textLop = new System.Windows.Forms.TextBox();
            this.label_Title = new System.Windows.Forms.Label();
            this.panel_Pagination = new System.Windows.Forms.Panel();
            this.lblpage = new System.Windows.Forms.Label();
            this.btntail = new System.Windows.Forms.Button();
            this.btnnext = new System.Windows.Forms.Button();
            this.btnback = new System.Windows.Forms.Button();
            this.btnhead = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel_Input.SuspendLayout();
            this.panel_Pagination.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_Ma
            // 
            this.label_Ma.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Ma.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(70)))), ((int)(((byte)(102)))));
            this.label_Ma.Location = new System.Drawing.Point(12, 10);
            this.label_Ma.Name = "label_Ma";
            this.label_Ma.Size = new System.Drawing.Size(100, 26);
            this.label_Ma.TabIndex = 1;
            this.label_Ma.Text = "Mã Lớp";
            this.label_Ma.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Khoi
            // 
            this.label_Khoi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Khoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(70)))), ((int)(((byte)(102)))));
            this.label_Khoi.Location = new System.Drawing.Point(12, 65);
            this.label_Khoi.Name = "label_Khoi";
            this.label_Khoi.Size = new System.Drawing.Size(100, 26);
            this.label_Khoi.TabIndex = 3;
            this.label_Khoi.Text = "Khối";
            this.label_Khoi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Lop
            // 
            this.label_Lop.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Lop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(70)))), ((int)(((byte)(102)))));
            this.label_Lop.Location = new System.Drawing.Point(12, 120);
            this.label_Lop.Name = "label_Lop";
            this.label_Lop.Size = new System.Drawing.Size(100, 26);
            this.label_Lop.TabIndex = 5;
            this.label_Lop.Text = "Tên Lớp";
            this.label_Lop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_them
            // 
            this.btn_them.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btn_them.FlatAppearance.BorderSize = 0;
            this.btn_them.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_them.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_them.ForeColor = System.Drawing.Color.White;
            this.btn_them.Location = new System.Drawing.Point(3, 370);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(105, 42);
            this.btn_them.TabIndex = 8;
            this.btn_them.Text = "Thêm";
            this.btn_them.UseVisualStyleBackColor = false;
            // 
            // btn_sua
            // 
            this.btn_sua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btn_sua.FlatAppearance.BorderSize = 0;
            this.btn_sua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sua.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_sua.ForeColor = System.Drawing.Color.White;
            this.btn_sua.Location = new System.Drawing.Point(127, 370);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Size = new System.Drawing.Size(105, 42);
            this.btn_sua.TabIndex = 9;
            this.btn_sua.Text = "Sửa";
            this.btn_sua.UseVisualStyleBackColor = false;
            // 
            // btn_xoa
            // 
            this.btn_xoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btn_xoa.FlatAppearance.BorderSize = 0;
            this.btn_xoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_xoa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_xoa.ForeColor = System.Drawing.Color.White;
            this.btn_xoa.Location = new System.Drawing.Point(251, 370);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(105, 42);
            this.btn_xoa.TabIndex = 10;
            this.btn_xoa.Text = "Xóa";
            this.btn_xoa.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(70)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeight = 35;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_Column,
            this.Khoi_Column,
            this.Lop_Column});
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.dataGridView1.Location = new System.Drawing.Point(371, 54);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 30;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(488, 430);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellClick);
            // 
            // ID_Column
            // 
            this.ID_Column.HeaderText = "Mã Lớp";
            this.ID_Column.MinimumWidth = 8;
            this.ID_Column.Name = "ID_Column";
            this.ID_Column.Width = 150;
            // 
            // Khoi_Column
            // 
            this.Khoi_Column.HeaderText = "Khối";
            this.Khoi_Column.MinimumWidth = 8;
            this.Khoi_Column.Name = "Khoi_Column";
            this.Khoi_Column.Width = 150;
            // 
            // Lop_Column
            // 
            this.Lop_Column.HeaderText = "Tên Lớp";
            this.Lop_Column.MinimumWidth = 8;
            this.Lop_Column.Name = "Lop_Column";
            this.Lop_Column.Width = 150;
            // 
            // panel_Input
            // 
            this.panel_Input.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.panel_Input.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Input.Controls.Add(this.cbBoxGrade);
            this.panel_Input.Controls.Add(this.textMa);
            this.panel_Input.Controls.Add(this.textLop);
            this.panel_Input.Controls.Add(this.label_Ma);
            this.panel_Input.Controls.Add(this.btn_them);
            this.panel_Input.Controls.Add(this.btn_sua);
            this.panel_Input.Controls.Add(this.btn_xoa);
            this.panel_Input.Controls.Add(this.label_Lop);
            this.panel_Input.Controls.Add(this.label_Khoi);
            this.panel_Input.Location = new System.Drawing.Point(3, 54);
            this.panel_Input.Name = "panel_Input";
            this.panel_Input.Size = new System.Drawing.Size(362, 430);
            this.panel_Input.TabIndex = 12;
            // 
            // cbBoxGrade
            // 
            this.cbBoxGrade.BackColor = System.Drawing.Color.White;
            this.cbBoxGrade.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbBoxGrade.FormattingEnabled = true;
            this.cbBoxGrade.Location = new System.Drawing.Point(88, 65);
            this.cbBoxGrade.Name = "cbBoxGrade";
            this.cbBoxGrade.Size = new System.Drawing.Size(241, 28);
            this.cbBoxGrade.TabIndex = 13;
            // 
            // textMa
            // 
            this.textMa.BackColor = System.Drawing.Color.White;
            this.textMa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textMa.Location = new System.Drawing.Point(88, 120);
            this.textMa.Name = "textMa";
            this.textMa.Size = new System.Drawing.Size(241, 26);
            this.textMa.TabIndex = 12;
            // 
            // textLop
            // 
            this.textLop.BackColor = System.Drawing.Color.White;
            this.textLop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textLop.Location = new System.Drawing.Point(88, 13);
            this.textLop.Name = "textLop";
            this.textLop.Size = new System.Drawing.Size(241, 26);
            this.textLop.TabIndex = 11;
            // 
            // label_Title
            // 
            this.label_Title.AutoSize = true;
            this.label_Title.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(70)))), ((int)(((byte)(102)))));
            this.label_Title.Location = new System.Drawing.Point(3, 8);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(316, 45);
            this.label_Title.TabIndex = 16;
            this.label_Title.Text = "QUẢN LÝ KHỐI LỚP";
            // 
            // panel_Pagination
            // 
            this.panel_Pagination.BackColor = System.Drawing.Color.White;
            this.panel_Pagination.Controls.Add(this.lblpage);
            this.panel_Pagination.Controls.Add(this.btntail);
            this.panel_Pagination.Controls.Add(this.btnnext);
            this.panel_Pagination.Controls.Add(this.btnback);
            this.panel_Pagination.Controls.Add(this.btnhead);
            this.panel_Pagination.Location = new System.Drawing.Point(472, 490);
            this.panel_Pagination.Name = "panel_Pagination";
            this.panel_Pagination.Size = new System.Drawing.Size(387, 40);
            this.panel_Pagination.TabIndex = 17;
            // 
            // lblpage
            // 
            this.lblpage.AutoSize = true;
            this.lblpage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(70)))), ((int)(((byte)(102)))));
            this.lblpage.Location = new System.Drawing.Point(240, 4);
            this.lblpage.Name = "lblpage";
            this.lblpage.Size = new System.Drawing.Size(40, 25);
            this.lblpage.TabIndex = 6;
            this.lblpage.Text = "1/1";
            this.lblpage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btntail
            // 
            this.btntail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(103)))), ((int)(((byte)(174)))));
            this.btntail.FlatAppearance.BorderSize = 0;
            this.btntail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btntail.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntail.ForeColor = System.Drawing.Color.White;
            this.btntail.Location = new System.Drawing.Point(344, 3);
            this.btntail.Name = "btntail";
            this.btntail.Size = new System.Drawing.Size(40, 28);
            this.btntail.TabIndex = 3;
            this.btntail.Text = ">>";
            this.btntail.UseVisualStyleBackColor = false;
            // 
            // btnnext
            // 
            this.btnnext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(103)))), ((int)(((byte)(174)))));
            this.btnnext.FlatAppearance.BorderSize = 0;
            this.btnnext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnnext.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnnext.ForeColor = System.Drawing.Color.White;
            this.btnnext.Location = new System.Drawing.Point(298, 3);
            this.btnnext.Name = "btnnext";
            this.btnnext.Size = new System.Drawing.Size(40, 28);
            this.btnnext.TabIndex = 2;
            this.btnnext.Text = ">";
            this.btnnext.UseVisualStyleBackColor = false;
            // 
            // btnback
            // 
            this.btnback.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(103)))), ((int)(((byte)(174)))));
            this.btnback.FlatAppearance.BorderSize = 0;
            this.btnback.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnback.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnback.ForeColor = System.Drawing.Color.White;
            this.btnback.Location = new System.Drawing.Point(182, 4);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(40, 28);
            this.btnback.TabIndex = 1;
            this.btnback.Text = "<";
            this.btnback.UseVisualStyleBackColor = false;
            // 
            // btnhead
            // 
            this.btnhead.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(103)))), ((int)(((byte)(174)))));
            this.btnhead.FlatAppearance.BorderSize = 0;
            this.btnhead.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnhead.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnhead.ForeColor = System.Drawing.Color.White;
            this.btnhead.Location = new System.Drawing.Point(136, 4);
            this.btnhead.Name = "btnhead";
            this.btnhead.Size = new System.Drawing.Size(40, 28);
            this.btnhead.TabIndex = 0;
            this.btnhead.Text = "<<";
            this.btnhead.UseVisualStyleBackColor = false;
            // 
            // UC_Admin_Class_KhoiLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel_Pagination);
            this.Controls.Add(this.label_Title);
            this.Controls.Add(this.panel_Input);
            this.Controls.Add(this.dataGridView1);
            this.Name = "UC_Admin_Class_KhoiLop";
            this.Size = new System.Drawing.Size(918, 539);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel_Input.ResumeLayout(false);
            this.panel_Input.PerformLayout();
            this.panel_Pagination.ResumeLayout(false);
            this.panel_Pagination.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // Cập nhật tên biến ở đây để khớp với phần trên
        private System.Windows.Forms.Label label_Ma;
        private System.Windows.Forms.Label label_Khoi;
        private System.Windows.Forms.Label label_Lop;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.Button btn_sua;
        private System.Windows.Forms.Button btn_xoa;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn Khoi_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lop_Column;
        private System.Windows.Forms.Panel panel_Input;
        private System.Windows.Forms.TextBox textMa;
        private System.Windows.Forms.TextBox textLop;
        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.Panel panel_Pagination;
        private System.Windows.Forms.Button btntail;
        private System.Windows.Forms.Button btnnext;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.Button btnhead;
        private System.Windows.Forms.ComboBox cbBoxGrade;
        private System.Windows.Forms.Label lblpage;
    }
}