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
            this.labelGrade = new System.Windows.Forms.Label();
            this.cbBoxYear = new System.Windows.Forms.ComboBox();
            this.cbBoxGrade = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtAddr = new System.Windows.Forms.TextBox();
            this.cbBoxClass = new System.Windows.Forms.ComboBox();
            this.cbBoxGender = new System.Windows.Forms.ComboBox();
            this.dateTimePickerDOB = new System.Windows.Forms.DateTimePicker();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btntail = new System.Windows.Forms.Button();
            this.btnnext = new System.Windows.Forms.Button();
            this.btnback = new System.Windows.Forms.Button();
            this.btnhead = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lblpage = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Location = new System.Drawing.Point(363, 51);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(952, 545);
            this.panel2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Hoten,
            this.DOB,
            this.Gender,
            this.DiaChi,
            this.Class});
            this.dataGridView1.Location = new System.Drawing.Point(4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(922, 538);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "id";
            this.ID.MinimumWidth = 8;
            this.ID.Name = "ID";
            this.ID.Width = 150;
            // 
            // Hoten
            // 
            this.Hoten.HeaderText = "Tên";
            this.Hoten.MinimumWidth = 8;
            this.Hoten.Name = "Hoten";
            this.Hoten.Width = 150;
            // 
            // DOB
            // 
            this.DOB.HeaderText = "Ngày Sinh";
            this.DOB.MinimumWidth = 8;
            this.DOB.Name = "DOB";
            this.DOB.Width = 150;
            // 
            // Gender
            // 
            this.Gender.HeaderText = "Giới Tính";
            this.Gender.MinimumWidth = 8;
            this.Gender.Name = "Gender";
            this.Gender.Width = 150;
            // 
            // DiaChi
            // 
            this.DiaChi.HeaderText = "Địa chỉ";
            this.DiaChi.MinimumWidth = 8;
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.Width = 150;
            // 
            // Class
            // 
            this.Class.HeaderText = "Class";
            this.Class.MinimumWidth = 8;
            this.Class.Name = "Class";
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
            this.labelName.Location = new System.Drawing.Point(14, 91);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(36, 20);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Tên";
            // 
            // labelDOB
            // 
            this.labelDOB.AutoSize = true;
            this.labelDOB.Location = new System.Drawing.Point(14, 149);
            this.labelDOB.Name = "labelDOB";
            this.labelDOB.Size = new System.Drawing.Size(81, 20);
            this.labelDOB.TabIndex = 2;
            this.labelDOB.Text = "Ngày Sinh";
            // 
            // labelGender
            // 
            this.labelGender.AutoSize = true;
            this.labelGender.Location = new System.Drawing.Point(13, 209);
            this.labelGender.Name = "labelGender";
            this.labelGender.Size = new System.Drawing.Size(71, 20);
            this.labelGender.TabIndex = 3;
            this.labelGender.Text = "Giới Tính";
            // 
            // labelAddr
            // 
            this.labelAddr.AutoSize = true;
            this.labelAddr.Location = new System.Drawing.Point(14, 246);
            this.labelAddr.Name = "labelAddr";
            this.labelAddr.Size = new System.Drawing.Size(60, 20);
            this.labelAddr.TabIndex = 4;
            this.labelAddr.Text = "Địa Chỉ";
            // 
            // labelClass
            // 
            this.labelClass.AutoSize = true;
            this.labelClass.Location = new System.Drawing.Point(14, 297);
            this.labelClass.Name = "labelClass";
            this.labelClass.Size = new System.Drawing.Size(36, 20);
            this.labelClass.TabIndex = 5;
            this.labelClass.Text = "Lớp";
            this.labelClass.Click += new System.EventHandler(this.label6_Click);
            // 
            // labelYear
            // 
            this.labelYear.AutoSize = true;
            this.labelYear.Location = new System.Drawing.Point(13, 4);
            this.labelYear.Name = "labelYear";
            this.labelYear.Size = new System.Drawing.Size(82, 20);
            this.labelYear.TabIndex = 6;
            this.labelYear.Text = "Niên Khóa";
            // 
            // labelGrade
            // 
            this.labelGrade.AutoSize = true;
            this.labelGrade.Location = new System.Drawing.Point(14, 48);
            this.labelGrade.Name = "labelGrade";
            this.labelGrade.Size = new System.Drawing.Size(40, 20);
            this.labelGrade.TabIndex = 7;
            this.labelGrade.Text = "Khối";
            // 
            // cbBoxYear
            // 
            this.cbBoxYear.FormattingEnabled = true;
            this.cbBoxYear.Location = new System.Drawing.Point(127, 4);
            this.cbBoxYear.Name = "cbBoxYear";
            this.cbBoxYear.Size = new System.Drawing.Size(196, 28);
            this.cbBoxYear.TabIndex = 8;
            this.cbBoxYear.SelectedIndexChanged += new System.EventHandler(this.cbBoxYear_SelectedIndexChanged);
            // 
            // cbBoxGrade
            // 
            this.cbBoxGrade.FormattingEnabled = true;
            this.cbBoxGrade.Location = new System.Drawing.Point(127, 48);
            this.cbBoxGrade.Name = "cbBoxGrade";
            this.cbBoxGrade.Size = new System.Drawing.Size(196, 28);
            this.cbBoxGrade.TabIndex = 9;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(123, 91);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 26);
            this.txtName.TabIndex = 11;
            // 
            // txtAddr
            // 
            this.txtAddr.Location = new System.Drawing.Point(123, 246);
            this.txtAddr.Name = "txtAddr";
            this.txtAddr.Size = new System.Drawing.Size(200, 26);
            this.txtAddr.TabIndex = 12;
            // 
            // cbBoxClass
            // 
            this.cbBoxClass.FormattingEnabled = true;
            this.cbBoxClass.Location = new System.Drawing.Point(123, 297);
            this.cbBoxClass.Name = "cbBoxClass";
            this.cbBoxClass.Size = new System.Drawing.Size(200, 28);
            this.cbBoxClass.TabIndex = 13;
            // 
            // cbBoxGender
            // 
            this.cbBoxGender.FormattingEnabled = true;
            this.cbBoxGender.Items.AddRange(new object[] {
            "Male",
            "FeMale"});
            this.cbBoxGender.Location = new System.Drawing.Point(123, 209);
            this.cbBoxGender.Name = "cbBoxGender";
            this.cbBoxGender.Size = new System.Drawing.Size(200, 28);
            this.cbBoxGender.TabIndex = 14;
            // 
            // dateTimePickerDOB
            // 
            this.dateTimePickerDOB.Location = new System.Drawing.Point(123, 149);
            this.dateTimePickerDOB.Name = "dateTimePickerDOB";
            this.dateTimePickerDOB.Size = new System.Drawing.Size(200, 26);
            this.dateTimePickerDOB.TabIndex = 15;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnUpdate.Location = new System.Drawing.Point(99, 390);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(95, 52);
            this.btnUpdate.TabIndex = 16;
            this.btnUpdate.Text = "Lưu";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.dateTimePickerDOB);
            this.panel1.Controls.Add(this.cbBoxGender);
            this.panel1.Controls.Add(this.cbBoxClass);
            this.panel1.Controls.Add(this.txtAddr);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.cbBoxGrade);
            this.panel1.Controls.Add(this.cbBoxYear);
            this.panel1.Controls.Add(this.labelGrade);
            this.panel1.Controls.Add(this.labelYear);
            this.panel1.Controls.Add(this.labelClass);
            this.panel1.Controls.Add(this.labelAddr);
            this.panel1.Controls.Add(this.labelGender);
            this.panel1.Controls.Add(this.labelDOB);
            this.panel1.Controls.Add(this.labelName);
            this.panel1.Location = new System.Drawing.Point(7, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(349, 545);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblpage);
            this.panel3.Controls.Add(this.btntail);
            this.panel3.Controls.Add(this.btnnext);
            this.panel3.Controls.Add(this.btnback);
            this.panel3.Controls.Add(this.btnhead);
            this.panel3.Location = new System.Drawing.Point(559, 599);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(488, 40);
            this.panel3.TabIndex = 17;
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(188, 25);
            this.label6.TabIndex = 20;
            this.label6.Text = "Quản Lý Học Sinh";
            // 
            // lblpage
            // 
            this.lblpage.AutoSize = true;
            this.lblpage.Location = new System.Drawing.Point(235, 10);
            this.lblpage.Name = "lblpage";
            this.lblpage.Size = new System.Drawing.Size(18, 20);
            this.lblpage.TabIndex = 6;
            this.lblpage.Text = "1";
            // 
            // UC_Admin_Student
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelDOB;
        private System.Windows.Forms.Label labelGender;
        private System.Windows.Forms.Label labelAddr;
        private System.Windows.Forms.Label labelClass;
        private System.Windows.Forms.Label labelYear;
        private System.Windows.Forms.Label labelGrade;
        private System.Windows.Forms.ComboBox cbBoxYear;
        private System.Windows.Forms.ComboBox cbBoxGrade;
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
    }
}
