namespace GUI
{
    partial class ThemHocSinh
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

            // Label Tiêu đề
            this.lblSecPersonal = new System.Windows.Forms.Label();
            this.lblSecAcademic = new System.Windows.Forms.Label();
            this.lblSecParents = new System.Windows.Forms.Label();

            // Panels Input
            this.pnlInputName = new System.Windows.Forms.Panel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.pnlInputDob = new System.Windows.Forms.Panel();
            this.dtpDob = new System.Windows.Forms.DateTimePicker();
            this.pnlInputAddress = new System.Windows.Forms.Panel();
            this.txtAddress = new System.Windows.Forms.TextBox();

            this.pnlInputID = new System.Windows.Forms.Panel();
            this.txtID = new System.Windows.Forms.TextBox();
            this.pnlInputClass = new System.Windows.Forms.Panel();
            this.cboClass = new System.Windows.Forms.ComboBox();
            this.pnlInputYear = new System.Windows.Forms.Panel();
            this.cboYear = new System.Windows.Forms.ComboBox();

            // Phụ huynh
            this.pnlInputFatherName = new System.Windows.Forms.Panel();
            this.txtFatherName = new System.Windows.Forms.TextBox();
            this.pnlInputFatherPhone = new System.Windows.Forms.Panel();
            this.txtFatherPhone = new System.Windows.Forms.TextBox();
            this.pnlInputFatherJob = new System.Windows.Forms.Panel();
            this.txtFatherJob = new System.Windows.Forms.TextBox();

            this.pnlInputMotherName = new System.Windows.Forms.Panel();
            this.txtMotherName = new System.Windows.Forms.TextBox();
            this.pnlInputMotherPhone = new System.Windows.Forms.Panel();
            this.txtMotherPhone = new System.Windows.Forms.TextBox();
            this.pnlInputMotherJob = new System.Windows.Forms.Panel();
            this.txtMotherJob = new System.Windows.Forms.TextBox();

            this.lblUpload = new System.Windows.Forms.Label();
            this.pnlAvatar = new System.Windows.Forms.Panel();
            this.btnGenderMale = new System.Windows.Forms.Button();
            this.btnGenderFemale = new System.Windows.Forms.Button();

            // Labels text
            this.lblName = new System.Windows.Forms.Label();
            this.lblDob = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblClass = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();

            this.lblFatherInfo = new System.Windows.Forms.Label();
            this.lblFatherName = new System.Windows.Forms.Label();
            this.lblFatherPhone = new System.Windows.Forms.Label();
            this.lblFatherJob = new System.Windows.Forms.Label();

            this.lblMotherInfo = new System.Windows.Forms.Label();
            this.lblMotherName = new System.Windows.Forms.Label();
            this.lblMotherPhone = new System.Windows.Forms.Label();
            this.lblMotherJob = new System.Windows.Forms.Label();

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
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblHeaderTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 70;

            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.Location = new System.Drawing.Point(25, 15);
            this.lblHeaderTitle.Text = "Thêm Hồ sơ Học sinh";

            // FOOTER
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.btnSave);
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Height = 80;

            // btnSave
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(13, 110, 253);
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(920, 20);
            this.btnSave.Size = new System.Drawing.Size(150, 45);
            this.btnSave.Text = "Lưu thông tin";
            this.btnSave.UseVisualStyleBackColor = false;
            // Click event ở file .cs

            // btnCancel
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(233, 236, 239);
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(780, 20);
            this.btnCancel.Size = new System.Drawing.Size(120, 45);
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.UseVisualStyleBackColor = false;

            // CONTENT
            this.pnlContent.AutoScroll = true;
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Padding = new System.Windows.Forms.Padding(0, 0, 0, 50);

            // --- SECTION 1 ---
            this.lblSecPersonal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSecPersonal.Location = new System.Drawing.Point(30, 20);
            this.lblSecPersonal.AutoSize = true;
            this.lblSecPersonal.Text = "Thông tin cá nhân";

            this.pnlAvatar.Location = new System.Drawing.Point(40, 60);
            this.pnlAvatar.Size = new System.Drawing.Size(150, 150);
            this.pnlAvatar.Controls.Add(this.lblUpload);

            this.lblUpload.AutoSize = true;
            this.lblUpload.ForeColor = System.Drawing.Color.Gray;
            this.lblUpload.Location = new System.Drawing.Point(40, 65);
            this.lblUpload.Text = "Tải ảnh lên";

            // Name
            this.lblName.Text = "Họ và tên";
            this.lblName.Location = new System.Drawing.Point(250, 60);
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            this.pnlInputName.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.pnlInputName.Controls.Add(this.txtName);
            this.pnlInputName.Location = new System.Drawing.Point(250, 85);
            this.pnlInputName.Size = new System.Drawing.Size(350, 45);

            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtName.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtName.Location = new System.Drawing.Point(10, 12);
            this.txtName.Size = new System.Drawing.Size(330, 20);
            // ĐÃ XÓA PlaceholderText

            // DOB
            this.lblDob.Text = "Ngày sinh";
            this.lblDob.Location = new System.Drawing.Point(650, 60);
            this.lblDob.AutoSize = true;
            this.lblDob.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            this.pnlInputDob.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.pnlInputDob.Controls.Add(this.dtpDob);
            this.pnlInputDob.Location = new System.Drawing.Point(650, 85);
            this.pnlInputDob.Size = new System.Drawing.Size(350, 45);

            this.dtpDob.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDob.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dtpDob.Location = new System.Drawing.Point(10, 10);
            this.dtpDob.Size = new System.Drawing.Size(330, 27);

            // Gender
            this.lblGender.Text = "Giới tính";
            this.lblGender.Location = new System.Drawing.Point(250, 140);
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

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
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            this.pnlInputAddress.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.pnlInputAddress.Controls.Add(this.txtAddress);
            this.pnlInputAddress.Location = new System.Drawing.Point(250, 245);
            this.pnlInputAddress.Size = new System.Drawing.Size(750, 45);

            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAddress.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtAddress.Location = new System.Drawing.Point(10, 12);
            this.txtAddress.Size = new System.Drawing.Size(730, 20);
            // ĐÃ XÓA PlaceholderText

            // --- SECTION 2 ---
            int top2 = 330;
            this.lblSecAcademic.Text = "Thông tin học tập";
            this.lblSecAcademic.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSecAcademic.Location = new System.Drawing.Point(30, top2);
            this.lblSecAcademic.AutoSize = true;

            // ID
            this.lblID.Text = "Mã số học sinh";
            this.lblID.Location = new System.Drawing.Point(30, top2 + 60);
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            this.pnlInputID.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.pnlInputID.Controls.Add(this.txtID);
            this.pnlInputID.Location = new System.Drawing.Point(30, top2 + 85);
            this.pnlInputID.Size = new System.Drawing.Size(300, 45);

            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtID.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.txtID.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtID.Location = new System.Drawing.Point(10, 12);
            this.txtID.Size = new System.Drawing.Size(280, 20);
            // ĐÃ XÓA PlaceholderText

            // Class
            this.lblClass.Text = "Chọn Lớp";
            this.lblClass.Location = new System.Drawing.Point(380, top2 + 60);
            this.lblClass.AutoSize = true;
            this.lblClass.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            this.pnlInputClass.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.pnlInputClass.Controls.Add(this.cboClass);
            this.pnlInputClass.Location = new System.Drawing.Point(380, top2 + 85);
            this.pnlInputClass.Size = new System.Drawing.Size(300, 45);

            this.cboClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboClass.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cboClass.Location = new System.Drawing.Point(10, 8);
            this.cboClass.Size = new System.Drawing.Size(280, 28);
            this.cboClass.Items.AddRange(new object[] { "Lớp 10A1", "Lớp 10A2" });

            // Year
            this.lblYear.Text = "Chọn Năm học";
            this.lblYear.Location = new System.Drawing.Point(730, top2 + 60);
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            this.pnlInputYear.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.pnlInputYear.Controls.Add(this.cboYear);
            this.pnlInputYear.Location = new System.Drawing.Point(730, top2 + 85);
            this.pnlInputYear.Size = new System.Drawing.Size(270, 45);

            this.cboYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboYear.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cboYear.Location = new System.Drawing.Point(10, 8);
            this.cboYear.Size = new System.Drawing.Size(250, 28);
            this.cboYear.Items.AddRange(new object[] { "2023-2024", "2024-2025" });

            // --- SECTION 3 ---
            int top3 = 480;
            this.lblSecParents.Text = "Thông tin liên hệ Phụ huynh";
            this.lblSecParents.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSecParents.Location = new System.Drawing.Point(30, top3);
            this.lblSecParents.AutoSize = true;

            // CHA
            int leftX = 30;
            this.lblFatherInfo.Text = "Thông tin Cha (hoặc người giám hộ)";
            this.lblFatherInfo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblFatherInfo.Location = new System.Drawing.Point(leftX, top3 + 60);
            this.lblFatherInfo.AutoSize = true;

            // Father Name
            this.lblFatherName.Text = "Họ tên";
            this.lblFatherName.Location = new System.Drawing.Point(leftX, top3 + 100);
            this.lblFatherName.AutoSize = true;
            this.lblFatherName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            this.pnlInputFatherName.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.pnlInputFatherName.Controls.Add(this.txtFatherName);
            this.pnlInputFatherName.Location = new System.Drawing.Point(leftX, top3 + 125);
            this.pnlInputFatherName.Size = new System.Drawing.Size(480, 45);

            this.txtFatherName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFatherName.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.txtFatherName.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtFatherName.Location = new System.Drawing.Point(10, 12);
            this.txtFatherName.Size = new System.Drawing.Size(460, 20);
            // ĐÃ XÓA PlaceholderText

            // Father Phone
            this.lblFatherPhone.Text = "Số điện thoại";
            this.lblFatherPhone.Location = new System.Drawing.Point(leftX, top3 + 180);
            this.lblFatherPhone.AutoSize = true;
            this.lblFatherPhone.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            this.pnlInputFatherPhone.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.pnlInputFatherPhone.Controls.Add(this.txtFatherPhone);
            this.pnlInputFatherPhone.Location = new System.Drawing.Point(leftX, top3 + 205);
            this.pnlInputFatherPhone.Size = new System.Drawing.Size(480, 45);

            this.txtFatherPhone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFatherPhone.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.txtFatherPhone.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtFatherPhone.Location = new System.Drawing.Point(10, 12);
            this.txtFatherPhone.Size = new System.Drawing.Size(460, 20);
            // ĐÃ XÓA PlaceholderText

            // Father Job
            this.lblFatherJob.Text = "Nghề nghiệp";
            this.lblFatherJob.Location = new System.Drawing.Point(leftX, top3 + 260);
            this.lblFatherJob.AutoSize = true;
            this.lblFatherJob.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            this.pnlInputFatherJob.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.pnlInputFatherJob.Controls.Add(this.txtFatherJob);
            this.pnlInputFatherJob.Location = new System.Drawing.Point(leftX, top3 + 285);
            this.pnlInputFatherJob.Size = new System.Drawing.Size(480, 45);

            this.txtFatherJob.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFatherJob.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.txtFatherJob.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtFatherJob.Location = new System.Drawing.Point(10, 12);
            this.txtFatherJob.Size = new System.Drawing.Size(460, 20);
            // ĐÃ XÓA PlaceholderText

            // MẸ
            int rightX = 550;
            this.lblMotherInfo.Text = "Thông tin Mẹ (hoặc người giám hộ)";
            this.lblMotherInfo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblMotherInfo.Location = new System.Drawing.Point(rightX, top3 + 60);
            this.lblMotherInfo.AutoSize = true;

            // Mother Name
            this.lblMotherName.Text = "Họ tên";
            this.lblMotherName.Location = new System.Drawing.Point(rightX, top3 + 100);
            this.lblMotherName.AutoSize = true;
            this.lblMotherName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            this.pnlInputMotherName.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.pnlInputMotherName.Controls.Add(this.txtMotherName);
            this.pnlInputMotherName.Location = new System.Drawing.Point(rightX, top3 + 125);
            this.pnlInputMotherName.Size = new System.Drawing.Size(450, 45);

            this.txtMotherName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMotherName.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.txtMotherName.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtMotherName.Location = new System.Drawing.Point(10, 12);
            this.txtMotherName.Size = new System.Drawing.Size(430, 20);
            // ĐÃ XÓA PlaceholderText

            // Mother Phone
            this.lblMotherPhone.Text = "Số điện thoại";
            this.lblMotherPhone.Location = new System.Drawing.Point(rightX, top3 + 180);
            this.lblMotherPhone.AutoSize = true;
            this.lblMotherPhone.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            this.pnlInputMotherPhone.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.pnlInputMotherPhone.Controls.Add(this.txtMotherPhone);
            this.pnlInputMotherPhone.Location = new System.Drawing.Point(rightX, top3 + 205);
            this.pnlInputMotherPhone.Size = new System.Drawing.Size(450, 45);

            this.txtMotherPhone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMotherPhone.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.txtMotherPhone.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtMotherPhone.Location = new System.Drawing.Point(10, 12);
            this.txtMotherPhone.Size = new System.Drawing.Size(430, 20);
            // ĐÃ XÓA PlaceholderText

            // Mother Job
            this.lblMotherJob.Text = "Nghề nghiệp";
            this.lblMotherJob.Location = new System.Drawing.Point(rightX, top3 + 260);
            this.lblMotherJob.AutoSize = true;
            this.lblMotherJob.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            this.pnlInputMotherJob.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.pnlInputMotherJob.Controls.Add(this.txtMotherJob);
            this.pnlInputMotherJob.Location = new System.Drawing.Point(rightX, top3 + 285);
            this.pnlInputMotherJob.Size = new System.Drawing.Size(450, 45);

            this.txtMotherJob.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMotherJob.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.txtMotherJob.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtMotherJob.Location = new System.Drawing.Point(10, 12);
            this.txtMotherJob.Size = new System.Drawing.Size(430, 20);
            // ĐÃ XÓA PlaceholderText

            // Add Controls to pnlContent
            this.pnlContent.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblSecPersonal, this.pnlAvatar, this.lblName, this.pnlInputName, this.lblDob, this.pnlInputDob,
                this.lblGender, this.btnGenderMale, this.btnGenderFemale, this.lblAddress, this.pnlInputAddress,
                this.lblSecAcademic, this.lblID, this.pnlInputID, this.lblClass, this.pnlInputClass, this.lblYear, this.pnlInputYear,
                this.lblSecParents,
                this.lblFatherInfo, this.lblFatherName, this.pnlInputFatherName, this.lblFatherPhone, this.pnlInputFatherPhone, this.lblFatherJob, this.pnlInputFatherJob,
                this.lblMotherInfo, this.lblMotherName, this.pnlInputMotherName, this.lblMotherPhone, this.pnlInputMotherPhone, this.lblMotherJob, this.pnlInputMotherJob
            });

            // Form Config
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
            this.pnlInputClass.ResumeLayout(false);
            this.pnlInputYear.ResumeLayout(false);
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

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlContent;

        // Controls public để file .cs truy cập
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
        public System.Windows.Forms.ComboBox cboClass;
        public System.Windows.Forms.Panel pnlInputYear;
        public System.Windows.Forms.ComboBox cboYear;

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