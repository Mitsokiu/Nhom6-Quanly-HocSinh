namespace GUI.UserControls
{
    partial class UC_Admin_Class_Phancong
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnadd; // Thêm
        private System.Windows.Forms.Button btnsua; // Sửa
        private System.Windows.Forms.Button btnxoa; // Xóa
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxlop; // Lớp
        private System.Windows.Forms.ComboBox comboBoxmon; // Môn
        private System.Windows.Forms.ComboBox comboBoxgv; // Giáo viên

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Lop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaoVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HocKi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tiet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnadd = new System.Windows.Forms.Button();
            this.btnsua = new System.Windows.Forms.Button();
            this.btnxoa = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxlop = new System.Windows.Forms.ComboBox();
            this.comboBoxmon = new System.Windows.Forms.ComboBox();
            this.comboBoxgv = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxtiet = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxhk = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtnumber = new System.Windows.Forms.TextBox();
            this.btntail = new System.Windows.Forms.Button();
            this.btnnext = new System.Windows.Forms.Button();
            this.btnback = new System.Windows.Forms.Button();
            this.btnhead = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeight = 34;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Lop,
            this.Mon,
            this.GiaoVien,
            this.HocKi,
            this.Tiet});
            this.dataGridView1.Location = new System.Drawing.Point(321, 92);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(822, 389);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // Lop
            // 
            this.Lop.HeaderText = "Lớp";
            this.Lop.MinimumWidth = 8;
            this.Lop.Name = "Lop";
            this.Lop.Width = 150;
            // 
            // Mon
            // 
            this.Mon.HeaderText = "Môn";
            this.Mon.MinimumWidth = 8;
            this.Mon.Name = "Mon";
            this.Mon.Width = 150;
            // 
            // GiaoVien
            // 
            this.GiaoVien.HeaderText = "Giáo Viên";
            this.GiaoVien.MinimumWidth = 8;
            this.GiaoVien.Name = "GiaoVien";
            this.GiaoVien.Width = 150;
            // 
            // HocKi
            // 
            this.HocKi.HeaderText = "Học Kì";
            this.HocKi.MinimumWidth = 8;
            this.HocKi.Name = "HocKi";
            this.HocKi.Width = 150;
            // 
            // Tiet
            // 
            this.Tiet.HeaderText = "Tiết";
            this.Tiet.MinimumWidth = 8;
            this.Tiet.Name = "Tiet";
            this.Tiet.Width = 150;
            // 
            // btnadd
            // 
            this.btnadd.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnadd.Location = new System.Drawing.Point(20, 323);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(75, 45);
            this.btnadd.TabIndex = 1;
            this.btnadd.Text = "Thêm";
            this.btnadd.UseVisualStyleBackColor = false;
            this.btnadd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // btnsua
            // 
            this.btnsua.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnsua.Location = new System.Drawing.Point(111, 323);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(75, 45);
            this.btnsua.TabIndex = 2;
            this.btnsua.Text = "Sửa";
            this.btnsua.UseVisualStyleBackColor = false;
            this.btnsua.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // btnxoa
            // 
            this.btnxoa.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnxoa.Location = new System.Drawing.Point(192, 323);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(75, 45);
            this.btnxoa.TabIndex = 3;
            this.btnxoa.Text = "Xóa";
            this.btnxoa.UseVisualStyleBackColor = false;
            this.btnxoa.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Lớp";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Môn";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Giáo Viên";
            // 
            // comboBoxlop
            // 
            this.comboBoxlop.Location = new System.Drawing.Point(116, 12);
            this.comboBoxlop.Name = "comboBoxlop";
            this.comboBoxlop.Size = new System.Drawing.Size(164, 28);
            this.comboBoxlop.TabIndex = 7;
            // 
            // comboBoxmon
            // 
            this.comboBoxmon.Location = new System.Drawing.Point(116, 71);
            this.comboBoxmon.Name = "comboBoxmon";
            this.comboBoxmon.Size = new System.Drawing.Size(164, 28);
            this.comboBoxmon.TabIndex = 8;
            // 
            // comboBoxgv
            // 
            this.comboBoxgv.Location = new System.Drawing.Point(116, 134);
            this.comboBoxgv.Name = "comboBoxgv";
            this.comboBoxgv.Size = new System.Drawing.Size(164, 28);
            this.comboBoxgv.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 232);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 10;
            this.label3.Text = "Tiết";
            // 
            // comboBoxtiet
            // 
            this.comboBoxtiet.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.comboBoxtiet.Location = new System.Drawing.Point(116, 229);
            this.comboBoxtiet.Name = "comboBoxtiet";
            this.comboBoxtiet.Size = new System.Drawing.Size(164, 28);
            this.comboBoxtiet.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 12;
            this.label5.Text = "HocKI";
            // 
            // comboBoxhk
            // 
            this.comboBoxhk.Location = new System.Drawing.Point(116, 182);
            this.comboBoxhk.Name = "comboBoxhk";
            this.comboBoxhk.Size = new System.Drawing.Size(164, 28);
            this.comboBoxhk.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(227, 25);
            this.label6.TabIndex = 18;
            this.label6.Text = "Phân Công Giảng Dạy";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comboBoxgv);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnadd);
            this.panel1.Controls.Add(this.btnsua);
            this.panel1.Controls.Add(this.comboBoxmon);
            this.panel1.Controls.Add(this.btnxoa);
            this.panel1.Controls.Add(this.comboBoxhk);
            this.panel1.Controls.Add(this.comboBoxlop);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.comboBoxtiet);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(3, 92);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(312, 389);
            this.panel1.TabIndex = 19;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtnumber);
            this.panel2.Controls.Add(this.btntail);
            this.panel2.Controls.Add(this.btnnext);
            this.panel2.Controls.Add(this.btnback);
            this.panel2.Controls.Add(this.btnhead);
            this.panel2.Location = new System.Drawing.Point(492, 487);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(488, 40);
            this.panel2.TabIndex = 20;
            // 
            // txtnumber
            // 
            this.txtnumber.Location = new System.Drawing.Point(194, 5);
            this.txtnumber.Name = "txtnumber";
            this.txtnumber.Size = new System.Drawing.Size(100, 26);
            this.txtnumber.TabIndex = 4;
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
            // UC_Admin_Class_Phancong
            // 
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataGridView1);
            this.Name = "UC_Admin_Class_Phancong";
            this.Size = new System.Drawing.Size(1146, 548);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxtiet;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lop;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mon;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaoVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn HocKi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tiet;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxhk;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtnumber;
        private System.Windows.Forms.Button btntail;
        private System.Windows.Forms.Button btnnext;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.Button btnhead;
    }
}
