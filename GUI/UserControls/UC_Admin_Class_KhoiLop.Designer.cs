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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbBoxGrade = new System.Windows.Forms.ComboBox();
            this.textMa = new System.Windows.Forms.TextBox();
            this.textLop = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btntail = new System.Windows.Forms.Button();
            this.btnnext = new System.Windows.Forms.Button();
            this.btnback = new System.Windows.Forms.Button();
            this.btnhead = new System.Windows.Forms.Button();
            this.lblpage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 1;
            this.label4.Text = "Mã";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Khối";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Lớp";
            // 
            // btn_them
            // 
            this.btn_them.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btn_them.Location = new System.Drawing.Point(3, 364);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(75, 44);
            this.btn_them.TabIndex = 8;
            this.btn_them.Text = "Thêm";
            this.btn_them.UseVisualStyleBackColor = false;
            // 
            // btn_sua
            // 
            this.btn_sua.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btn_sua.Location = new System.Drawing.Point(141, 364);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Size = new System.Drawing.Size(75, 44);
            this.btn_sua.TabIndex = 9;
            this.btn_sua.Text = "Sửa";
            this.btn_sua.UseVisualStyleBackColor = false;
            // 
            // btn_xoa
            // 
            this.btn_xoa.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btn_xoa.Location = new System.Drawing.Point(254, 364);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(75, 44);
            this.btn_xoa.TabIndex = 10;
            this.btn_xoa.Text = "Xóa";
            this.btn_xoa.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeight = 34;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Khoi,
            this.Lop});
            this.dataGridView1.Location = new System.Drawing.Point(371, 54);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(514, 430);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellClick);
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
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cbBoxGrade);
            this.panel1.Controls.Add(this.textMa);
            this.panel1.Controls.Add(this.textLop);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btn_them);
            this.panel1.Controls.Add(this.btn_sua);
            this.panel1.Controls.Add(this.btn_xoa);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(362, 430);
            this.panel1.TabIndex = 12;
            // 
            // cbBoxGrade
            // 
            this.cbBoxGrade.FormattingEnabled = true;
            this.cbBoxGrade.Location = new System.Drawing.Point(88, 65);
            this.cbBoxGrade.Name = "cbBoxGrade";
            this.cbBoxGrade.Size = new System.Drawing.Size(241, 28);
            this.cbBoxGrade.TabIndex = 13;
            // 
            // textMa
            // 
            this.textMa.Location = new System.Drawing.Point(88, 120);
            this.textMa.Name = "textMa";
            this.textMa.Size = new System.Drawing.Size(241, 26);
            this.textMa.TabIndex = 12;
            // 
            // textLop
            // 
            this.textLop.Location = new System.Drawing.Point(88, 10);
            this.textLop.Name = "textLop";
            this.textLop.Size = new System.Drawing.Size(241, 26);
            this.textLop.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 25);
            this.label2.TabIndex = 16;
            this.label2.Text = "Quản Lý Khối Lớp";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblpage);
            this.panel2.Controls.Add(this.btntail);
            this.panel2.Controls.Add(this.btnnext);
            this.panel2.Controls.Add(this.btnback);
            this.panel2.Controls.Add(this.btnhead);
            this.panel2.Location = new System.Drawing.Point(383, 490);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(489, 37);
            this.panel2.TabIndex = 17;
            // 
            // btntail
            // 
            this.btntail.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btntail.Location = new System.Drawing.Point(400, 4);
            this.btntail.Name = "btntail";
            this.btntail.Size = new System.Drawing.Size(75, 28);
            this.btntail.TabIndex = 3;
            this.btntail.Text = ">>";
            this.btntail.UseVisualStyleBackColor = false;
            // 
            // btnnext
            // 
            this.btnnext.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnnext.Location = new System.Drawing.Point(319, 4);
            this.btnnext.Name = "btnnext";
            this.btnnext.Size = new System.Drawing.Size(75, 28);
            this.btnnext.TabIndex = 2;
            this.btnnext.Text = ">";
            this.btnnext.UseVisualStyleBackColor = false;
            // 
            // btnback
            // 
            this.btnback.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnback.Location = new System.Drawing.Point(95, 4);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(75, 28);
            this.btnback.TabIndex = 1;
            this.btnback.Text = "<";
            this.btnback.UseVisualStyleBackColor = false;
            // 
            // btnhead
            // 
            this.btnhead.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnhead.Location = new System.Drawing.Point(14, 4);
            this.btnhead.Name = "btnhead";
            this.btnhead.Size = new System.Drawing.Size(75, 28);
            this.btnhead.TabIndex = 0;
            this.btnhead.Text = "<<";
            this.btnhead.UseVisualStyleBackColor = false;
            // 
            // lblpage
            // 
            this.lblpage.AutoSize = true;
            this.lblpage.Location = new System.Drawing.Point(235, 8);
            this.lblpage.Name = "lblpage";
            this.lblpage.Size = new System.Drawing.Size(18, 20);
            this.lblpage.TabIndex = 6;
            this.lblpage.Text = "1";
            // 
            // UC_Admin_Class_KhoiLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "UC_Admin_Class_KhoiLop";
            this.Size = new System.Drawing.Size(918, 539);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private Label label4, label1, label3;
        private Button btn_them, btn_sua, btn_xoa;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Khoi;
        private DataGridViewTextBoxColumn Lop;
        private Panel panel1;
        private TextBox textMa;
        private TextBox textLop;
        private Label label2;
        private Panel panel2;
        private Button btntail;
        private Button btnnext;
        private Button btnback;
        private Button btnhead;
        private ComboBox cbBoxGrade;
        private Label lblpage;
    }
}
