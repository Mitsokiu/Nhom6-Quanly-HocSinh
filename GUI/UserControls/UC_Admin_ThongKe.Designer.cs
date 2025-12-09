namespace GUI.UserControls
{
    partial class UC_Admin_ThongKe
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();

            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabCoCau = new System.Windows.Forms.TabPage();
            this.panelCharts = new System.Windows.Forms.TableLayoutPanel();
            this.chartStudent = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartTeacher = new System.Windows.Forms.DataVisualization.Charting.Chart();
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
            this.panelCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartStudent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTeacher)).BeginInit();
            this.panelSummary.SuspendLayout();
            this.cardLop.SuspendLayout();
            this.cardGV.SuspendLayout();
            this.cardHS.SuspendLayout();
            this.SuspendLayout();

            // 
            // tabControlMain (Container chính)
            // 
            this.tabControlMain.Controls.Add(this.tabCoCau);
            this.tabControlMain.Controls.Add(this.tabDiemSo);
            this.tabControlMain.Controls.Add(this.tabHocPhi);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlMain.ItemSize = new System.Drawing.Size(180, 40);
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1100, 680);
            this.tabControlMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlMain.TabIndex = 0;

            // 
            // tabCoCau (Tab 1: Thống kê Cơ cấu & Tổng quan)
            // 
            this.tabCoCau.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabCoCau.Controls.Add(this.panelCharts);
            this.tabCoCau.Controls.Add(this.panelSummary);
            this.tabCoCau.Location = new System.Drawing.Point(4, 44);
            this.tabCoCau.Name = "tabCoCau";
            this.tabCoCau.Padding = new System.Windows.Forms.Padding(20);
            this.tabCoCau.Size = new System.Drawing.Size(1092, 632);
            this.tabCoCau.TabIndex = 0;
            this.tabCoCau.Text = "Thống Kê Cơ Cấu";

            // 
            // panelSummary (Chứa 3 Card Tổng số)
            // 
            this.panelSummary.Controls.Add(this.cardLop);
            this.panelSummary.Controls.Add(this.cardGV);
            this.panelSummary.Controls.Add(this.cardHS);
            this.panelSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSummary.Location = new System.Drawing.Point(20, 20);
            this.panelSummary.Name = "panelSummary";
            this.panelSummary.Size = new System.Drawing.Size(1052, 160);
            this.panelSummary.TabIndex = 0;

            // 
            // cardHS (Màu Xanh Dương)
            // 
            this.cardHS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.cardHS.Controls.Add(this.lblNumStudents);
            this.cardHS.Controls.Add(this.label1);
            this.cardHS.Location = new System.Drawing.Point(0, 5);
            this.cardHS.Name = "cardHS";
            this.cardHS.Size = new System.Drawing.Size(320, 140);
            this.cardHS.TabIndex = 0;

            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "TỔNG SỐ HS";

            // 
            // lblNumStudents
            // 
            this.lblNumStudents.AutoSize = true;
            this.lblNumStudents.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblNumStudents.ForeColor = System.Drawing.Color.White;
            this.lblNumStudents.Location = new System.Drawing.Point(20, 60);
            this.lblNumStudents.Name = "lblNumStudents";
            this.lblNumStudents.Size = new System.Drawing.Size(46, 54);
            this.lblNumStudents.TabIndex = 1;
            this.lblNumStudents.Text = "0";

            // 
            // cardGV (Màu Xanh Lá)
            // 
            this.cardGV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.cardGV.Controls.Add(this.lblNumTeachers);
            this.cardGV.Controls.Add(this.label4);
            this.cardGV.Location = new System.Drawing.Point(340, 5);
            this.cardGV.Name = "cardGV";
            this.cardGV.Size = new System.Drawing.Size(320, 140);
            this.cardGV.TabIndex = 1;

            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(20, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 28);
            this.label4.TabIndex = 0;
            this.label4.Text = "TỔNG SỐ GV";

            // 
            // lblNumTeachers
            // 
            this.lblNumTeachers.AutoSize = true;
            this.lblNumTeachers.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblNumTeachers.ForeColor = System.Drawing.Color.White;
            this.lblNumTeachers.Location = new System.Drawing.Point(20, 60);
            this.lblNumTeachers.Name = "lblNumTeachers";
            this.lblNumTeachers.Size = new System.Drawing.Size(46, 54);
            this.lblNumTeachers.TabIndex = 1;
            this.lblNumTeachers.Text = "0";

            // 
            // cardLop (Màu Cam)
            // 
            this.cardLop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.cardLop.Controls.Add(this.lblNumClasses);
            this.cardLop.Controls.Add(this.label6);
            this.cardLop.Location = new System.Drawing.Point(680, 5);
            this.cardLop.Name = "cardLop";
            this.cardLop.Size = new System.Drawing.Size(320, 140);
            this.cardLop.TabIndex = 2;

            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(20, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 28);
            this.label6.TabIndex = 0;
            this.label6.Text = "TỔNG SỐ LỚP";

            // 
            // lblNumClasses
            // 
            this.lblNumClasses.AutoSize = true;
            this.lblNumClasses.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblNumClasses.ForeColor = System.Drawing.Color.White;
            this.lblNumClasses.Location = new System.Drawing.Point(20, 60);
            this.lblNumClasses.Name = "lblNumClasses";
            this.lblNumClasses.Size = new System.Drawing.Size(46, 54);
            this.lblNumClasses.TabIndex = 1;
            this.lblNumClasses.Text = "0";

            // 
            // panelCharts (Chứa 2 biểu đồ bên dưới)
            // 
            this.panelCharts.ColumnCount = 2;
            this.panelCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelCharts.Controls.Add(this.chartStudent, 0, 0);
            this.panelCharts.Controls.Add(this.chartTeacher, 1, 0);
            this.panelCharts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCharts.Location = new System.Drawing.Point(20, 180);
            this.panelCharts.Name = "panelCharts";
            this.panelCharts.RowCount = 1;
            this.panelCharts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelCharts.Size = new System.Drawing.Size(1052, 432);
            this.panelCharts.TabIndex = 1;

            // 
            // chartStudent
            // 
            chartArea1.Name = "ChartArea1";
            this.chartStudent.ChartAreas.Add(chartArea1);
            this.chartStudent.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartStudent.Legends.Add(legend1);
            this.chartStudent.Location = new System.Drawing.Point(3, 3);
            this.chartStudent.Name = "chartStudent";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartStudent.Series.Add(series1);
            this.chartStudent.Size = new System.Drawing.Size(520, 426);
            this.chartStudent.TabIndex = 0;
            this.chartStudent.Text = "chart1";

            // 
            // chartTeacher
            // 
            chartArea2.Name = "ChartArea1";
            this.chartTeacher.ChartAreas.Add(chartArea2);
            this.chartTeacher.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chartTeacher.Legends.Add(legend2);
            this.chartTeacher.Location = new System.Drawing.Point(529, 3);
            this.chartTeacher.Name = "chartTeacher";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartTeacher.Series.Add(series2);
            this.chartTeacher.Size = new System.Drawing.Size(520, 426);
            this.chartTeacher.TabIndex = 1;
            this.chartTeacher.Text = "chart2";

            // 
            // tabDiemSo (Tab 2: Để trống cho file sau này)
            // 
            this.tabDiemSo.Location = new System.Drawing.Point(4, 44);
            this.tabDiemSo.Name = "tabDiemSo";
            this.tabDiemSo.Size = new System.Drawing.Size(1092, 632);
            this.tabDiemSo.TabIndex = 1;
            this.tabDiemSo.Text = "Thống Kê Điểm Số";
            this.tabDiemSo.UseVisualStyleBackColor = true;

            // 
            // tabHocPhi (Tab 3: Để trống cho file sau này)
            // 
            this.tabHocPhi.Location = new System.Drawing.Point(4, 44);
            this.tabHocPhi.Name = "tabHocPhi";
            this.tabHocPhi.Size = new System.Drawing.Size(1092, 632);
            this.tabHocPhi.TabIndex = 2;
            this.tabHocPhi.Text = "Thống Kê Học Phí";
            this.tabHocPhi.UseVisualStyleBackColor = true;

            // 
            // UC_Admin_ThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlMain);
            this.Name = "UC_Admin_ThongKe";
            this.Size = new System.Drawing.Size(1100, 680);
            this.tabControlMain.ResumeLayout(false);
            this.tabCoCau.ResumeLayout(false);
            this.panelCharts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartStudent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTeacher)).EndInit();
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
        private System.Windows.Forms.TableLayoutPanel panelCharts;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartStudent;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTeacher;
    }
}