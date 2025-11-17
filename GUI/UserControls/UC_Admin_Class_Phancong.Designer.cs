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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeight = 34;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Lop,
            this.Mon,
            this.GiaoVien,
            this.HocKi,
            this.Tiet});
            this.dataGridView1.Location = new System.Drawing.Point(314, 18);
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
            this.btnadd.Location = new System.Drawing.Point(13, 340);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(75, 23);
            this.btnadd.TabIndex = 1;
            this.btnadd.Text = "Thêm";
            this.btnadd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // btnsua
            // 
            this.btnsua.Location = new System.Drawing.Point(104, 340);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(75, 23);
            this.btnsua.TabIndex = 2;
            this.btnsua.Text = "Sửa";
            this.btnsua.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // btnxoa
            // 
            this.btnxoa.Location = new System.Drawing.Point(212, 340);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(75, 23);
            this.btnxoa.TabIndex = 3;
            this.btnxoa.Text = "Xóa";
            this.btnxoa.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(23, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Lớp";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(23, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Môn";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(23, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Giáo Viên";
            // 
            // comboBoxlop
            // 
            this.comboBoxlop.Location = new System.Drawing.Point(123, 41);
            this.comboBoxlop.Name = "comboBoxlop";
            this.comboBoxlop.Size = new System.Drawing.Size(164, 28);
            this.comboBoxlop.TabIndex = 7;
            // 
            // comboBoxmon
            // 
            this.comboBoxmon.Location = new System.Drawing.Point(123, 100);
            this.comboBoxmon.Name = "comboBoxmon";
            this.comboBoxmon.Size = new System.Drawing.Size(164, 28);
            this.comboBoxmon.TabIndex = 8;
            // 
            // comboBoxgv
            // 
            this.comboBoxgv.Location = new System.Drawing.Point(123, 163);
            this.comboBoxgv.Name = "comboBoxgv";
            this.comboBoxgv.Size = new System.Drawing.Size(164, 28);
            this.comboBoxgv.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(23, 261);
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
            this.comboBoxtiet.Location = new System.Drawing.Point(123, 258);
            this.comboBoxtiet.Name = "comboBoxtiet";
            this.comboBoxtiet.Size = new System.Drawing.Size(164, 28);
            this.comboBoxtiet.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(23, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 12;
            this.label5.Text = "HocKI";
            // 
            // comboBoxhk
            // 
            this.comboBoxhk.Location = new System.Drawing.Point(123, 211);
            this.comboBoxhk.Name = "comboBoxhk";
            this.comboBoxhk.Size = new System.Drawing.Size(164, 28);
            this.comboBoxhk.TabIndex = 13;
            // 
            // UC_Admin_Class_Phancong
            // 
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxhk);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxtiet);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.btnsua);
            this.Controls.Add(this.btnxoa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxlop);
            this.Controls.Add(this.comboBoxmon);
            this.Controls.Add(this.comboBoxgv);
            this.Name = "UC_Admin_Class_Phancong";
            this.Size = new System.Drawing.Size(1146, 486);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

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
    }
}
