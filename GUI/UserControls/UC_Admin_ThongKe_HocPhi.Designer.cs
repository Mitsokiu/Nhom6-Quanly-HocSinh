namespace GUI.UserControls
{
    partial class UC_Admin_ThongKe_HocPhi
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();

            this.panelTop = new System.Windows.Forms.Panel();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.cboGrade = new System.Windows.Forms.ComboBox();
            this.lblGrade = new System.Windows.Forms.Label();
            this.cboSemester = new System.Windows.Forms.ComboBox();
            this.lblSemester = new System.Windows.Forms.Label();
            this.panelSummary = new System.Windows.Forms.Panel();
            this.tableCards = new System.Windows.Forms.TableLayoutPanel();
            this.cardDebt = new System.Windows.Forms.Panel();
            this.lblDebt = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cardPaid = new System.Windows.Forms.Panel();
            this.lblPaid = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cardTotal = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.gbChart = new System.Windows.Forms.GroupBox();
            this.chartTuition = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.gbList = new System.Windows.Forms.GroupBox();
            this.dgvUnpaid = new System.Windows.Forms.DataGridView();

            this.panelTop.SuspendLayout();
            this.panelSummary.SuspendLayout();
            this.tableCards.SuspendLayout();
            this.cardDebt.SuspendLayout();
            this.cardPaid.SuspendLayout();
            this.cardTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.gbChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTuition)).BeginInit();
            this.gbList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnpaid)).BeginInit();
            this.SuspendLayout();

            // 
            // panelTop (Filter)
            // 
            this.panelTop.BackColor = System.Drawing.Color.White;
            this.panelTop.Controls.Add(this.btnFilter);
            this.panelTop.Controls.Add(this.btnExport);
            this.panelTop.Controls.Add(this.cboGrade);
            this.panelTop.Controls.Add(this.lblGrade);
            this.panelTop.Controls.Add(this.cboSemester);
            this.panelTop.Controls.Add(this.lblSemester);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(10, 10);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1080, 70);
            this.panelTop.TabIndex = 0;

            // 
            // lblSemester
            // 
            this.lblSemester.AutoSize = true;
            this.lblSemester.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSemester.Location = new System.Drawing.Point(20, 23);
            this.lblSemester.Name = "lblSemester";
            this.lblSemester.Text = "Chọn Học Kỳ:";
            this.lblSemester.TabIndex = 0;

            // 
            // cboSemester
            // 
            this.cboSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSemester.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboSemester.FormattingEnabled = true;
            this.cboSemester.Location = new System.Drawing.Point(140, 20);
            this.cboSemester.Name = "cboSemester";
            this.cboSemester.Size = new System.Drawing.Size(220, 31);
            this.cboSemester.TabIndex = 1;

            // 
            // lblGrade (Lọc danh sách nợ)
            // 
            this.lblGrade.AutoSize = true;
            this.lblGrade.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblGrade.Location = new System.Drawing.Point(400, 23);
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Text = "Lọc DS Nợ theo Khối:";
            this.lblGrade.TabIndex = 2;

            // 
            // cboGrade
            // 
            this.cboGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrade.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboGrade.FormattingEnabled = true;
            this.cboGrade.Location = new System.Drawing.Point(570, 20);
            this.cboGrade.Name = "cboGrade";
            this.cboGrade.Size = new System.Drawing.Size(150, 31);
            this.cboGrade.TabIndex = 3;

            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.Location = new System.Drawing.Point(750, 16);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(120, 38);
            this.btnFilter.TabIndex = 4;
            this.btnFilter.Text = "Thống Kê";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);

            // btnExport (Nút Xuất Excel Mới)
            // 
            this.btnExport.BackColor = System.Drawing.Color.ForestGreen; // Màu xanh lá excel
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(880, 16); // Nằm bên phải nút Filter
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(120, 38);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "Xuất Excel";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click); // <--- SỰ KIỆN CLICK

            // 
            // panelSummary (Cards)
            // 
            this.panelSummary.Controls.Add(this.tableCards);
            this.panelSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSummary.Location = new System.Drawing.Point(10, 80);
            this.panelSummary.Name = "panelSummary";
            this.panelSummary.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.panelSummary.Size = new System.Drawing.Size(1080, 140);
            this.panelSummary.TabIndex = 1;

            // 
            // tableCards
            // 
            this.tableCards.ColumnCount = 3;
            this.tableCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableCards.Controls.Add(this.cardDebt, 2, 0);
            this.tableCards.Controls.Add(this.cardPaid, 1, 0);
            this.tableCards.Controls.Add(this.cardTotal, 0, 0);
            this.tableCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableCards.Location = new System.Drawing.Point(0, 10);
            this.tableCards.Name = "tableCards";
            this.tableCards.RowCount = 1;
            this.tableCards.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableCards.Size = new System.Drawing.Size(1080, 120);
            this.tableCards.TabIndex = 0;

            // 
            // cardTotal (Blue)
            // 
            this.cardTotal.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.cardTotal.Controls.Add(this.lblTotal);
            this.cardTotal.Controls.Add(this.label1);
            this.cardTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardTotal.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.cardTotal.Name = "cardTotal";
            this.cardTotal.Size = new System.Drawing.Size(350, 120);
            this.cardTotal.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Text = "TỔNG PHẢI THU";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.White;
            this.lblTotal.Location = new System.Drawing.Point(15, 50);
            this.lblTotal.Text = "0 VNĐ";

            // 
            // cardPaid (Green)
            // 
            this.cardPaid.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.cardPaid.Controls.Add(this.lblPaid);
            this.cardPaid.Controls.Add(this.label3);
            this.cardPaid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardPaid.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.cardPaid.Name = "cardPaid";
            this.cardPaid.Size = new System.Drawing.Size(350, 120);
            this.cardPaid.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(15, 15);
            this.label3.Text = "ĐÃ THU ĐƯỢC";
            // 
            // lblPaid
            // 
            this.lblPaid.AutoSize = true;
            this.lblPaid.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblPaid.ForeColor = System.Drawing.Color.White;
            this.lblPaid.Location = new System.Drawing.Point(15, 50);
            this.lblPaid.Text = "0 VNĐ";

            // 
            // cardDebt (Red)
            // 
            this.cardDebt.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.cardDebt.Controls.Add(this.lblDebt);
            this.cardDebt.Controls.Add(this.label5);
            this.cardDebt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardDebt.Name = "cardDebt";
            this.cardDebt.Size = new System.Drawing.Size(360, 120);
            this.cardDebt.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(15, 15);
            this.label5.Text = "CÒN NỢ";
            // 
            // lblDebt
            // 
            this.lblDebt.AutoSize = true;
            this.lblDebt.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblDebt.ForeColor = System.Drawing.Color.White;
            this.lblDebt.Location = new System.Drawing.Point(15, 50);
            this.lblDebt.Text = "0 VNĐ";

            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(10, 220);
            this.splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1 (Chart)
            // 
            this.splitMain.Panel1.Controls.Add(this.gbChart);
            this.splitMain.Panel1.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            // 
            // splitMain.Panel2 (List)
            // 
            this.splitMain.Panel2.Controls.Add(this.gbList);
            this.splitMain.Size = new System.Drawing.Size(1080, 470);
            this.splitMain.SplitterDistance = 400;
            this.splitMain.TabIndex = 2;

            // 
            // gbChart
            // 
            this.gbChart.Controls.Add(this.chartTuition);
            this.gbChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbChart.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.gbChart.Location = new System.Drawing.Point(0, 0);
            this.gbChart.Name = "gbChart";
            this.gbChart.Size = new System.Drawing.Size(390, 470);
            this.gbChart.TabIndex = 0;
            this.gbChart.TabStop = false;
            this.gbChart.Text = "Tỉ Lệ Đã Đóng / Chưa Đóng";

            // 
            // chartTuition
            // 
            chartArea1.Name = "ChartArea1";
            this.chartTuition.ChartAreas.Add(chartArea1);
            this.chartTuition.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            this.chartTuition.Legends.Add(legend1);
            this.chartTuition.Location = new System.Drawing.Point(3, 28);
            this.chartTuition.Name = "chartTuition";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series1.IsValueShownAsLabel = true;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartTuition.Series.Add(series1);
            this.chartTuition.Size = new System.Drawing.Size(384, 439);
            this.chartTuition.TabIndex = 0;

            // 
            // gbList
            // 
            this.gbList.Controls.Add(this.dgvUnpaid);
            this.gbList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbList.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.gbList.Location = new System.Drawing.Point(0, 0);
            this.gbList.Name = "gbList";
            this.gbList.Size = new System.Drawing.Size(676, 470);
            this.gbList.TabIndex = 0;
            this.gbList.TabStop = false;
            this.gbList.Text = "Danh Sách Học Sinh Nợ Học Phí";

            // 
            // dgvUnpaid
            // 
            this.dgvUnpaid.AllowUserToAddRows = false;
            this.dgvUnpaid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUnpaid.BackgroundColor = System.Drawing.Color.White;
            this.dgvUnpaid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvUnpaid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUnpaid.Location = new System.Drawing.Point(3, 28);
            this.dgvUnpaid.Name = "dgvUnpaid";
            this.dgvUnpaid.ReadOnly = true;
            this.dgvUnpaid.RowHeadersVisible = false;
            this.dgvUnpaid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUnpaid.Size = new System.Drawing.Size(670, 439);
            this.dgvUnpaid.TabIndex = 0;

            // 
            // UC_Admin_ThongKe_HocPhi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.panelSummary);
            this.Controls.Add(this.panelTop);
            this.Name = "UC_Admin_ThongKe_HocPhi";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(1100, 700);
            this.Load += new System.EventHandler(this.UC_Admin_ThongKe_HocPhi_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelSummary.ResumeLayout(false);
            this.tableCards.ResumeLayout(false);
            this.cardDebt.ResumeLayout(false);
            this.cardDebt.PerformLayout();
            this.cardPaid.ResumeLayout(false);
            this.cardPaid.PerformLayout();
            this.cardTotal.ResumeLayout(false);
            this.cardTotal.PerformLayout();
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.gbChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartTuition)).EndInit();
            this.gbList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnpaid)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.ComboBox cboSemester;
        private System.Windows.Forms.Label lblSemester;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Panel panelSummary;
        private System.Windows.Forms.TableLayoutPanel tableCards;
        private System.Windows.Forms.Panel cardTotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel cardPaid;
        private System.Windows.Forms.Label lblPaid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel cardDebt;
        private System.Windows.Forms.Label lblDebt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.GroupBox gbChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTuition;
        private System.Windows.Forms.GroupBox gbList;
        private System.Windows.Forms.DataGridView dgvUnpaid;
        private System.Windows.Forms.ComboBox cboGrade;
        private System.Windows.Forms.Label lblGrade;
        private System.Windows.Forms.Button btnExport; //   
    }
}