namespace GUI
{
    partial class ChiTietHocSinh
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

            // --- 1. CÁ NHÂN ---
            this.lblSecPersonal = new System.Windows.Forms.Label();
            this.pnlAvatar = new System.Windows.Forms.Panel();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.lblUpload = new System.Windows.Forms.Label();
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

            // --- 2. HỌC TẬP ---
            this.lblSecAcademic = new System.Windows.Forms.Label();
            this.lblClass = new System.Windows.Forms.Label();
            this.pnlInputClass = new System.Windows.Forms.Panel();
            this.cboClass = new System.Windows.Forms.ComboBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.pnlInputYear = new System.Windows.Forms.Panel();
            this.cboYear = new System.Windows.Forms.ComboBox();

            // --- 3. PHỤ HUYNH ---
            this.lblSecParents = new System.Windows.Forms.Label();
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

            // --- 4. GIÁM HỘ ---
            this.lblGuardianInfo = new System.Windows.Forms.Label();
            this.lblGuardianName = new System.Windows.Forms.Label();
            this.pnlInputGuardianName = new System.Windows.Forms.Panel();
            this.txtGuardianName = new System.Windows.Forms.TextBox();
            this.lblGuardianPhone = new System.Windows.Forms.Label();
            this.pnlInputGuardianPhone = new System.Windows.Forms.Panel();
            this.txtGuardianPhone = new System.Windows.Forms.TextBox();
            this.lblGuardianJob = new System.Windows.Forms.Label();
            this.pnlInputGuardianJob = new System.Windows.Forms.Panel();
            this.txtGuardianJob = new System.Windows.Forms.TextBox();
            this.lblGuardianRelation = new System.Windows.Forms.Label();
            this.pnlInputGuardianRelation = new System.Windows.Forms.Panel();
            this.txtGuardianRelation = new System.Windows.Forms.TextBox();

            // --- SUSPEND LAYOUT ---
            this.pnlHeader.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlAvatar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.pnlInputName.SuspendLayout();
            this.pnlInputDob.SuspendLayout();
            this.pnlInputAddress.SuspendLayout();
            this.pnlInputClass.SuspendLayout();
            this.pnlInputYear.SuspendLayout();
            this.pnlInputFatherName.SuspendLayout();
            this.pnlInputFatherPhone.SuspendLayout();
            this.pnlInputFatherJob.SuspendLayout();
            this.pnlInputMotherName.SuspendLayout();
            this.pnlInputMotherPhone.SuspendLayout();
            this.pnlInputMotherJob.SuspendLayout();
            this.pnlInputGuardianName.SuspendLayout();
            this.pnlInputGuardianPhone.SuspendLayout();
            this.pnlInputGuardianJob.SuspendLayout();
            this.pnlInputGuardianRelation.SuspendLayout();
            this.SuspendLayout();

            // Form
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1100, 850);
            this.Name = "ChiTietHocSinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết Hồ sơ Học sinh";

            // Header
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 70;
            this.pnlHeader.Controls.Add(this.lblHeaderTitle);
            this.lblHeaderTitle.Location = new System.Drawing.Point(25, 15);
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.Text = "Chi tiết Hồ sơ Học sinh";

            // Footer
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Height = 80;
            this.pnlFooter.Controls.Add(this.btnSave);
            this.pnlFooter.Controls.Add(this.btnCancel);

            this.btnSave.Location = new System.Drawing.Point(920, 20);
            this.btnSave.Size = new System.Drawing.Size(150, 45);
            this.btnSave.Text = "Lưu";
            this.btnSave.Visible = false;

            this.btnCancel.Location = new System.Drawing.Point(920, 20);
            this.btnCancel.Size = new System.Drawing.Size(120, 45);
            this.btnCancel.Text = "Đóng";
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(233, 236, 239);
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            // Content Panel
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.AutoScroll = true; // QUAN TRỌNG
            this.pnlContent.Padding = new System.Windows.Forms.Padding(0, 0, 0, 50);

            // --- LAYOUT ---
            // 1. Cá nhân
            this.lblSecPersonal.Location = new System.Drawing.Point(30, 20); this.lblSecPersonal.Text = "Thông tin cá nhân"; this.lblSecPersonal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold); this.lblSecPersonal.AutoSize = true;
            this.pnlAvatar.Location = new System.Drawing.Point(40, 60); this.pnlAvatar.Size = new System.Drawing.Size(150, 150); this.pnlAvatar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.picAvatar.Dock = System.Windows.Forms.DockStyle.Fill; this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.lblUpload.Dock = System.Windows.Forms.DockStyle.Fill; this.lblUpload.TextAlign = System.Drawing.ContentAlignment.MiddleCenter; this.lblUpload.Text = "";

            this.lblName.Location = new System.Drawing.Point(250, 60); this.lblName.Text = "Họ và tên"; this.lblName.AutoSize = true; this.lblName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.pnlInputName.Location = new System.Drawing.Point(250, 85); this.pnlInputName.Size = new System.Drawing.Size(350, 45); this.pnlInputName.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.txtName.Location = new System.Drawing.Point(10, 12); this.txtName.Size = new System.Drawing.Size(330, 20); this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None; this.txtName.Font = new System.Drawing.Font("Segoe UI", 11F); this.txtName.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);

            this.lblDob.Location = new System.Drawing.Point(650, 60); this.lblDob.Text = "Ngày sinh"; this.lblDob.AutoSize = true; this.lblDob.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.pnlInputDob.Location = new System.Drawing.Point(650, 85); this.pnlInputDob.Size = new System.Drawing.Size(350, 45); this.pnlInputDob.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.dtpDob.Location = new System.Drawing.Point(10, 10); this.dtpDob.Size = new System.Drawing.Size(330, 27); this.dtpDob.Font = new System.Drawing.Font("Segoe UI", 11F);

            this.lblGender.Location = new System.Drawing.Point(250, 140); this.lblGender.Text = "Giới tính"; this.lblGender.AutoSize = true; this.lblGender.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGenderMale.Location = new System.Drawing.Point(250, 165); this.btnGenderMale.Size = new System.Drawing.Size(80, 40); this.btnGenderMale.Text = "Nam"; this.btnGenderMale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenderFemale.Location = new System.Drawing.Point(340, 165); this.btnGenderFemale.Size = new System.Drawing.Size(80, 40); this.btnGenderFemale.Text = "Nữ"; this.btnGenderFemale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            this.lblAddress.Location = new System.Drawing.Point(250, 220); this.lblAddress.Text = "Địa chỉ thường trú"; this.lblAddress.AutoSize = true; this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.pnlInputAddress.Location = new System.Drawing.Point(250, 245); this.pnlInputAddress.Size = new System.Drawing.Size(750, 45); this.pnlInputAddress.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.txtAddress.Location = new System.Drawing.Point(10, 12); this.txtAddress.Size = new System.Drawing.Size(730, 20); this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.None; this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 11F); this.txtAddress.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);

            // 2. Học tập
            this.lblSecAcademic.Location = new System.Drawing.Point(30, 330); this.lblSecAcademic.Text = "Thông tin học tập"; this.lblSecAcademic.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold); this.lblSecAcademic.AutoSize = true;
            this.lblClass.Location = new System.Drawing.Point(30, 370); this.lblClass.Text = "Lớp học"; this.lblClass.AutoSize = true; this.lblClass.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.pnlInputClass.Location = new System.Drawing.Point(30, 395); this.pnlInputClass.Size = new System.Drawing.Size(300, 45); this.pnlInputClass.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.cboClass.Location = new System.Drawing.Point(10, 8); this.cboClass.Size = new System.Drawing.Size(280, 28); this.cboClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.cboClass.Font = new System.Drawing.Font("Segoe UI", 11F); this.cboClass.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);

            this.lblYear.Location = new System.Drawing.Point(380, 370); this.lblYear.Text = "Năm học"; this.lblYear.AutoSize = true; this.lblYear.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.pnlInputYear.Location = new System.Drawing.Point(380, 395); this.pnlInputYear.Size = new System.Drawing.Size(270, 45); this.pnlInputYear.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.cboYear.Location = new System.Drawing.Point(10, 8); this.cboYear.Size = new System.Drawing.Size(250, 28); this.cboYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.cboYear.Font = new System.Drawing.Font("Segoe UI", 11F); this.cboYear.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);

            // 3. Phụ huynh (Dọc)
            this.lblSecParents.Location = new System.Drawing.Point(30, 470); this.lblSecParents.Text = "Thông tin liên hệ Phụ huynh"; this.lblSecParents.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold); this.lblSecParents.AutoSize = true;

            // -- Cha (Y=510)
            int yF = 510;
            this.lblFatherInfo.Location = new System.Drawing.Point(30, yF); this.lblFatherInfo.Text = "1. Thông tin Cha"; this.lblFatherInfo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold); this.lblFatherInfo.AutoSize = true;
            this.lblFatherName.Location = new System.Drawing.Point(30, yF + 30); this.lblFatherName.Text = "Họ tên"; this.lblFatherName.AutoSize = true; this.lblFatherName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.pnlInputFatherName.Location = new System.Drawing.Point(30, yF + 55); this.pnlInputFatherName.Size = new System.Drawing.Size(300, 45); this.pnlInputFatherName.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.txtFatherName.Location = new System.Drawing.Point(10, 12); this.txtFatherName.Size = new System.Drawing.Size(280, 20); this.txtFatherName.BorderStyle = System.Windows.Forms.BorderStyle.None; this.txtFatherName.Font = new System.Drawing.Font("Segoe UI", 11F); this.txtFatherName.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);

            this.lblFatherPhone.Location = new System.Drawing.Point(360, yF + 30); this.lblFatherPhone.Text = "Số điện thoại"; this.lblFatherPhone.AutoSize = true; this.lblFatherPhone.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.pnlInputFatherPhone.Location = new System.Drawing.Point(360, yF + 55); this.pnlInputFatherPhone.Size = new System.Drawing.Size(250, 45); this.pnlInputFatherPhone.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.txtFatherPhone.Location = new System.Drawing.Point(10, 12); this.txtFatherPhone.Size = new System.Drawing.Size(230, 20); this.txtFatherPhone.BorderStyle = System.Windows.Forms.BorderStyle.None; this.txtFatherPhone.Font = new System.Drawing.Font("Segoe UI", 11F); this.txtFatherPhone.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);

            this.lblFatherJob.Location = new System.Drawing.Point(640, yF + 30); this.lblFatherJob.Text = "Nghề nghiệp"; this.lblFatherJob.AutoSize = true; this.lblFatherJob.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.pnlInputFatherJob.Location = new System.Drawing.Point(640, yF + 55); this.pnlInputFatherJob.Size = new System.Drawing.Size(300, 45); this.pnlInputFatherJob.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.txtFatherJob.Location = new System.Drawing.Point(10, 12); this.txtFatherJob.Size = new System.Drawing.Size(280, 20); this.txtFatherJob.BorderStyle = System.Windows.Forms.BorderStyle.None; this.txtFatherJob.Font = new System.Drawing.Font("Segoe UI", 11F); this.txtFatherJob.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);

            // -- Mẹ (Y=630)
            int yM = yF + 120;
            this.lblMotherInfo.Location = new System.Drawing.Point(30, yM); this.lblMotherInfo.Text = "2. Thông tin Mẹ"; this.lblMotherInfo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold); this.lblMotherInfo.AutoSize = true;
            this.lblMotherName.Location = new System.Drawing.Point(30, yM + 30); this.lblMotherName.Text = "Họ tên"; this.lblMotherName.AutoSize = true; this.lblMotherName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.pnlInputMotherName.Location = new System.Drawing.Point(30, yM + 55); this.pnlInputMotherName.Size = new System.Drawing.Size(300, 45); this.pnlInputMotherName.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.txtMotherName.Location = new System.Drawing.Point(10, 12); this.txtMotherName.Size = new System.Drawing.Size(280, 20); this.txtMotherName.BorderStyle = System.Windows.Forms.BorderStyle.None; this.txtMotherName.Font = new System.Drawing.Font("Segoe UI", 11F); this.txtMotherName.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);

            this.lblMotherPhone.Location = new System.Drawing.Point(360, yM + 30); this.lblMotherPhone.Text = "Số điện thoại"; this.lblMotherPhone.AutoSize = true; this.lblMotherPhone.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.pnlInputMotherPhone.Location = new System.Drawing.Point(360, yM + 55); this.pnlInputMotherPhone.Size = new System.Drawing.Size(250, 45); this.pnlInputMotherPhone.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.txtMotherPhone.Location = new System.Drawing.Point(10, 12); this.txtMotherPhone.Size = new System.Drawing.Size(230, 20); this.txtMotherPhone.BorderStyle = System.Windows.Forms.BorderStyle.None; this.txtMotherPhone.Font = new System.Drawing.Font("Segoe UI", 11F); this.txtMotherPhone.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);

            this.lblMotherJob.Location = new System.Drawing.Point(640, yM + 30); this.lblMotherJob.Text = "Nghề nghiệp"; this.lblMotherJob.AutoSize = true; this.lblMotherJob.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.pnlInputMotherJob.Location = new System.Drawing.Point(640, yM + 55); this.pnlInputMotherJob.Size = new System.Drawing.Size(300, 45); this.pnlInputMotherJob.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.txtMotherJob.Location = new System.Drawing.Point(10, 12); this.txtMotherJob.Size = new System.Drawing.Size(280, 20); this.txtMotherJob.BorderStyle = System.Windows.Forms.BorderStyle.None; this.txtMotherJob.Font = new System.Drawing.Font("Segoe UI", 11F); this.txtMotherJob.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);

            // -- Giám hộ (Y=750)
            int yG = yM + 120;
            this.lblGuardianInfo.Location = new System.Drawing.Point(30, yG); this.lblGuardianInfo.Text = "3. Người giám hộ (nếu có)"; this.lblGuardianInfo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold); this.lblGuardianInfo.AutoSize = true;

            this.lblGuardianName.Location = new System.Drawing.Point(30, yG + 30); this.lblGuardianName.Text = "Họ tên"; this.lblGuardianName.AutoSize = true; this.lblGuardianName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.pnlInputGuardianName.Location = new System.Drawing.Point(30, yG + 55); this.pnlInputGuardianName.Size = new System.Drawing.Size(250, 45); this.pnlInputGuardianName.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.txtGuardianName.Location = new System.Drawing.Point(10, 12); this.txtGuardianName.Size = new System.Drawing.Size(230, 20); this.txtGuardianName.BorderStyle = System.Windows.Forms.BorderStyle.None; this.txtGuardianName.Font = new System.Drawing.Font("Segoe UI", 11F); this.txtGuardianName.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);

            this.lblGuardianPhone.Location = new System.Drawing.Point(300, yG + 30); this.lblGuardianPhone.Text = "Số điện thoại"; this.lblGuardianPhone.AutoSize = true; this.lblGuardianPhone.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.pnlInputGuardianPhone.Location = new System.Drawing.Point(300, yG + 55); this.pnlInputGuardianPhone.Size = new System.Drawing.Size(200, 45); this.pnlInputGuardianPhone.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.txtGuardianPhone.Location = new System.Drawing.Point(10, 12); this.txtGuardianPhone.Size = new System.Drawing.Size(180, 20); this.txtGuardianPhone.BorderStyle = System.Windows.Forms.BorderStyle.None; this.txtGuardianPhone.Font = new System.Drawing.Font("Segoe UI", 11F); this.txtGuardianPhone.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);

            this.lblGuardianRelation.Location = new System.Drawing.Point(520, yG + 30); this.lblGuardianRelation.Text = "Quan hệ (vd: Bà)"; this.lblGuardianRelation.AutoSize = true; this.lblGuardianRelation.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.pnlInputGuardianRelation.Location = new System.Drawing.Point(520, yG + 55); this.pnlInputGuardianRelation.Size = new System.Drawing.Size(150, 45); this.pnlInputGuardianRelation.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.txtGuardianRelation.Location = new System.Drawing.Point(10, 12); this.txtGuardianRelation.Size = new System.Drawing.Size(130, 20); this.txtGuardianRelation.BorderStyle = System.Windows.Forms.BorderStyle.None; this.txtGuardianRelation.Font = new System.Drawing.Font("Segoe UI", 11F); this.txtGuardianRelation.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);

            this.lblGuardianJob.Location = new System.Drawing.Point(690, yG + 30); this.lblGuardianJob.Text = "Nghề nghiệp"; this.lblGuardianJob.AutoSize = true; this.lblGuardianJob.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.pnlInputGuardianJob.Location = new System.Drawing.Point(690, yG + 55); this.pnlInputGuardianJob.Size = new System.Drawing.Size(250, 45); this.pnlInputGuardianJob.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.txtGuardianJob.Location = new System.Drawing.Point(10, 12); this.txtGuardianJob.Size = new System.Drawing.Size(230, 20); this.txtGuardianJob.BorderStyle = System.Windows.Forms.BorderStyle.None; this.txtGuardianJob.Font = new System.Drawing.Font("Segoe UI", 11F); this.txtGuardianJob.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);

            // Add ALL Controls (Thứ tự thêm vào Panel rất quan trọng)
            this.pnlContent.Controls.Add(this.lblSecPersonal);
            this.pnlContent.Controls.Add(this.pnlAvatar); this.pnlAvatar.Controls.Add(this.picAvatar); this.picAvatar.Controls.Add(this.lblUpload);
            this.pnlContent.Controls.Add(this.lblName); this.pnlContent.Controls.Add(this.pnlInputName); this.pnlInputName.Controls.Add(this.txtName);
            this.pnlContent.Controls.Add(this.lblDob); this.pnlContent.Controls.Add(this.pnlInputDob); this.pnlInputDob.Controls.Add(this.dtpDob);
            this.pnlContent.Controls.Add(this.lblGender); this.pnlContent.Controls.Add(this.btnGenderMale); this.pnlContent.Controls.Add(this.btnGenderFemale);
            this.pnlContent.Controls.Add(this.lblAddress); this.pnlContent.Controls.Add(this.pnlInputAddress); this.pnlInputAddress.Controls.Add(this.txtAddress);
            this.pnlContent.Controls.Add(this.lblSecAcademic);
            this.pnlContent.Controls.Add(this.lblClass); this.pnlContent.Controls.Add(this.pnlInputClass); this.pnlInputClass.Controls.Add(this.cboClass);
            this.pnlContent.Controls.Add(this.lblYear); this.pnlContent.Controls.Add(this.pnlInputYear); this.pnlInputYear.Controls.Add(this.cboYear);
            this.pnlContent.Controls.Add(this.lblSecParents);
            // Cha
            this.pnlContent.Controls.Add(this.lblFatherInfo);
            this.pnlContent.Controls.Add(this.lblFatherName); this.pnlContent.Controls.Add(this.pnlInputFatherName); this.pnlInputFatherName.Controls.Add(this.txtFatherName);
            this.pnlContent.Controls.Add(this.lblFatherPhone); this.pnlContent.Controls.Add(this.pnlInputFatherPhone); this.pnlInputFatherPhone.Controls.Add(this.txtFatherPhone);
            this.pnlContent.Controls.Add(this.lblFatherJob); this.pnlContent.Controls.Add(this.pnlInputFatherJob); this.pnlInputFatherJob.Controls.Add(this.txtFatherJob);
            // Mẹ
            this.pnlContent.Controls.Add(this.lblMotherInfo);
            this.pnlContent.Controls.Add(this.lblMotherName); this.pnlContent.Controls.Add(this.pnlInputMotherName); this.pnlInputMotherName.Controls.Add(this.txtMotherName);
            this.pnlContent.Controls.Add(this.lblMotherPhone); this.pnlContent.Controls.Add(this.pnlInputMotherPhone); this.pnlInputMotherPhone.Controls.Add(this.txtMotherPhone);
            this.pnlContent.Controls.Add(this.lblMotherJob); this.pnlContent.Controls.Add(this.pnlInputMotherJob); this.pnlInputMotherJob.Controls.Add(this.txtMotherJob);
            // Giám hộ
            this.pnlContent.Controls.Add(this.lblGuardianInfo);
            this.pnlContent.Controls.Add(this.lblGuardianName); this.pnlContent.Controls.Add(this.pnlInputGuardianName); this.pnlInputGuardianName.Controls.Add(this.txtGuardianName);
            this.pnlContent.Controls.Add(this.lblGuardianPhone); this.pnlContent.Controls.Add(this.pnlInputGuardianPhone); this.pnlInputGuardianPhone.Controls.Add(this.txtGuardianPhone);
            this.pnlContent.Controls.Add(this.lblGuardianRelation); this.pnlContent.Controls.Add(this.pnlInputGuardianRelation); this.pnlInputGuardianRelation.Controls.Add(this.txtGuardianRelation);
            this.pnlContent.Controls.Add(this.lblGuardianJob); this.pnlContent.Controls.Add(this.pnlInputGuardianJob); this.pnlInputGuardianJob.Controls.Add(this.txtGuardianJob);

            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader; private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Panel pnlFooter; private System.Windows.Forms.Button btnSave; private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlContent;
        // Public Controls
        public System.Windows.Forms.Label lblSecPersonal, lblSecAcademic, lblSecParents;
        public System.Windows.Forms.Panel pnlAvatar; public System.Windows.Forms.Label lblUpload; public System.Windows.Forms.PictureBox picAvatar;
        public System.Windows.Forms.Panel pnlInputName; public System.Windows.Forms.TextBox txtName;
        public System.Windows.Forms.Panel pnlInputDob; public System.Windows.Forms.DateTimePicker dtpDob;
        public System.Windows.Forms.Panel pnlInputAddress; public System.Windows.Forms.TextBox txtAddress;
        public System.Windows.Forms.Button btnGenderMale, btnGenderFemale;
        public System.Windows.Forms.Label lblClass; public System.Windows.Forms.Panel pnlInputClass; public System.Windows.Forms.ComboBox cboClass;
        public System.Windows.Forms.Label lblYear; public System.Windows.Forms.Panel pnlInputYear; public System.Windows.Forms.ComboBox cboYear;
        // Parents
        public System.Windows.Forms.Label lblFatherInfo, lblFatherName, lblFatherPhone, lblFatherJob;
        public System.Windows.Forms.Panel pnlInputFatherName, pnlInputFatherPhone, pnlInputFatherJob;
        public System.Windows.Forms.TextBox txtFatherName, txtFatherPhone, txtFatherJob;
        public System.Windows.Forms.Label lblMotherInfo, lblMotherName, lblMotherPhone, lblMotherJob;
        public System.Windows.Forms.Panel pnlInputMotherName, pnlInputMotherPhone, pnlInputMotherJob;
        public System.Windows.Forms.TextBox txtMotherName, txtMotherPhone, txtMotherJob;
        // Guardian
        public System.Windows.Forms.Label lblGuardianInfo, lblGuardianName, lblGuardianPhone, lblGuardianJob, lblGuardianRelation;
        public System.Windows.Forms.Panel pnlInputGuardianName, pnlInputGuardianPhone, pnlInputGuardianJob, pnlInputGuardianRelation;
        public System.Windows.Forms.TextBox txtGuardianName, txtGuardianPhone, txtGuardianJob, txtGuardianRelation;
        // Labels
        private System.Windows.Forms.Label lblName, lblDob, lblGender, lblAddress;
    }
}