namespace GUI
{
    partial class SuaHocSinh
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();

            // --- KHAI BÁO CONTROLS ---

            // Labels Tiêu đề
            this.lblSecPersonal = new System.Windows.Forms.Label();
            this.lblSecAcademic = new System.Windows.Forms.Label();
            this.lblSecParents = new System.Windows.Forms.Label();

            // Avatar
            this.pnlAvatar = new System.Windows.Forms.Panel();
            this.lblUpload = new System.Windows.Forms.Label();

            // Inputs: Cá nhân
            this.lblName = new System.Windows.Forms.Label();
            this.pnlInputName = new System.Windows.Forms.Panel();
            this.txtName = new System.Windows.Forms.TextBox();

            this.lblDob = new System.Windows.Forms.Label();
            this.pnlInputDob = new System.Windows.Forms.Panel();
            this.dtpDob = new System.Windows.Forms.DateTimePicker();

            this.lblGender = new System.Windows.Forms.Label();
            this.btnGenderMale = new System.Windows.Forms.Button();
            this.btnGenderFemale = new System.Windows.Forms.Button();

            this.lblAddress = new System.Windows.Forms.Label();
            this.pnlInputAddress = new System.Windows.Forms.Panel();
            this.txtAddress = new System.Windows.Forms.TextBox();

            // Inputs: Học tập
            this.lblID = new System.Windows.Forms.Label();
            this.pnlInputID = new System.Windows.Forms.Panel();
            this.txtID = new System.Windows.Forms.TextBox();

            this.lblClass = new System.Windows.Forms.Label();
            this.pnlInputClass = new System.Windows.Forms.Panel();
            this.cboClass = new System.Windows.Forms.ComboBox(); // COMBOBOX

            this.lblYear = new System.Windows.Forms.Label();
            this.pnlInputYear = new System.Windows.Forms.Panel();
            this.cboYear = new System.Windows.Forms.ComboBox(); // COMBOBOX

            // Inputs: Phụ huynh - Cha
            this.lblFatherInfo = new System.Windows.Forms.Label();
            this.lblFatherName = new System.Windows.Forms.Label();
            this.pnlInputFatherName = new System.Windows.Forms.Panel();
            this.txtFatherName = new System.Windows.Forms.TextBox();

            this.lblFatherPhone = new System.Windows.Forms.Label();
            this.pnlInputFatherPhone = new System.Windows.Forms.Panel();
            this.txtFatherPhone = new System.Windows.Forms.TextBox();

            this.lblFatherJob = new System.Windows.Forms.Label();
            this.pnlInputFatherJob = new System.Windows.Forms.Panel();
            this.txtFatherJob = new System.Windows.Forms.TextBox();

            // Inputs: Phụ huynh - Mẹ
            this.lblMotherInfo = new System.Windows.Forms.Label();
            this.lblMotherName = new System.Windows.Forms.Label();
            this.pnlInputMotherName = new System.Windows.Forms.Panel();
            this.txtMotherName = new System.Windows.Forms.TextBox();

            this.lblMotherPhone = new System.Windows.Forms.Label();
            this.pnlInputMotherPhone = new System.Windows.Forms.Panel();
            this.txtMotherPhone = new System.Windows.Forms.TextBox();

            this.lblMotherJob = new System.Windows.Forms.Label();
            this.pnlInputMotherJob = new System.Windows.Forms.Panel();
            this.txtMotherJob = new System.Windows.Forms.TextBox();

            // SuspendLayout
            this.pnlHeader.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlAvatar.SuspendLayout();
            this.pnlInputName.SuspendLayout();
            this.pnlInputDob.SuspendLayout();
            this.pnlInputAddress.SuspendLayout();
            this.pnlInputID.SuspendLayout();
            this.pnlInputClass.SuspendLayout();
            this.pnlInputYear.SuspendLayout();
            this.pnlInputFatherName.SuspendLayout();
            this.pnlInputFatherPhone.SuspendLayout();
            this.pnlInputFatherJob.SuspendLayout();
            this.pnlInputMotherName.SuspendLayout();
            this.pnlInputMotherPhone.SuspendLayout();
            this.pnlInputMotherJob.SuspendLayout();
            this.SuspendLayout();

            // HEADER
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 70;
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblHeaderTitle);

            this.lblHeaderTitle.Text = "Cập nhật hồ sơ";
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.Location = new System.Drawing.Point(25, 15);
            this.lblHeaderTitle.AutoSize = true;

            // FOOTER
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Height = 80;
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.btnSave);
            this.pnlFooter.Controls.Add(this.btnCancel);

            this.btnSave.Text = "Lưu thông tin";
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(13, 110, 253);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.Size = new System.Drawing.Size(150, 45);
            this.btnSave.Location = new System.Drawing.Point(920, 20);
            this.btnSave.UseVisualStyleBackColor = false;
            // Event in .cs

            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(233, 236, 239);
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Size = new System.Drawing.Size(120, 45);
            this.btnCancel.Location = new System.Drawing.Point(780, 20);
            this.btnCancel.UseVisualStyleBackColor = false;
            // Event in .cs

            // CONTENT
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.AutoScroll = true;
            this.pnlContent.Padding = new System.Windows.Forms.Padding(0, 0, 0, 50);
            this.pnlContent.BackColor = System.Drawing.Color.White;

            // --- SECTION 1: CÁ NHÂN ---
            this.lblSecPersonal.Text = "Thông tin cá nhân";
            this.lblSecPersonal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSecPersonal.Location = new System.Drawing.Point(30, 20);
            this.lblSecPersonal.AutoSize = true;

            // Avatar
            this.pnlAvatar.Location = new System.Drawing.Point(40, 60);
            this.pnlAvatar.Size = new System.Drawing.Size(150, 150);
            this.pnlAvatar.Controls.Add(this.lblUpload);

            this.lblUpload.Text = "Tải ảnh lên";
            this.lblUpload.ForeColor = System.Drawing.Color.Gray;
            this.lblUpload.Location = new System.Drawing.Point(40, 65);
            this.lblUpload.AutoSize = true;

            // Name
            this.lblName.Text = "Họ và tên";
            this.lblName.Location = new System.Drawing.Point(250, 60);
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblName.AutoSize = true;

            this.pnlInputName.Location = new System.Drawing.Point(250, 85);
            this.pnlInputName.Size = new System.Drawing.Size(350, 45);
            this.pnlInputName.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.pnlInputName.Controls.Add(this.txtName);

            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtName.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtName.Location = new System.Drawing.Point(10, 12);
            this.txtName.Size = new System.Drawing.Size(330, 20);

            // DOB
            this.lblDob.Text = "Ngày sinh";
            this.lblDob.Location = new System.Drawing.Point(650, 60);
            this.lblDob.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDob.AutoSize = true;

            this.pnlInputDob.Location = new System.Drawing.Point(650, 85);
            this.pnlInputDob.Size = new System.Drawing.Size(350, 45);
            this.pnlInputDob.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.pnlInputDob.Controls.Add(this.dtpDob);

            this.dtpDob.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDob.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dtpDob.Location = new System.Drawing.Point(10, 10);
            this.dtpDob.Size = new System.Drawing.Size(330, 27);

            // Gender
            this.lblGender.Text = "Giới tính";
            this.lblGender.Location = new System.Drawing.Point(250, 140);
            this.lblGender.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblGender.AutoSize = true;

            this.btnGenderMale.Text = "Nam";
            this.btnGenderMale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenderMale.Location = new System.Drawing.Point(250, 165);
            this.btnGenderMale.Size = new System.Drawing.Size(80, 40);

            this.btnGenderFemale.Text = "Nữ";
            this.btnGenderFemale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenderFemale.Location = new System.Drawing.Point(340, 165);
            this.btnGenderFemale.Size = new System.Drawing.Size(80, 40);

            // Address
            this.lblAddress.Text = "Địa chỉ thường trú";
            this.lblAddress.Location = new System.Drawing.Point(250, 220);
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAddress.AutoSize = true;

            this.pnlInputAddress.Location = new System.Drawing.Point(250, 245);
            this.pnlInputAddress.Size = new System.Drawing.Size(750, 45);
            this.pnlInputAddress.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.pnlInputAddress.Controls.Add(this.txtAddress);

            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAddress.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtAddress.Location = new System.Drawing.Point(10, 12);
            this.txtAddress.Size = new System.Drawing.Size(730, 20);

            // --- SECTION 2: HỌC TẬP ---
            int top2 = 330;
            this.lblSecAcademic.Text = "Thông tin học tập";
            this.lblSecAcademic.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSecAcademic.Location = new System.Drawing.Point(30, top2);
            this.lblSecAcademic.AutoSize = true;

            // ID
            this.lblID.Text = "Mã số học sinh";
            this.lblID.Location = new System.Drawing.Point(30, top2 + 60);
            this.lblID.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblID.AutoSize = true;

            this.pnlInputID.Location = new System.Drawing.Point(30, top2 + 85);
            this.pnlInputID.Size = new System.Drawing.Size(300, 45);
            this.pnlInputID.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.pnlInputID.Controls.Add(this.txtID);

            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtID.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.txtID.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtID.Location = new System.Drawing.Point(10, 12);
            this.txtID.Size = new System.Drawing.Size(280, 20);

            // Class (COMBOBOX)
            this.lblClass.Text = "Chọn Lớp";
            this.lblClass.Location = new System.Drawing.Point(380, top2 + 60);
            this.lblClass.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblClass.AutoSize = true;

            this.pnlInputClass.Location = new System.Drawing.Point(380, top2 + 85);
            this.pnlInputClass.Size = new System.Drawing.Size(300, 45);
            this.pnlInputClass.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.pnlInputClass.Controls.Add(this.cboClass);

            this.cboClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboClass.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cboClass.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.cboClass.Location = new System.Drawing.Point(10, 8);
            this.cboClass.Size = new System.Drawing.Size(280, 28);
            this.cboClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; // Chỉ chọn, không nhập

            // Year (COMBOBOX)
            this.lblYear.Text = "Chọn Năm học";
            this.lblYear.Location = new System.Drawing.Point(730, top2 + 60);
            this.lblYear.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblYear.AutoSize = true;

            this.pnlInputYear.Location = new System.Drawing.Point(730, top2 + 85);
            this.pnlInputYear.Size = new System.Drawing.Size(270, 45);
            this.pnlInputYear.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.pnlInputYear.Controls.Add(this.cboYear);

            this.cboYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboYear.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cboYear.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.cboYear.Location = new System.Drawing.Point(10, 8);
            this.cboYear.Size = new System.Drawing.Size(250, 28);
            this.cboYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // --- SECTION 3: PHỤ HUYNH ---
            int top3 = 480;
            this.lblSecParents.Text = "Thông tin liên hệ Phụ huynh";
            this.lblSecParents.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSecParents.Location = new System.Drawing.Point(30, top3);
            this.lblSecParents.AutoSize = true;

            // CỘT TRÁI (CHA)
            int leftX = 30;
            this.lblFatherInfo.Text = "Thông tin Cha (hoặc người giám hộ)";
            this.lblFatherInfo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblFatherInfo.Location = new System.Drawing.Point(leftX, top3 + 60);
            this.lblFatherInfo.AutoSize = true;

            this.lblFatherName.Text = "Họ tên";
            this.lblFatherName.Location = new System.Drawing.Point(leftX, top3 + 100);
            this.lblFatherName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFatherName.AutoSize = true;

            this.pnlInputFatherName.Location = new System.Drawing.Point(leftX, top3 + 125);
            this.pnlInputFatherName.Size = new System.Drawing.Size(480, 45);
            this.pnlInputFatherName.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.pnlInputFatherName.Controls.Add(this.txtFatherName);

            this.txtFatherName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFatherName.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.txtFatherName.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtFatherName.Location = new System.Drawing.Point(10, 12);
            this.txtFatherName.Size = new System.Drawing.Size(460, 20);

            this.lblFatherPhone.Text = "Số điện thoại";
            this.lblFatherPhone.Location = new System.Drawing.Point(leftX, top3 + 180);
            this.lblFatherPhone.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFatherPhone.AutoSize = true;

            this.pnlInputFatherPhone.Location = new System.Drawing.Point(leftX, top3 + 205);
            this.pnlInputFatherPhone.Size = new System.Drawing.Size(480, 45);
            this.pnlInputFatherPhone.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.pnlInputFatherPhone.Controls.Add(this.txtFatherPhone);

            this.txtFatherPhone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFatherPhone.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.txtFatherPhone.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtFatherPhone.Location = new System.Drawing.Point(10, 12);
            this.txtFatherPhone.Size = new System.Drawing.Size(460, 20);

            this.lblFatherJob.Text = "Nghề nghiệp";
            this.lblFatherJob.Location = new System.Drawing.Point(leftX, top3 + 260);
            this.lblFatherJob.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFatherJob.AutoSize = true;

            this.pnlInputFatherJob.Location = new System.Drawing.Point(leftX, top3 + 285);
            this.pnlInputFatherJob.Size = new System.Drawing.Size(480, 45);
            this.pnlInputFatherJob.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.pnlInputFatherJob.Controls.Add(this.txtFatherJob);

            this.txtFatherJob.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFatherJob.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.txtFatherJob.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtFatherJob.Location = new System.Drawing.Point(10, 12);
            this.txtFatherJob.Size = new System.Drawing.Size(460, 20);

            // CỘT PHẢI (MẸ)
            int rightX = 550;
            this.lblMotherInfo.Text = "Thông tin Mẹ (hoặc người giám hộ)";
            this.lblMotherInfo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblMotherInfo.Location = new System.Drawing.Point(rightX, top3 + 60);
            this.lblMotherInfo.AutoSize = true;

            this.lblMotherName.Text = "Họ tên";
            this.lblMotherName.Location = new System.Drawing.Point(rightX, top3 + 100);
            this.lblMotherName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMotherName.AutoSize = true;

            this.pnlInputMotherName.Location = new System.Drawing.Point(rightX, top3 + 125);
            this.pnlInputMotherName.Size = new System.Drawing.Size(450, 45);
            this.pnlInputMotherName.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.pnlInputMotherName.Controls.Add(this.txtMotherName);

            this.txtMotherName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMotherName.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.txtMotherName.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtMotherName.Location = new System.Drawing.Point(10, 12);
            this.txtMotherName.Size = new System.Drawing.Size(430, 20);

            this.lblMotherPhone.Text = "Số điện thoại";
            this.lblMotherPhone.Location = new System.Drawing.Point(rightX, top3 + 180);
            this.lblMotherPhone.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMotherPhone.AutoSize = true;

            this.pnlInputMotherPhone.Location = new System.Drawing.Point(rightX, top3 + 205);
            this.pnlInputMotherPhone.Size = new System.Drawing.Size(450, 45);
            this.pnlInputMotherPhone.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.pnlInputMotherPhone.Controls.Add(this.txtMotherPhone);

            this.txtMotherPhone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMotherPhone.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.txtMotherPhone.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtMotherPhone.Location = new System.Drawing.Point(10, 12);
            this.txtMotherPhone.Size = new System.Drawing.Size(430, 20);

            this.lblMotherJob.Text = "Nghề nghiệp";
            this.lblMotherJob.Location = new System.Drawing.Point(rightX, top3 + 260);
            this.lblMotherJob.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMotherJob.AutoSize = true;

            this.pnlInputMotherJob.Location = new System.Drawing.Point(rightX, top3 + 285);
            this.pnlInputMotherJob.Size = new System.Drawing.Size(450, 45);
            this.pnlInputMotherJob.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.pnlInputMotherJob.Controls.Add(this.txtMotherJob);

            this.txtMotherJob.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMotherJob.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.txtMotherJob.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtMotherJob.Location = new System.Drawing.Point(10, 12);
            this.txtMotherJob.Size = new System.Drawing.Size(430, 20);

            // Add Controls to Panel Content
            this.pnlContent.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblSecPersonal, this.pnlAvatar, this.lblName, this.pnlInputName, this.lblDob, this.pnlInputDob,
                this.lblGender, this.btnGenderMale, this.btnGenderFemale, this.lblAddress, this.pnlInputAddress,
                this.lblSecAcademic, this.lblID, this.pnlInputID, this.lblClass, this.pnlInputClass, this.lblYear, this.pnlInputYear,
                this.lblSecParents,
                this.lblFatherInfo, this.lblFatherName, this.pnlInputFatherName, this.lblFatherPhone, this.pnlInputFatherPhone, this.lblFatherJob, this.pnlInputFatherJob,
                this.lblMotherInfo, this.lblMotherName, this.pnlInputMotherName, this.lblMotherPhone, this.pnlInputMotherPhone, this.lblMotherJob, this.pnlInputMotherJob
            });

            // Form
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.Name = "ThemHocSinh";
            this.Text = "Thêm Hồ sơ Học sinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1100, 850);
            this.BackColor = System.Drawing.Color.White;

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.pnlAvatar.ResumeLayout(false);
            this.pnlAvatar.PerformLayout();
            this.pnlInputName.ResumeLayout(false);
            this.pnlInputName.PerformLayout();
            this.pnlInputDob.ResumeLayout(false);
            this.pnlInputAddress.ResumeLayout(false);
            this.pnlInputAddress.PerformLayout();
            this.pnlInputID.ResumeLayout(false);
            this.pnlInputID.PerformLayout();
            this.pnlInputClass.ResumeLayout(false); // ComboBox
            this.pnlInputYear.ResumeLayout(false);  // ComboBox
            this.pnlInputFatherName.ResumeLayout(false);
            this.pnlInputFatherName.PerformLayout();
            this.pnlInputFatherPhone.ResumeLayout(false);
            this.pnlInputFatherPhone.PerformLayout();
            this.pnlInputFatherJob.ResumeLayout(false);
            this.pnlInputFatherJob.PerformLayout();
            this.pnlInputMotherName.ResumeLayout(false);
            this.pnlInputMotherName.PerformLayout();
            this.pnlInputMotherPhone.ResumeLayout(false);
            this.pnlInputMotherPhone.PerformLayout();
            this.pnlInputMotherJob.ResumeLayout(false);
            this.pnlInputMotherJob.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        // Biến controls
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlContent;

        public System.Windows.Forms.Label lblSecPersonal;
        public System.Windows.Forms.Label lblSecAcademic;
        public System.Windows.Forms.Label lblSecParents;

        public System.Windows.Forms.Panel pnlAvatar;
        public System.Windows.Forms.Label lblUpload;

        public System.Windows.Forms.Panel pnlInputName;
        public System.Windows.Forms.TextBox txtName;
        public System.Windows.Forms.Panel pnlInputDob;
        public System.Windows.Forms.DateTimePicker dtpDob;
        public System.Windows.Forms.Panel pnlInputAddress;
        public System.Windows.Forms.TextBox txtAddress;
        public System.Windows.Forms.Button btnGenderMale;
        public System.Windows.Forms.Button btnGenderFemale;

        public System.Windows.Forms.Panel pnlInputID;
        public System.Windows.Forms.TextBox txtID;
        public System.Windows.Forms.Panel pnlInputClass;
        public System.Windows.Forms.ComboBox cboClass; // ComboBox
        public System.Windows.Forms.Panel pnlInputYear;
        public System.Windows.Forms.ComboBox cboYear;  // ComboBox

        public System.Windows.Forms.Panel pnlInputFatherName;
        public System.Windows.Forms.TextBox txtFatherName;
        public System.Windows.Forms.Panel pnlInputFatherPhone;
        public System.Windows.Forms.TextBox txtFatherPhone;
        public System.Windows.Forms.Panel pnlInputFatherJob;
        public System.Windows.Forms.TextBox txtFatherJob;

        public System.Windows.Forms.Panel pnlInputMotherName;
        public System.Windows.Forms.TextBox txtMotherName;
        public System.Windows.Forms.Panel pnlInputMotherPhone;
        public System.Windows.Forms.TextBox txtMotherPhone;
        public System.Windows.Forms.Panel pnlInputMotherJob;
        public System.Windows.Forms.TextBox txtMotherJob;

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDob;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblFatherInfo;
        private System.Windows.Forms.Label lblFatherName;
        private System.Windows.Forms.Label lblFatherPhone;
        private System.Windows.Forms.Label lblFatherJob;
        private System.Windows.Forms.Label lblMotherInfo;
        private System.Windows.Forms.Label lblMotherName;
        private System.Windows.Forms.Label lblMotherPhone;
        private System.Windows.Forms.Label lblMotherJob;
    }
}