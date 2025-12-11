namespace GUI.UserControls
{
    partial class UC_Admin_ThongKe
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();

            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabCoCau = new System.Windows.Forms.TabPage();
            this.splitContainerData = new System.Windows.Forms.SplitContainer();
            this.dgvStats = new System.Windows.Forms.DataGridView();
            this.chartStats = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelControl = new System.Windows.Forms.Panel();
            this.cboCriteria = new System.Windows.Forms.ComboBox();
            this.labelCriteria = new System.Windows.Forms.Label();
            this.panelSummary = new System.Windows.Forms.Panel();
            this.cardLop = new System.Windows.Forms.Panel();
            this.lblNumClasses = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cardGV = new System.Windows.Forms.Panel();
            this.lblNumTeachers = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cardHS = new System.Windows.Forms.Panel();
            this.lblNumStudents = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabDiemSo = new System.Windows.Forms.TabPage();
            this.tabHocPhi = new System.Windows.Forms.TabPage();

            this.tabControlMain.SuspendLayout();
            this.tabCoCau.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerData)).BeginInit();
            this.splitContainerData.Panel1.SuspendLayout();
            this.splitContainerData.Panel2.SuspendLayout();
            this.splitContainerData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartStats)).BeginInit();
            this.panelControl.SuspendLayout();
            this.panelSummary.SuspendLayout();
            this.cardLop.SuspendLayout();
            this.cardGV.SuspendLayout();
            this.cardHS.SuspendLayout();
            this.SuspendLayout();

            // tabControlMain
            this.tabControlMain.Controls.Add(this.tabCoCau);
            this.tabControlMain.Controls.Add(this.tabDiemSo);
            this.tabControlMain.Controls.Add(this.tabHocPhi);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1100, 700);
            this.tabControlMain.TabIndex = 0;

            // tabCoCau
            this.tabCoCau.Controls.Add(this.splitContainerData);
            this.tabCoCau.Controls.Add(this.panelControl);
            this.tabCoCau.Controls.Add(this.panelSummary);
            this.tabCoCau.Location = new System.Drawing.Point(4, 34);
            this.tabCoCau.Name = "tabCoCau";
            this.tabCoCau.Padding = new System.Windows.Forms.Padding(10);
            this.tabCoCau.Size = new System.Drawing.Size(1092, 662);
            this.tabCoCau.Text = "Thống Kê Cơ Cấu";
            this.tabCoCau.UseVisualStyleBackColor = true;

            // Thêm hoặc kiểm tra thuộc tính của tabDiemSo
            // tabDiemSo
            this.tabDiemSo.Location = new System.Drawing.Point(4, 34);
            this.tabDiemSo.Name = "tabDiemSo";
            this.tabDiemSo.Padding = new System.Windows.Forms.Padding(10);
            this.tabDiemSo.Size = new System.Drawing.Size(1092, 662);
            this.tabDiemSo.Text = "Thống Kê Điểm Số";
            this.tabDiemSo.UseVisualStyleBackColor = true;

            // 
            // tabHocPhi
            // 
            this.tabHocPhi.Location = new System.Drawing.Point(4, 34);
            this.tabHocPhi.Name = "tabHocPhi";
            this.tabHocPhi.Padding = new System.Windows.Forms.Padding(10);
            this.tabHocPhi.Size = new System.Drawing.Size(1092, 662);
            this.tabHocPhi.Text = "Thống Kê Học Phí"; // 
            this.tabHocPhi.UseVisualStyleBackColor = true;

            // panelSummary (3 Cards)
            this.panelSummary.Controls.Add(this.cardLop);
            this.panelSummary.Controls.Add(this.cardGV);
            this.panelSummary.Controls.Add(this.cardHS);
            this.panelSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSummary.Location = new System.Drawing.Point(10, 10);
            this.panelSummary.Name = "panelSummary";
            this.panelSummary.Size = new System.Drawing.Size(1072, 140);
            this.panelSummary.TabIndex = 0;

            // cardHS
            this.cardHS.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.cardHS.Controls.Add(this.lblNumStudents);
            this.cardHS.Controls.Add(this.label1);
            this.cardHS.Location = new System.Drawing.Point(0, 0);
            this.cardHS.Size = new System.Drawing.Size(300, 120);
            this.cardHS.TabIndex = 0;
            // label1
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Text = "TỔNG SỐ HS";
            // lblNumStudents
            this.lblNumStudents.AutoSize = true;
            this.lblNumStudents.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblNumStudents.ForeColor = System.Drawing.Color.White;
            this.lblNumStudents.Location = new System.Drawing.Point(15, 50);
            this.lblNumStudents.Text = "0";

            // cardGV
            this.cardGV.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.cardGV.Controls.Add(this.lblNumTeachers);
            this.cardGV.Controls.Add(this.label4);
            this.cardGV.Location = new System.Drawing.Point(320, 0);
            this.cardGV.Size = new System.Drawing.Size(300, 120);
            this.cardGV.TabIndex = 1;
            // label4
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(15, 15);
            this.label4.Text = "TỔNG SỐ GV";
            // lblNumTeachers
            this.lblNumTeachers.AutoSize = true;
            this.lblNumTeachers.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblNumTeachers.ForeColor = System.Drawing.Color.White;
            this.lblNumTeachers.Location = new System.Drawing.Point(15, 50);
            this.lblNumTeachers.Text = "0";

            // cardLop
            this.cardLop.BackColor = System.Drawing.Color.FromArgb(243, 156, 18);
            this.cardLop.Controls.Add(this.lblNumClasses);
            this.cardLop.Controls.Add(this.label6);
            this.cardLop.Location = new System.Drawing.Point(640, 0);
            this.cardLop.Size = new System.Drawing.Size(300, 120);
            this.cardLop.TabIndex = 2;
            // label6
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(15, 15);
            this.label6.Text = "TỔNG SỐ LỚP";
            // lblNumClasses
            this.lblNumClasses.AutoSize = true;
            this.lblNumClasses.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblNumClasses.ForeColor = System.Drawing.Color.White;
            this.lblNumClasses.Location = new System.Drawing.Point(15, 50);
            this.lblNumClasses.Text = "0";

            // panelControl (Chứa ComboBox)
            this.panelControl.Controls.Add(this.cboCriteria);
            this.panelControl.Controls.Add(this.labelCriteria);
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl.Location = new System.Drawing.Point(10, 150);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(1072, 60);
            this.panelControl.TabIndex = 1;

            // labelCriteria
            this.labelCriteria.AutoSize = true;
            this.labelCriteria.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular);
            this.labelCriteria.Location = new System.Drawing.Point(5, 18);
            this.labelCriteria.Name = "labelCriteria";
            this.labelCriteria.Size = new System.Drawing.Size(180, 28);
            this.labelCriteria.Text = "Chọn loại thống kê:";

            // cboCriteria
            this.cboCriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCriteria.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cboCriteria.FormattingEnabled = true;
            this.cboCriteria.Items.AddRange(new object[] { "Theo Giới Tính", "Theo Khối", "Theo Lớp" });
            this.cboCriteria.Location = new System.Drawing.Point(200, 15);
            this.cboCriteria.Name = "cboCriteria";
            this.cboCriteria.Size = new System.Drawing.Size(250, 33);
            this.cboCriteria.TabIndex = 1;

            // splitContainerData (Bảng trái - Biểu đồ phải)
            this.splitContainerData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerData.Location = new System.Drawing.Point(10, 210);
            this.splitContainerData.Name = "splitContainerData";

            // Panel1 - DataGridView
            this.splitContainerData.Panel1.Controls.Add(this.dgvStats);
            this.splitContainerData.Panel1.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);

            // Panel2 - Chart
            this.splitContainerData.Panel2.Controls.Add(this.chartStats);
            this.splitContainerData.Size = new System.Drawing.Size(1072, 442);
            this.splitContainerData.SplitterDistance = 400;
            this.splitContainerData.TabIndex = 2;

            // dgvStats
            this.dgvStats.AllowUserToAddRows = false;
            this.dgvStats.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStats.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.dgvStats.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStats.Location = new System.Drawing.Point(0, 0);
            this.dgvStats.Name = "dgvStats";
            this.dgvStats.ReadOnly = true;
            this.dgvStats.RowHeadersVisible = false;
            this.dgvStats.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStats.Size = new System.Drawing.Size(390, 442);
            this.dgvStats.TabIndex = 0;

            // chartStats
            chartArea1.Name = "ChartArea1";
            this.chartStats.ChartAreas.Add(chartArea1);
            this.chartStats.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartStats.Legends.Add(legend1);
            this.chartStats.Location = new System.Drawing.Point(0, 0);
            this.chartStats.Name = "chartStats";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartStats.Series.Add(series1);
            this.chartStats.Size = new System.Drawing.Size(668, 442);
            this.chartStats.TabIndex = 0;

            // UC_Admin_ThongKe
            this.Controls.Add(this.tabControlMain);
            this.Name = "UC_Admin_ThongKe";
            this.Size = new System.Drawing.Size(1100, 700);
            this.tabControlMain.ResumeLayout(false);
            this.tabCoCau.ResumeLayout(false);
            this.splitContainerData.Panel1.ResumeLayout(false);
            this.splitContainerData.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerData)).EndInit();
            this.splitContainerData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartStats)).EndInit();
            this.panelControl.ResumeLayout(false);
            this.panelControl.PerformLayout();
            this.panelSummary.ResumeLayout(false);
            this.cardLop.ResumeLayout(false);
            this.cardLop.PerformLayout();
            this.cardGV.ResumeLayout(false);
            this.cardGV.PerformLayout();
            this.cardHS.ResumeLayout(false);
            this.cardHS.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabCoCau;
        private System.Windows.Forms.TabPage tabDiemSo;
        private System.Windows.Forms.TabPage tabHocPhi;
        private System.Windows.Forms.Panel panelSummary;
        private System.Windows.Forms.Panel cardHS;
        private System.Windows.Forms.Label lblNumStudents;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel cardGV;
        private System.Windows.Forms.Label lblNumTeachers;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel cardLop;
        private System.Windows.Forms.Label lblNumClasses;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panelControl;
        private System.Windows.Forms.ComboBox cboCriteria;
        private System.Windows.Forms.Label labelCriteria;
        private System.Windows.Forms.SplitContainer splitContainerData;
        private System.Windows.Forms.DataGridView dgvStats;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartStats;
    }
}