namespace GUI.UserControls
{
    partial class UC_GVCN_DiemDanh
    {
        private System.ComponentModel.IContainer components = null;

        // --- CÁC PANEL CHÍNH ---
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlRight;

        // --- HEADER ---
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSemester;
        private System.Windows.Forms.ComboBox cbbYear;
        private System.Windows.Forms.Label lblClassTitle;
        private System.Windows.Forms.Label lblClassName; // Label hiển thị tên lớp cứng
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate; // Chọn ngày điểm danh
        private System.Windows.Forms.Label lblListTitle;
        private System.Windows.Forms.DataGridView dgvStudentList;

        // --- PHẢI (CHI TIẾT & LỊCH SỬ) ---
        private System.Windows.Forms.Panel pnlDetailCard;
        private System.Windows.Forms.Label lblDetailName;
        private System.Windows.Forms.Label lblStatusTitle;

        // Radio Buttons (Trạng thái)
        private System.Windows.Forms.Panel pnlStatusGroup;
        private System.Windows.Forms.RadioButton radAbsentPermit;
        private System.Windows.Forms.RadioButton radAbsentNoPermit;
        private System.Windows.Forms.RadioButton radLate;

        // Ghi chú & Nút
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblClassTitle = new System.Windows.Forms.Label();
            this.lblClassName = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblSemester = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.cbbYear = new System.Windows.Forms.ComboBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlSearchBox = new System.Windows.Forms.Panel();
            this.TxtSearch = new System.Windows.Forms.TextBox();
            this.lblListTitle = new System.Windows.Forms.Label();
            this.dgvStudentList = new System.Windows.Forms.DataGridView();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlHistory = new System.Windows.Forms.Panel();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.lblHistoryTitle = new System.Windows.Forms.Label();
            this.pnlDetailCard = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblDetailName = new System.Windows.Forms.Label();
            this.lblStatusTitle = new System.Windows.Forms.Label();
            this.pnlStatusGroup = new System.Windows.Forms.Panel();
            this.radPresent = new System.Windows.Forms.RadioButton();
            this.radAbsentPermit = new System.Windows.Forms.RadioButton();
            this.radAbsentNoPermit = new System.Windows.Forms.RadioButton();
            this.radLate = new System.Windows.Forms.RadioButton();
            this.lblNote = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.picSearchIcon = new System.Windows.Forms.PictureBox();
            this.btnExportPDF = new System.Windows.Forms.Button();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.btnImportExcel = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlSearchBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentList)).BeginInit();
            this.pnlRight.SuspendLayout();
            this.pnlHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.pnlDetailCard.SuspendLayout();
            this.pnlStatusGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSearchIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlHeader.Controls.Add(this.btnExportPDF);
            this.pnlHeader.Controls.Add(this.btnExportExcel);
            this.pnlHeader.Controls.Add(this.btnImportExcel);
            this.pnlHeader.Controls.Add(this.panel1);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(20, 20);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1463, 80);
            this.pnlHeader.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblClassTitle);
            this.panel1.Controls.Add(this.lblClassName);
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Controls.Add(this.lblSemester);
            this.panel1.Controls.Add(this.dtpDate);
            this.panel1.Controls.Add(this.cbbYear);
            this.panel1.Location = new System.Drawing.Point(7, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(905, 35);
            this.panel1.TabIndex = 7;
            // 
            // lblClassTitle
            // 
            this.lblClassTitle.AutoSize = true;
            this.lblClassTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblClassTitle.Location = new System.Drawing.Point(305, 7);
            this.lblClassTitle.Name = "lblClassTitle";
            this.lblClassTitle.Size = new System.Drawing.Size(52, 28);
            this.lblClassTitle.TabIndex = 3;
            this.lblClassTitle.Text = "Lớp:";
            // 
            // lblClassName
            // 
            this.lblClassName.AutoSize = true;
            this.lblClassName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblClassName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.lblClassName.Location = new System.Drawing.Point(330, 8);
            this.lblClassName.Name = "lblClassName";
            this.lblClassName.Size = new System.Drawing.Size(27, 28);
            this.lblClassName.TabIndex = 4;
            this.lblClassName.Text = "...";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDate.Location = new System.Drawing.Point(563, 8);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(67, 28);
            this.lblDate.TabIndex = 5;
            this.lblDate.Text = "Ngày:";
            // 
            // lblSemester
            // 
            this.lblSemester.AutoSize = true;
            this.lblSemester.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSemester.Location = new System.Drawing.Point(-3, 5);
            this.lblSemester.Name = "lblSemester";
            this.lblSemester.Size = new System.Drawing.Size(102, 28);
            this.lblSemester.TabIndex = 1;
            this.lblSemester.Text = "Năm học:";
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd/MM/yyyy";
            this.dtpDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(657, 2);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(150, 34);
            this.dtpDate.TabIndex = 6;
            // 
            // cbbYear
            // 
            this.cbbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbYear.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbbYear.Location = new System.Drawing.Point(96, 5);
            this.cbbYear.Name = "cbbYear";
            this.cbbYear.Size = new System.Drawing.Size(208, 36);
            this.cbbYear.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(395, 54);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Điểm danh học sinh";
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(20, 100);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.pnlLeft);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.pnlRight);
            this.splitContainer.Size = new System.Drawing.Size(1463, 680);
            this.splitContainer.SplitterDistance = 545;
            this.splitContainer.SplitterWidth = 20;
            this.splitContainer.TabIndex = 0;
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.White;
            this.pnlLeft.Controls.Add(this.pnlSearchBox);
            this.pnlLeft.Controls.Add(this.lblListTitle);
            this.pnlLeft.Controls.Add(this.dgvStudentList);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(545, 680);
            this.pnlLeft.TabIndex = 0;
            // 
            // pnlSearchBox
            // 
            this.pnlSearchBox.BackColor = System.Drawing.Color.White;
            this.pnlSearchBox.Controls.Add(this.TxtSearch);
            this.pnlSearchBox.Controls.Add(this.picSearchIcon);
            this.pnlSearchBox.Location = new System.Drawing.Point(19, 39);
            this.pnlSearchBox.Name = "pnlSearchBox";
            this.pnlSearchBox.Size = new System.Drawing.Size(511, 40);
            this.pnlSearchBox.TabIndex = 3;
            // 
            // TxtSearch
            // 
            this.TxtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtSearch.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.TxtSearch.ForeColor = System.Drawing.Color.Gray;
            this.TxtSearch.Location = new System.Drawing.Point(49, 8);
            this.TxtSearch.Name = "TxtSearch";
            this.TxtSearch.Size = new System.Drawing.Size(340, 30);
            this.TxtSearch.TabIndex = 0;
            this.TxtSearch.Text = "Tìm kiếm học sinh...";
            // 
            // lblListTitle
            // 
            this.lblListTitle.AutoSize = true;
            this.lblListTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblListTitle.Location = new System.Drawing.Point(15, 15);
            this.lblListTitle.Name = "lblListTitle";
            this.lblListTitle.Size = new System.Drawing.Size(233, 32);
            this.lblListTitle.TabIndex = 0;
            this.lblListTitle.Text = "Danh sách học sinh";
            // 
            // dgvStudentList
            // 
            this.dgvStudentList.AllowUserToAddRows = false;
            this.dgvStudentList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStudentList.BackgroundColor = System.Drawing.Color.White;
            this.dgvStudentList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvStudentList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvStudentList.ColumnHeadersHeight = 34;
            this.dgvStudentList.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(10);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStudentList.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStudentList.Location = new System.Drawing.Point(19, 85);
            this.dgvStudentList.MultiSelect = false;
            this.dgvStudentList.Name = "dgvStudentList";
            this.dgvStudentList.RowHeadersVisible = false;
            this.dgvStudentList.RowHeadersWidth = 62;
            this.dgvStudentList.RowTemplate.Height = 50;
            this.dgvStudentList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStudentList.Size = new System.Drawing.Size(511, 575);
            this.dgvStudentList.TabIndex = 2;
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.Transparent;
            this.pnlRight.Controls.Add(this.pnlHistory);
            this.pnlRight.Controls.Add(this.pnlDetailCard);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(0, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(898, 680);
            this.pnlRight.TabIndex = 0;
            // 
            // pnlHistory
            // 
            this.pnlHistory.BackColor = System.Drawing.SystemColors.Window;
            this.pnlHistory.Controls.Add(this.dgvHistory);
            this.pnlHistory.Controls.Add(this.lblHistoryTitle);
            this.pnlHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHistory.Location = new System.Drawing.Point(0, 330);
            this.pnlHistory.Name = "pnlHistory";
            this.pnlHistory.Padding = new System.Windows.Forms.Padding(20);
            this.pnlHistory.Size = new System.Drawing.Size(898, 350);
            this.pnlHistory.TabIndex = 1;
            // 
            // dgvHistory
            // 
            this.dgvHistory.AllowUserToAddRows = false;
            this.dgvHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHistory.ColumnHeadersHeight = 40;
            this.dgvHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistory.EnableHeadersVisualStyles = false;
            this.dgvHistory.Location = new System.Drawing.Point(20, 60);
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.RowHeadersVisible = false;
            this.dgvHistory.RowHeadersWidth = 62;
            this.dgvHistory.Size = new System.Drawing.Size(858, 270);
            this.dgvHistory.TabIndex = 1;
            // 
            // lblHistoryTitle
            // 
            this.lblHistoryTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHistoryTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblHistoryTitle.Location = new System.Drawing.Point(20, 20);
            this.lblHistoryTitle.Name = "lblHistoryTitle";
            this.lblHistoryTitle.Size = new System.Drawing.Size(858, 40);
            this.lblHistoryTitle.TabIndex = 0;
            this.lblHistoryTitle.Text = "Danh sách vắng / trễ";
            this.lblHistoryTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlDetailCard
            // 
            this.pnlDetailCard.BackColor = System.Drawing.Color.White;
            this.pnlDetailCard.Controls.Add(this.btnSave);
            this.pnlDetailCard.Controls.Add(this.lblDetailName);
            this.pnlDetailCard.Controls.Add(this.lblStatusTitle);
            this.pnlDetailCard.Controls.Add(this.pnlStatusGroup);
            this.pnlDetailCard.Controls.Add(this.lblNote);
            this.pnlDetailCard.Controls.Add(this.txtNote);
            this.pnlDetailCard.Controls.Add(this.btnCancel);
            this.pnlDetailCard.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDetailCard.Location = new System.Drawing.Point(0, 0);
            this.pnlDetailCard.Name = "pnlDetailCard";
            this.pnlDetailCard.Padding = new System.Windows.Forms.Padding(20);
            this.pnlDetailCard.Size = new System.Drawing.Size(898, 330);
            this.pnlDetailCard.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(735, 280);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(140, 40);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // lblDetailName
            // 
            this.lblDetailName.AutoSize = true;
            this.lblDetailName.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblDetailName.Location = new System.Drawing.Point(20, 20);
            this.lblDetailName.Name = "lblDetailName";
            this.lblDetailName.Size = new System.Drawing.Size(318, 38);
            this.lblDetailName.TabIndex = 0;
            this.lblDetailName.Text = "Điểm danh học sinh: ...";
            // 
            // lblStatusTitle
            // 
            this.lblStatusTitle.AutoSize = true;
            this.lblStatusTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStatusTitle.Location = new System.Drawing.Point(20, 70);
            this.lblStatusTitle.Name = "lblStatusTitle";
            this.lblStatusTitle.Size = new System.Drawing.Size(215, 28);
            this.lblStatusTitle.TabIndex = 1;
            this.lblStatusTitle.Text = "Trạng thái điểm danh";
            // 
            // pnlStatusGroup
            // 
            this.pnlStatusGroup.Controls.Add(this.radPresent);
            this.pnlStatusGroup.Controls.Add(this.radAbsentPermit);
            this.pnlStatusGroup.Controls.Add(this.radAbsentNoPermit);
            this.pnlStatusGroup.Controls.Add(this.radLate);
            this.pnlStatusGroup.Location = new System.Drawing.Point(25, 92);
            this.pnlStatusGroup.Name = "pnlStatusGroup";
            this.pnlStatusGroup.Size = new System.Drawing.Size(854, 40);
            this.pnlStatusGroup.TabIndex = 2;
            // 
            // radPresent
            // 
            this.radPresent.AutoSize = true;
            this.radPresent.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.radPresent.Location = new System.Drawing.Point(18, 5);
            this.radPresent.Name = "radPresent";
            this.radPresent.Size = new System.Drawing.Size(100, 32);
            this.radPresent.TabIndex = 4;
            this.radPresent.Text = "Có mặt";
            // 
            // radAbsentPermit
            // 
            this.radAbsentPermit.AutoSize = true;
            this.radAbsentPermit.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.radAbsentPermit.Location = new System.Drawing.Point(166, 3);
            this.radAbsentPermit.Name = "radAbsentPermit";
            this.radAbsentPermit.Size = new System.Drawing.Size(156, 32);
            this.radAbsentPermit.TabIndex = 1;
            this.radAbsentPermit.Text = "Nghỉ có phép";
            // 
            // radAbsentNoPermit
            // 
            this.radAbsentNoPermit.AutoSize = true;
            this.radAbsentNoPermit.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.radAbsentNoPermit.Location = new System.Drawing.Point(378, 5);
            this.radAbsentNoPermit.Name = "radAbsentNoPermit";
            this.radAbsentNoPermit.Size = new System.Drawing.Size(191, 32);
            this.radAbsentNoPermit.TabIndex = 2;
            this.radAbsentNoPermit.Text = "Nghỉ không phép";
            // 
            // radLate
            // 
            this.radLate.AutoSize = true;
            this.radLate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.radLate.Location = new System.Drawing.Point(720, 3);
            this.radLate.Name = "radLate";
            this.radLate.Size = new System.Drawing.Size(85, 32);
            this.radLate.TabIndex = 3;
            this.radLate.Text = "Đi trễ";
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNote.Location = new System.Drawing.Point(20, 150);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(145, 28);
            this.lblNote.TabIndex = 3;
            this.lblNote.Text = "Lý do (nếu có)";
            // 
            // txtNote
            // 
            this.txtNote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.txtNote.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNote.Location = new System.Drawing.Point(20, 172);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(859, 80);
            this.txtNote.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancel.Location = new System.Drawing.Point(1218, 280);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 40);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // picSearchIcon
            // 
            this.picSearchIcon.Image = global::GUI.Properties.Resources.search_32;
            this.picSearchIcon.Location = new System.Drawing.Point(10, 8);
            this.picSearchIcon.Name = "picSearchIcon";
            this.picSearchIcon.Size = new System.Drawing.Size(24, 24);
            this.picSearchIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSearchIcon.TabIndex = 1;
            this.picSearchIcon.TabStop = false;
            // 
            // btnExportPDF
            // 
            this.btnExportPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportPDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnExportPDF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportPDF.FlatAppearance.BorderSize = 0;
            this.btnExportPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportPDF.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExportPDF.ForeColor = System.Drawing.Color.White;
            this.btnExportPDF.Image = global::GUI.Properties.Resources.pdf_32;
            this.btnExportPDF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportPDF.Location = new System.Drawing.Point(990, 4);
            this.btnExportPDF.Name = "btnExportPDF";
            this.btnExportPDF.Size = new System.Drawing.Size(150, 40);
            this.btnExportPDF.TabIndex = 11;
            this.btnExportPDF.Text = " Xuất PDF";
            this.btnExportPDF.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportPDF.UseVisualStyleBackColor = false;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnExportExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportExcel.FlatAppearance.BorderSize = 0;
            this.btnExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportExcel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExportExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportExcel.Image = global::GUI.Properties.Resources.xuatexcel_32;
            this.btnExportExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportExcel.Location = new System.Drawing.Point(1310, 4);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(150, 40);
            this.btnExportExcel.TabIndex = 9;
            this.btnExportExcel.Text = " Xuất Excel";
            this.btnExportExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportExcel.UseVisualStyleBackColor = false;
            // 
            // btnImportExcel
            // 
            this.btnImportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnImportExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImportExcel.FlatAppearance.BorderSize = 0;
            this.btnImportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportExcel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnImportExcel.ForeColor = System.Drawing.Color.White;
            this.btnImportExcel.Image = global::GUI.Properties.Resources.nhapexcel_32;
            this.btnImportExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImportExcel.Location = new System.Drawing.Point(1150, 4);
            this.btnImportExcel.Name = "btnImportExcel";
            this.btnImportExcel.Size = new System.Drawing.Size(150, 40);
            this.btnImportExcel.TabIndex = 10;
            this.btnImportExcel.Text = " Nhập Excel";
            this.btnImportExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImportExcel.UseVisualStyleBackColor = false;
            // 
            // UC_GVCN_DiemDanh
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.pnlHeader);
            this.Name = "UC_GVCN_DiemDanh";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Size = new System.Drawing.Size(1503, 800);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.pnlSearchBox.ResumeLayout(false);
            this.pnlSearchBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentList)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.pnlHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.pnlDetailCard.ResumeLayout(false);
            this.pnlDetailCard.PerformLayout();
            this.pnlStatusGroup.ResumeLayout(false);
            this.pnlStatusGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSearchIcon)).EndInit();
            this.ResumeLayout(false);

        }


        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlHistory;
        private System.Windows.Forms.Label lblHistoryTitle;
        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.Panel pnlSearchBox;
        private System.Windows.Forms.TextBox TxtSearch;
        private System.Windows.Forms.PictureBox picSearchIcon;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RadioButton radPresent;
        private System.Windows.Forms.Button btnExportPDF;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.Button btnImportExcel;
    }
}