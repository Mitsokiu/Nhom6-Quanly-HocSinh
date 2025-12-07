namespace GUI.UserControls.Admin
{
    partial class UC_Admin_QuanLyLopHoc
    {
        private System.ComponentModel.IContainer components = null;

        // Controls
        private System.Windows.Forms.Label lblTitle;

        // --- CỤM TÌM KIẾM MỚI ---
        private System.Windows.Forms.Panel pnlSearch;      // Panel bao ngoài
        private System.Windows.Forms.PictureBox pbSearch;  // Icon kính lúp
        private System.Windows.Forms.TextBox txtSearch;    // Ô nhập liệu (nằm trong Panel)
        // ------------------------

        private System.Windows.Forms.DataGridView dgvClass;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Label lblInfoTitle;

        // Form Inputs
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblGrade;
        private System.Windows.Forms.ComboBox cbGrade; // Combobox chọn Khối

        // Buttons
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();

            // Khởi tạo các control tìm kiếm mới
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.pbSearch = new System.Windows.Forms.PictureBox();
            this.txtSearch = new System.Windows.Forms.TextBox();

            this.dgvClass = new System.Windows.Forms.DataGridView();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cbGrade = new System.Windows.Forms.ComboBox();
            this.lblGrade = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.lblInfoTitle = new System.Windows.Forms.Label();

            // Bắt đầu Init
            ((System.ComponentModel.ISupportInitialize)(this.dgvClass)).BeginInit();
            this.pnlRight.SuspendLayout();
            this.pnlSearch.SuspendLayout(); // Suspend layout cho Panel tìm kiếm
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).BeginInit(); // Init cho PictureBox
            this.SuspendLayout();

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(326, 54);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Quản lý Lớp học";

            // 
            // --- CẤU HÌNH CỤM TÌM KIẾM ---
            // 

            // 1. pnlSearch (Khung bao ngoài)
            this.pnlSearch.BackColor = System.Drawing.Color.White;
            this.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSearch.Controls.Add(this.txtSearch); // Thêm TextBox vào Panel
            this.pnlSearch.Controls.Add(this.pbSearch);  // Thêm Icon vào Panel
            this.pnlSearch.Location = new System.Drawing.Point(28, 80);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Padding = new System.Windows.Forms.Padding(5, 10, 5, 5); // Căn lề để text nằm giữa
            this.pnlSearch.Size = new System.Drawing.Size(420, 45); // Kích thước to hơn (Rộng 420, Cao 45)
            this.pnlSearch.TabIndex = 1;

            // 2. pbSearch (Icon kính lúp)
            this.pbSearch.Dock = System.Windows.Forms.DockStyle.Right; // Dính sang phải
            this.pbSearch.Image = global::GUI.Properties.Resources.timkiem_24; // Đảm bảo bạn có resource này
            this.pbSearch.Location = new System.Drawing.Point(378, 0);
            this.pbSearch.Name = "pbSearch";
            this.pbSearch.Size = new System.Drawing.Size(40, 43); // Kích thước icon
            this.pbSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbSearch.TabIndex = 1;
            this.pbSearch.TabStop = false;

            // 3. txtSearch (Ô nhập liệu)
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None; // Bỏ viền
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill; // Lấp đầy phần còn lại
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtSearch.Location = new System.Drawing.Point(10, 10); // Vị trí (phụ thuộc padding của panel)
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(360, 27);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            // 
            // dgvClass
            // 
            this.dgvClass.AllowUserToAddRows = false;
            this.dgvClass.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClass.BackgroundColor = System.Drawing.Color.White;
            this.dgvClass.ColumnHeadersHeight = 40;
            this.dgvClass.Location = new System.Drawing.Point(28, 140); // Đẩy xuống một chút vì thanh tìm kiếm to ra
            this.dgvClass.Name = "dgvClass";
            this.dgvClass.ReadOnly = true;
            this.dgvClass.RowHeadersWidth = 51;
            this.dgvClass.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClass.Size = new System.Drawing.Size(650, 490);
            this.dgvClass.TabIndex = 2;
            this.dgvClass.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClass_CellClick);

            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.White;
            this.pnlRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRight.Controls.Add(this.btnDelete);
            this.pnlRight.Controls.Add(this.btnEdit);
            this.pnlRight.Controls.Add(this.btnAdd);
            this.pnlRight.Controls.Add(this.cbGrade);
            this.pnlRight.Controls.Add(this.lblGrade);
            this.pnlRight.Controls.Add(this.txtName);
            this.pnlRight.Controls.Add(this.lblName);
            this.pnlRight.Controls.Add(this.txtID);
            this.pnlRight.Controls.Add(this.lblID);
            this.pnlRight.Controls.Add(this.lblInfoTitle);
            this.pnlRight.Location = new System.Drawing.Point(700, 140); // Đẩy xuống khớp với DGV
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(300, 438);
            this.pnlRight.TabIndex = 3;

            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.Color.Red;
            this.btnDelete.Location = new System.Drawing.Point(20, 370);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(260, 40);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = " Xóa";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(231)))), ((int)(((byte)(255)))));
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.ForeColor = System.Drawing.Color.Black;
            this.btnEdit.Location = new System.Drawing.Point(20, 320);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(260, 40);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = " Cập nhật";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(20, 270);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(260, 40);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = " Thêm";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // 
            // cbGrade
            // 
            this.cbGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGrade.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cbGrade.Location = new System.Drawing.Point(20, 215);
            this.cbGrade.Name = "cbGrade";
            this.cbGrade.Size = new System.Drawing.Size(260, 33);
            this.cbGrade.TabIndex = 3;

            // 
            // lblGrade
            // 
            this.lblGrade.Location = new System.Drawing.Point(20, 190);
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Size = new System.Drawing.Size(100, 23);
            this.lblGrade.TabIndex = 4;
            this.lblGrade.Text = "Thuộc Khối";

            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtName.Location = new System.Drawing.Point(20, 150);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(260, 32);
            this.txtName.TabIndex = 5;

            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(20, 125);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(100, 23);
            this.lblName.TabIndex = 6;
            this.lblName.Text = "Tên lớp";

            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtID.Location = new System.Drawing.Point(20, 85);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(260, 32);
            this.txtID.TabIndex = 7;

            // 
            // lblID
            // 
            this.lblID.Location = new System.Drawing.Point(20, 60);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(100, 23);
            this.lblID.TabIndex = 8;
            this.lblID.Text = "Mã lớp";

            // 
            // lblInfoTitle
            // 
            this.lblInfoTitle.AutoSize = true;
            this.lblInfoTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblInfoTitle.Location = new System.Drawing.Point(15, 15);
            this.lblInfoTitle.Name = "lblInfoTitle";
            this.lblInfoTitle.Size = new System.Drawing.Size(249, 37);
            this.lblInfoTitle.TabIndex = 9;
            this.lblInfoTitle.Text = "Thông tin Lớp học";

            // 
            // UC_Admin_QuanLyLopHoc
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.lblTitle);

            // Thay vì add txtSearch, ta add pnlSearch (đã chứa txtSearch và icon)
            this.Controls.Add(this.pnlSearch);

            this.Controls.Add(this.dgvClass);
            this.Controls.Add(this.pnlRight);
            this.Name = "UC_Admin_QuanLyLopHoc";
            this.Size = new System.Drawing.Size(1050, 700);

            ((System.ComponentModel.ISupportInitialize)(this.dgvClass)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();

            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout(); // Layout lại cho textbox bên trong
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}