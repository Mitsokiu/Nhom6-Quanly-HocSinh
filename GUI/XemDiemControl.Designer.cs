namespace GUI
{
    partial class XemDiemControl
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 8.5D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 7.8D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 9D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 7.2D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint5 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 8D);
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelMain = new System.Windows.Forms.Panel();
            this.cmbMonHoc = new System.Windows.Forms.ComboBox();
            this.panelTrungBinh = new System.Windows.Forms.Panel();
            this.lblTBMonValue = new System.Windows.Forms.Label();
            this.lblTBMonTitle = new System.Windows.Forms.Label();
            this.dgvDiem = new System.Windows.Forms.DataGridView();
            this.colLoaiDiem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHeSo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiemSo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgayKiemTra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbHocKy = new System.Windows.Forms.ComboBox();
            this.cmbNamHoc = new System.Windows.Forms.ComboBox();
            this.btnInBangDiem = new System.Windows.Forms.Button();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelRightSidebar = new System.Windows.Forms.Panel();
            this.panelChart = new System.Windows.Forms.Panel();
            this.chartTienTrinh = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblChartTitle = new System.Windows.Forms.Label();
            this.panelHanhKiem = new System.Windows.Forms.Panel();
            this.lblHanhKiemValue = new System.Windows.Forms.Label();
            this.lblHanhKiemTitle = new System.Windows.Forms.Label();
            this.picHanhKiem = new System.Windows.Forms.PictureBox();
            this.panelHocLuc = new System.Windows.Forms.Panel();
            this.lblHocLucValue = new System.Windows.Forms.Label();
            this.lblHocLucTitle = new System.Windows.Forms.Label();
            this.picHocLuc = new System.Windows.Forms.PictureBox();
            this.panelTBChung = new System.Windows.Forms.Panel();
            this.lblTBChungValue = new System.Windows.Forms.Label();
            this.lblTBChungTitle = new System.Windows.Forms.Label();
            this.picTBChung = new System.Windows.Forms.PictureBox();
            this.lblRightSidebarTitle = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.panelTrungBinh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiem)).BeginInit();
            this.panelRightSidebar.SuspendLayout();
            this.panelChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTienTrinh)).BeginInit();
            this.panelHanhKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHanhKiem)).BeginInit();
            this.panelHocLuc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHocLuc)).BeginInit();
            this.panelTBChung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTBChung)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Controls.Add(this.cmbMonHoc);
            this.panelMain.Controls.Add(this.panelTrungBinh);
            this.panelMain.Controls.Add(this.dgvDiem);
            this.panelMain.Controls.Add(this.cmbHocKy);
            this.panelMain.Controls.Add(this.cmbNamHoc);
            this.panelMain.Controls.Add(this.btnInBangDiem);
            this.panelMain.Controls.Add(this.lblSubtitle);
            this.panelMain.Controls.Add(this.lblTitle);
            this.panelMain.Location = new System.Drawing.Point(25, 25);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(630, 700);
            this.panelMain.TabIndex = 0;
            // 
            // cmbMonHoc
            // 
            this.cmbMonHoc.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbMonHoc.FormattingEnabled = true;
            this.cmbMonHoc.Items.AddRange(new object[] {
            "Toán",
            "Ngữ Văn",
            "Anh Văn",
            "Vật Lý",
            "Hóa Học",
            "Sinh Học",
            "Lịch Sử",
            "Địa Lý",
            "GDCD"});
            this.cmbMonHoc.Location = new System.Drawing.Point(25, 180);
            this.cmbMonHoc.Name = "cmbMonHoc";
            this.cmbMonHoc.Size = new System.Drawing.Size(325, 25);
            this.cmbMonHoc.TabIndex = 8;
            this.cmbMonHoc.Text = "Chọn môn học: Toán";
            // 
            // panelTrungBinh
            // 
            this.panelTrungBinh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTrungBinh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.panelTrungBinh.Controls.Add(this.lblTBMonValue);
            this.panelTrungBinh.Controls.Add(this.lblTBMonTitle);
            this.panelTrungBinh.Location = new System.Drawing.Point(25, 615);
            this.panelTrungBinh.Name = "panelTrungBinh";
            this.panelTrungBinh.Size = new System.Drawing.Size(580, 60);
            this.panelTrungBinh.TabIndex = 7;
            // 
            // lblTBMonValue
            // 
            this.lblTBMonValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTBMonValue.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTBMonValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.lblTBMonValue.Location = new System.Drawing.Point(500, 16);
            this.lblTBMonValue.Name = "lblTBMonValue";
            this.lblTBMonValue.Size = new System.Drawing.Size(60, 25);
            this.lblTBMonValue.TabIndex = 1;
            this.lblTBMonValue.Text = "8.1";
            this.lblTBMonValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTBMonTitle
            // 
            this.lblTBMonTitle.AutoSize = true;
            this.lblTBMonTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTBMonTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.lblTBMonTitle.Location = new System.Drawing.Point(20, 19);
            this.lblTBMonTitle.Name = "lblTBMonTitle";
            this.lblTBMonTitle.Size = new System.Drawing.Size(225, 21);
            this.lblTBMonTitle.TabIndex = 0;
            this.lblTBMonTitle.Text = "Điểm Trung Bình Môn Toán";
            // 
            // dgvDiem
            // 
            this.dgvDiem.AllowUserToAddRows = false;
            this.dgvDiem.AllowUserToDeleteRows = false;
            this.dgvDiem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDiem.BackgroundColor = System.Drawing.Color.White;
            this.dgvDiem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDiem.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDiem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDiem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDiem.ColumnHeadersHeight = 40;
            this.dgvDiem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLoaiDiem,
            this.colHeSo,
            this.colDiemSo,
            this.colNgayKiemTra});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDiem.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDiem.EnableHeadersVisualStyles = false;
            this.dgvDiem.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvDiem.Location = new System.Drawing.Point(25, 230);
            this.dgvDiem.Name = "dgvDiem";
            this.dgvDiem.ReadOnly = true;
            this.dgvDiem.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDiem.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDiem.RowTemplate.Height = 40;
            this.dgvDiem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDiem.Size = new System.Drawing.Size(580, 370);
            this.dgvDiem.TabIndex = 6;
            // 
            // colLoaiDiem
            // 
            this.colLoaiDiem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colLoaiDiem.HeaderText = "Loại điểm";
            this.colLoaiDiem.Name = "colLoaiDiem";
            this.colLoaiDiem.ReadOnly = true;
            // 
            // colHeSo
            // 
            this.colHeSo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colHeSo.HeaderText = "Hệ số";
            this.colHeSo.Name = "colHeSo";
            this.colHeSo.ReadOnly = true;
            this.colHeSo.Width = 84;
            // 
            // colDiemSo
            // 
            this.colDiemSo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDiemSo.HeaderText = "Điểm số";
            this.colDiemSo.Name = "colDiemSo";
            this.colDiemSo.ReadOnly = true;
            this.colDiemSo.Width = 99;
            // 
            // colNgayKiemTra
            // 
            this.colNgayKiemTra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNgayKiemTra.HeaderText = "Ngày kiểm tra";
            this.colNgayKiemTra.Name = "colNgayKiemTra";
            this.colNgayKiemTra.ReadOnly = true;
            // 
            // cmbHocKy
            // 
            this.cmbHocKy.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbHocKy.FormattingEnabled = true;
            this.cmbHocKy.Items.AddRange(new object[] {
            "Học kỳ 1",
            "Học kỳ 2"});
            this.cmbHocKy.Location = new System.Drawing.Point(200, 140);
            this.cmbHocKy.Name = "cmbHocKy";
            this.cmbHocKy.Size = new System.Drawing.Size(150, 25);
            this.cmbHocKy.TabIndex = 4;
            this.cmbHocKy.Text = "Học kỳ 1";
            // 
            // cmbNamHoc
            // 
            this.cmbNamHoc.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNamHoc.FormattingEnabled = true;
            this.cmbNamHoc.Items.AddRange(new object[] {
            "2023-2024",
            "2024-2025"});
            this.cmbNamHoc.Location = new System.Drawing.Point(25, 140);
            this.cmbNamHoc.Name = "cmbNamHoc";
            this.cmbNamHoc.Size = new System.Drawing.Size(150, 25);
            this.cmbNamHoc.TabIndex = 3;
            this.cmbNamHoc.Text = "Năm học: 2023-2024";
            // 
            // btnInBangDiem
            // 
            this.btnInBangDiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnInBangDiem.FlatAppearance.BorderSize = 0;
            this.btnInBangDiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInBangDiem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInBangDiem.ForeColor = System.Drawing.Color.White;
            this.btnInBangDiem.Location = new System.Drawing.Point(25, 80);
            this.btnInBangDiem.Name = "btnInBangDiem";
            this.btnInBangDiem.Size = new System.Drawing.Size(150, 40);
            this.btnInBangDiem.TabIndex = 2;
            this.btnInBangDiem.Text = "In Bảng Điểm";
            this.btnInBangDiem.UseVisualStyleBackColor = false;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle.ForeColor = System.Drawing.Color.Gray;
            this.lblSubtitle.Location = new System.Drawing.Point(25, 50);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(378, 17);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Xem lại kết quả học tập của bạn theo từng học kỳ và môn học.";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(20, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(277, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Bảng Điểm Chi Tiết";
            // 
            // panelRightSidebar
            // 
            this.panelRightSidebar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRightSidebar.Controls.Add(this.panelChart);
            this.panelRightSidebar.Controls.Add(this.panelHanhKiem);
            this.panelRightSidebar.Controls.Add(this.panelHocLuc);
            this.panelRightSidebar.Controls.Add(this.panelTBChung);
            this.panelRightSidebar.Controls.Add(this.lblRightSidebarTitle);
            this.panelRightSidebar.Location = new System.Drawing.Point(675, 25);
            this.panelRightSidebar.Name = "panelRightSidebar";
            this.panelRightSidebar.Size = new System.Drawing.Size(300, 700);
            this.panelRightSidebar.TabIndex = 1;
            // 
            // panelChart
            // 
            this.panelChart.BackColor = System.Drawing.Color.White;
            this.panelChart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelChart.Controls.Add(this.chartTienTrinh);
            this.panelChart.Controls.Add(this.lblChartTitle);
            this.panelChart.Location = new System.Drawing.Point(0, 400);
            this.panelChart.Name = "panelChart";
            this.panelChart.Size = new System.Drawing.Size(300, 300);
            this.panelChart.TabIndex = 4;
            // 
            // chartTienTrinh
            // 
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 8F);
            chartArea1.AxisX.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisX.MajorTickMark.Enabled = false;
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisY.LabelStyle.Enabled = false;
            chartArea1.AxisY.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisY.MajorTickMark.Enabled = false;
            chartArea1.BackColor = System.Drawing.Color.White;
            chartArea1.Name = "ChartArea1";
            this.chartTienTrinh.ChartAreas.Add(chartArea1);
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.Name = "Legend1";
            this.chartTienTrinh.Legends.Add(legend1);
            this.chartTienTrinh.Location = new System.Drawing.Point(15, 50);
            this.chartTienTrinh.Name = "chartTienTrinh";
            series1.ChartArea = "ChartArea1";
            series1.IsValueShownAsLabel = true;
            series1.Legend = "Legend1";
            series1.Name = "Học Kỳ 1";
            dataPoint1.AxisLabel = "Toán";
            dataPoint2.AxisLabel = "Văn";
            dataPoint3.AxisLabel = "Anh";
            dataPoint4.AxisLabel = "Lý";
            dataPoint5.AxisLabel = "Hóa";
            series1.Points.Add(dataPoint1);
            series1.Points.Add(dataPoint2);
            series1.Points.Add(dataPoint3);
            series1.Points.Add(dataPoint4);
            series1.Points.Add(dataPoint5);
            this.chartTienTrinh.Series.Add(series1);
            this.chartTienTrinh.Size = new System.Drawing.Size(270, 235);
            this.chartTienTrinh.TabIndex = 2;
            this.chartTienTrinh.Text = "chart1";
            // 
            // lblChartTitle
            // 
            this.lblChartTitle.AutoSize = true;
            this.lblChartTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChartTitle.Location = new System.Drawing.Point(15, 15);
            this.lblChartTitle.Name = "lblChartTitle";
            this.lblChartTitle.Size = new System.Drawing.Size(149, 21);
            this.lblChartTitle.TabIndex = 1;
            this.lblChartTitle.Text = "Tiến Trình Học Tập";
            // 
            // panelHanhKiem
            // 
            this.panelHanhKiem.BackColor = System.Drawing.Color.White;
            this.panelHanhKiem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelHanhKiem.Controls.Add(this.lblHanhKiemValue);
            this.panelHanhKiem.Controls.Add(this.lblHanhKiemTitle);
            this.panelHanhKiem.Controls.Add(this.picHanhKiem);
            this.panelHanhKiem.Location = new System.Drawing.Point(0, 280);
            this.panelHanhKiem.Name = "panelHanhKiem";
            this.panelHanhKiem.Size = new System.Drawing.Size(300, 100);
            this.panelHanhKiem.TabIndex = 3;
            // 
            // lblHanhKiemValue
            // 
            this.lblHanhKiemValue.AutoSize = true;
            this.lblHanhKiemValue.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHanhKiemValue.Location = new System.Drawing.Point(80, 50);
            this.lblHanhKiemValue.Name = "lblHanhKiemValue";
            this.lblHanhKiemValue.Size = new System.Drawing.Size(46, 30);
            this.lblHanhKiemValue.TabIndex = 2;
            this.lblHanhKiemValue.Text = "Tốt";
            // 
            // lblHanhKiemTitle
            // 
            this.lblHanhKiemTitle.AutoSize = true;
            this.lblHanhKiemTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHanhKiemTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblHanhKiemTitle.Location = new System.Drawing.Point(80, 25);
            this.lblHanhKiemTitle.Name = "lblHanhKiemTitle";
            this.lblHanhKiemTitle.Size = new System.Drawing.Size(74, 17);
            this.lblHanhKiemTitle.TabIndex = 1;
            this.lblHanhKiemTitle.Text = "Hạnh Kiểm";
            // 
            // picHanhKiem
            // 
            this.picHanhKiem.Location = new System.Drawing.Point(20, 25);
            this.picHanhKiem.Name = "picHanhKiem";
            this.picHanhKiem.Size = new System.Drawing.Size(50, 50);
            this.picHanhKiem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHanhKiem.TabIndex = 0;
            this.picHanhKiem.TabStop = false;
            // 
            // panelHocLuc
            // 
            this.panelHocLuc.BackColor = System.Drawing.Color.White;
            this.panelHocLuc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelHocLuc.Controls.Add(this.lblHocLucValue);
            this.panelHocLuc.Controls.Add(this.lblHocLucTitle);
            this.panelHocLuc.Controls.Add(this.picHocLuc);
            this.panelHocLuc.Location = new System.Drawing.Point(0, 165);
            this.panelHocLuc.Name = "panelHocLuc";
            this.panelHocLuc.Size = new System.Drawing.Size(300, 100);
            this.panelHocLuc.TabIndex = 2;
            // 
            // lblHocLucValue
            // 
            this.lblHocLucValue.AutoSize = true;
            this.lblHocLucValue.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHocLucValue.Location = new System.Drawing.Point(80, 50);
            this.lblHocLucValue.Name = "lblHocLucValue";
            this.lblHocLucValue.Size = new System.Drawing.Size(58, 30);
            this.lblHocLucValue.TabIndex = 2;
            this.lblHocLucValue.Text = "Giỏi";
            // 
            // lblHocLucTitle
            // 
            this.lblHocLucTitle.AutoSize = true;
            this.lblHocLucTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHocLucTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblHocLucTitle.Location = new System.Drawing.Point(80, 25);
            this.lblHocLucTitle.Name = "lblHocLucTitle";
            this.lblHocLucTitle.Size = new System.Drawing.Size(109, 17);
            this.lblHocLucTitle.TabIndex = 1;
            this.lblHocLucTitle.Text = "Xếp Loại Học Lực";
            // 
            // picHocLuc
            // 
            this.picHocLuc.Location = new System.Drawing.Point(20, 25);
            this.picHocLuc.Name = "picHocLuc";
            this.picHocLuc.Size = new System.Drawing.Size(50, 50);
            this.picHocLuc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHocLuc.TabIndex = 0;
            this.picHocLuc.TabStop = false;
            // 
            // panelTBChung
            // 
            this.panelTBChung.BackColor = System.Drawing.Color.White;
            this.panelTBChung.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTBChung.Controls.Add(this.lblTBChungValue);
            this.panelTBChung.Controls.Add(this.lblTBChungTitle);
            this.panelTBChung.Controls.Add(this.picTBChung);
            this.panelTBChung.Location = new System.Drawing.Point(0, 50);
            this.panelTBChung.Name = "panelTBChung";
            this.panelTBChung.Size = new System.Drawing.Size(300, 100);
            this.panelTBChung.TabIndex = 1;
            // 
            // lblTBChungValue
            // 
            this.lblTBChungValue.AutoSize = true;
            this.lblTBChungValue.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTBChungValue.Location = new System.Drawing.Point(80, 50);
            this.lblTBChungValue.Name = "lblTBChungValue";
            this.lblTBChungValue.Size = new System.Drawing.Size(49, 30);
            this.lblTBChungValue.TabIndex = 2;
            this.lblTBChungValue.Text = "8.5";
            // 
            // lblTBChungTitle
            // 
            this.lblTBChungTitle.AutoSize = true;
            this.lblTBChungTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTBChungTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblTBChungTitle.Location = new System.Drawing.Point(80, 25);
            this.lblTBChungTitle.Name = "lblTBChungTitle";
            this.lblTBChungTitle.Size = new System.Drawing.Size(107, 17);
            this.lblTBChungTitle.TabIndex = 1;
            this.lblTBChungTitle.Text = "TB Chung Học Kỳ";
            // 
            // picTBChung
            // 
            this.picTBChung.Location = new System.Drawing.Point(20, 25);
            this.picTBChung.Name = "picTBChung";
            this.picTBChung.Size = new System.Drawing.Size(50, 50);
            this.picTBChung.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picTBChung.TabIndex = 0;
            this.picTBChung.TabStop = false;
            // 
            // lblRightSidebarTitle
            // 
            this.lblRightSidebarTitle.AutoSize = true;
            this.lblRightSidebarTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRightSidebarTitle.Location = new System.Drawing.Point(0, 15);
            this.lblRightSidebarTitle.Name = "lblRightSidebarTitle";
            this.lblRightSidebarTitle.Size = new System.Drawing.Size(155, 21);
            this.lblRightSidebarTitle.TabIndex = 0;
            this.lblRightSidebarTitle.Text = "Tổng Kết Học Kỳ 1";
            // 
            // XemDiemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.panelRightSidebar);
            this.Controls.Add(this.panelMain);
            this.Name = "XemDiemControl";
            this.Size = new System.Drawing.Size(1000, 750);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelTrungBinh.ResumeLayout(false);
            this.panelTrungBinh.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiem)).EndInit();
            this.panelRightSidebar.ResumeLayout(false);
            this.panelRightSidebar.PerformLayout();
            this.panelChart.ResumeLayout(false);
            this.panelChart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTienTrinh)).EndInit();
            this.panelHanhKiem.ResumeLayout(false);
            this.panelHanhKiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHanhKiem)).EndInit();
            this.panelHocLuc.ResumeLayout(false);
            this.panelHocLuc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHocLuc)).EndInit();
            this.panelTBChung.ResumeLayout(false);
            this.panelTBChung.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTBChung)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Button btnInBangDiem;
        private System.Windows.Forms.ComboBox cmbHocKy;
        private System.Windows.Forms.ComboBox cmbNamHoc;
        private System.Windows.Forms.DataGridView dgvDiem;
        private System.Windows.Forms.Panel panelTrungBinh;
        private System.Windows.Forms.Label lblTBMonValue;
        private System.Windows.Forms.Label lblTBMonTitle;
        private System.Windows.Forms.Panel panelRightSidebar;
        private System.Windows.Forms.Label lblRightSidebarTitle;
        private System.Windows.Forms.Panel panelTBChung;
        private System.Windows.Forms.PictureBox picTBChung;
        private System.Windows.Forms.Label lblTBChungValue;
        private System.Windows.Forms.Label lblTBChungTitle;
        private System.Windows.Forms.Panel panelHanhKiem;
        private System.Windows.Forms.Label lblHanhKiemValue;
        private System.Windows.Forms.Label lblHanhKiemTitle;
        private System.Windows.Forms.PictureBox picHanhKiem;
        private System.Windows.Forms.Panel panelHocLuc;
        private System.Windows.Forms.Label lblHocLucValue;
        private System.Windows.Forms.Label lblHocLucTitle;
        private System.Windows.Forms.PictureBox picHocLuc;
        private System.Windows.Forms.Panel panelChart;
        private System.Windows.Forms.Label lblChartTitle;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTienTrinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoaiDiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHeSo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiemSo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayKiemTra;
        private System.Windows.Forms.ComboBox cmbMonHoc;
    }
}