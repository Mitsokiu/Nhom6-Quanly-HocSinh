namespace GUI.UserControls
{
    partial class UC_Admin_Student
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hoten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DOB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Class = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.labelName = new System.Windows.Forms.Label();
            this.labelDOB = new System.Windows.Forms.Label();
            this.labelGender = new System.Windows.Forms.Label();
            this.labelAddr = new System.Windows.Forms.Label();
            this.labelClass = new System.Windows.Forms.Label();
            this.labelYear = new System.Windows.Forms.Label();
            this.cbBoxYear = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtAddr = new System.Windows.Forms.TextBox();
            this.cbBoxClass = new System.Windows.Forms.ComboBox();
            this.cbBoxGender = new System.Windows.Forms.ComboBox();
            this.dateTimePickerDOB = new System.Windows.Forms.DateTimePicker();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnxuat = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblpage = new System.Windows.Forms.Label();
            this.btntail = new System.Windows.Forms.Button();
            this.btnnext = new System.Windows.Forms.Button();
            this.btnback = new System.Windows.Forms.Button();
            this.btnhead = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnDetail = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Location = new System.Drawing.Point(363, 68);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(867, 528);
            this.panel2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(70)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Hoten,
            this.DOB,
            this.Gender,
            this.DiaChi,
            this.Class});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(867, 528);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 8;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            this.ID.Width = 80;
            // 
            // Hoten
            // 
            this.Hoten.HeaderText = "Tên";
            this.Hoten.MinimumWidth = 8;
            this.Hoten.Name = "Hoten";
            this.Hoten.ReadOnly = true;
            this.Hoten.Width = 150;
            // 
            // DOB
            // 
            this.DOB.HeaderText = "Ngày Sinh";
            this.DOB.MinimumWidth = 8;
            this.DOB.Name = "DOB";
            this.DOB.ReadOnly = true;
            this.DOB.Width = 150;
            // 
            // Gender
            // 
            this.Gender.HeaderText = "Giới Tính";
            this.Gender.MinimumWidth = 8;
            this.Gender.Name = "Gender";
            this.Gender.ReadOnly = true;
            this.Gender.Width = 150;
            // 
            // DiaChi
            // 
            this.DiaChi.HeaderText = "Địa chỉ";
            this.DiaChi.MinimumWidth = 8;
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.ReadOnly = true;
            this.DiaChi.Width = 200;
            // 
            // Class
            // 
            this.Class.HeaderText = "Lớp";
            this.Class.MinimumWidth = 8;
            this.Class.Name = "Class";
            this.Class.ReadOnly = true;
            this.Class.Width = 150;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.labelName.Location = new System.Drawing.Point(14, 82);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(42, 22);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Tên";
            // 
            // labelDOB
            // 
            this.labelDOB.AutoSize = true;
            this.labelDOB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDOB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.labelDOB.Location = new System.Drawing.Point(14, 137);
            this.labelDOB.Name = "labelDOB";
            this.labelDOB.Size = new System.Drawing.Size(93, 22);
            this.labelDOB.TabIndex = 2;
            this.labelDOB.Text = "Ngày Sinh";
            // 
            // labelGender
            // 
            this.labelGender.AutoSize = true;
            this.labelGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGender.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.labelGender.Location = new System.Drawing.Point(13, 192);
            this.labelGender.Name = "labelGender";
            this.labelGender.Size = new System.Drawing.Size(83, 22);
            this.labelGender.TabIndex = 3;
            this.labelGender.Text = "Giới Tính";
            // 
            // labelAddr
            // 
            this.labelAddr.AutoSize = true;
            this.labelAddr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAddr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.labelAddr.Location = new System.Drawing.Point(14, 247);
            this.labelAddr.Name = "labelAddr";
            this.labelAddr.Size = new System.Drawing.Size(69, 22);
            this.labelAddr.TabIndex = 4;
            this.labelAddr.Text = "Địa Chỉ";
            // 
            // labelClass
            // 
            this.labelClass.AutoSize = true;
            this.labelClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.labelClass.Location = new System.Drawing.Point(14, 302);
            this.labelClass.Name = "labelClass";
            this.labelClass.Size = new System.Drawing.Size(40, 22);
            this.labelClass.TabIndex = 5;
            this.labelClass.Text = "Lớp";
            // 
            // labelYear
            // 
            this.labelYear.AutoSize = true;
            this.labelYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.labelYear.Location = new System.Drawing.Point(13, 27);
            this.labelYear.Name = "labelYear";
            this.labelYear.Size = new System.Drawing.Size(94, 22);
            this.labelYear.TabIndex = 6;
            this.labelYear.Text = "Niên Khóa";
            // 
            // cbBoxYear
            // 
            this.cbBoxYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBoxYear.FormattingEnabled = true;
            this.cbBoxYear.Location = new System.Drawing.Point(127, 24);
            this.cbBoxYear.Name = "cbBoxYear";
            this.cbBoxYear.Size = new System.Drawing.Size(196, 28);
            this.cbBoxYear.TabIndex = 8;
            this.cbBoxYear.SelectedIndexChanged += new System.EventHandler(this.cbBoxYear_SelectedIndexChanged);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(123, 80);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 26);
            this.txtName.TabIndex = 11;
            // 
            // txtAddr
            // 
            this.txtAddr.Location = new System.Drawing.Point(123, 245);
            this.txtAddr.Name = "txtAddr";
            this.txtAddr.Size = new System.Drawing.Size(200, 26);
            this.txtAddr.TabIndex = 12;
            // 
            // cbBoxClass
            // 
            this.cbBoxClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBoxClass.FormattingEnabled = true;
            this.cbBoxClass.Location = new System.Drawing.Point(123, 299);
            this.cbBoxClass.Name = "cbBoxClass";
            this.cbBoxClass.Size = new System.Drawing.Size(200, 28);
            this.cbBoxClass.TabIndex = 13;
            // 
            // cbBoxGender
            // 
            this.cbBoxGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBoxGender.FormattingEnabled = true;
            this.cbBoxGender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cbBoxGender.Location = new System.Drawing.Point(123, 190);
            this.cbBoxGender.Name = "cbBoxGender";
            this.cbBoxGender.Size = new System.Drawing.Size(200, 28);
            this.cbBoxGender.TabIndex = 14;
            // 
            // dateTimePickerDOB
            // 
            this.dateTimePickerDOB.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDOB.Location = new System.Drawing.Point(123, 137);
            this.dateTimePickerDOB.Name = "dateTimePickerDOB";
            this.dateTimePickerDOB.Size = new System.Drawing.Size(200, 26);
            this.dateTimePickerDOB.TabIndex = 15;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(3, 406);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(120, 49);
            this.btnUpdate.TabIndex = 16;
            this.btnUpdate.Text = "💾 Lưu";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnDetail);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.dateTimePickerDOB);
            this.panel1.Controls.Add(this.cbBoxGender);
            this.panel1.Controls.Add(this.cbBoxClass);
            this.panel1.Controls.Add(this.txtAddr);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.cbBoxYear);
            this.panel1.Controls.Add(this.labelYear);
            this.panel1.Controls.Add(this.labelClass);
            this.panel1.Controls.Add(this.labelAddr);
            this.panel1.Controls.Add(this.labelGender);
            this.panel1.Controls.Add(this.labelDOB);
            this.panel1.Controls.Add(this.labelName);
            this.panel1.Location = new System.Drawing.Point(7, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(349, 528);
            this.panel1.TabIndex = 0;
            // 
            // btnxuat
            // 
            this.btnxuat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(193)))), ((int)(((byte)(214)))));
            this.btnxuat.FlatAppearance.BorderSize = 0;
            this.btnxuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnxuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnxuat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(70)))), ((int)(((byte)(102)))));
            this.btnxuat.Location = new System.Drawing.Point(1097, 14);
            this.btnxuat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnxuat.Name = "btnxuat";
            this.btnxuat.Size = new System.Drawing.Size(133, 49);
            this.btnxuat.TabIndex = 19;
            this.btnxuat.Text = "📊 Xuất Excel";
            this.btnxuat.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblpage);
            this.panel3.Controls.Add(this.btntail);
            this.panel3.Controls.Add(this.btnnext);
            this.panel3.Controls.Add(this.btnback);
            this.panel3.Controls.Add(this.btnhead);
            this.panel3.Location = new System.Drawing.Point(742, 602);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(488, 40);
            this.panel3.TabIndex = 17;
            // 
            // lblpage
            // 
            this.lblpage.AutoSize = true;
            this.lblpage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(103)))), ((int)(((byte)(174)))));
            this.lblpage.Location = new System.Drawing.Point(203, 10);
            this.lblpage.Name = "lblpage";
            this.lblpage.Size = new System.Drawing.Size(97, 22);
            this.lblpage.TabIndex = 6;
            this.lblpage.Text = "Trang 1/1";
            // 
            // btntail
            // 
            this.btntail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(103)))), ((int)(((byte)(174)))));
            this.btntail.FlatAppearance.BorderSize = 0;
            this.btntail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btntail.Location = new System.Drawing.Point(400, 6);
            this.btntail.Name = "btntail";
            this.btntail.Size = new System.Drawing.Size(75, 28);
            this.btntail.TabIndex = 3;
            this.btntail.Text = ">>";
            this.btntail.UseVisualStyleBackColor = false;
            this.btntail.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnnext
            // 
            this.btnnext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(103)))), ((int)(((byte)(174)))));
            this.btnnext.FlatAppearance.BorderSize = 0;
            this.btnnext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnnext.Location = new System.Drawing.Point(319, 4);
            this.btnnext.Name = "btnnext";
            this.btnnext.Size = new System.Drawing.Size(75, 28);
            this.btnnext.TabIndex = 2;
            this.btnnext.Text = ">";
            this.btnnext.UseVisualStyleBackColor = false;
            this.btnnext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnback
            // 
            this.btnback.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(103)))), ((int)(((byte)(174)))));
            this.btnback.FlatAppearance.BorderSize = 0;
            this.btnback.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnback.Location = new System.Drawing.Point(95, 4);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(75, 28);
            this.btnback.TabIndex = 1;
            this.btnback.Text = "<";
            this.btnback.UseVisualStyleBackColor = false;
            this.btnback.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnhead
            // 
            this.btnhead.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(103)))), ((int)(((byte)(174)))));
            this.btnhead.FlatAppearance.BorderSize = 0;
            this.btnhead.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnhead.Location = new System.Drawing.Point(14, 4);
            this.btnhead.Name = "btnhead";
            this.btnhead.Size = new System.Drawing.Size(75, 28);
            this.btnhead.TabIndex = 0;
            this.btnhead.Text = "<<";
            this.btnhead.UseVisualStyleBackColor = false;
            this.btnhead.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(70)))), ((int)(((byte)(102)))));
            this.label6.Location = new System.Drawing.Point(3, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(295, 32);
            this.label6.TabIndex = 20;
            this.label6.Text = "QUẢN LÝ HỌC SINH";
            // 
            // btnDetail
            // 
            this.btnDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnDetail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetail.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDetail.Location = new System.Drawing.Point(160, 406);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(114, 49);
            this.btnDetail.TabIndex = 17;
            this.btnDetail.Text = "Chi Tiết";
            this.btnDetail.UseVisualStyleBackColor = false;
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // UC_Admin_Student
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.btnxuat);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "UC_Admin_Student";
            this.Size = new System.Drawing.Size(1299, 732);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        // ... (Giữ nguyên các khai báo components ở cuối file)
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelDOB;
        private System.Windows.Forms.Label labelGender;
        private System.Windows.Forms.Label labelAddr;
        private System.Windows.Forms.Label labelClass;
        private System.Windows.Forms.Label labelYear;
        private System.Windows.Forms.ComboBox cbBoxYear;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtAddr;
        private System.Windows.Forms.ComboBox cbBoxClass;
        private System.Windows.Forms.ComboBox cbBoxGender;
        private System.Windows.Forms.DateTimePicker dateTimePickerDOB;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hoten;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOB;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Class;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btntail;
        private System.Windows.Forms.Button btnnext;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.Button btnhead;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblpage;
        private System.Windows.Forms.Button btnxuat;
        private System.Windows.Forms.Button btnDetail;
    }
}