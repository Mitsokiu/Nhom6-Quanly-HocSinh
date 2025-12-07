namespace GUI.UserControls
{
    partial class UC_Admin_ThongKe
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbSumGv = new System.Windows.Forms.Label();
            this.lbnumgv = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lbSumhs = new System.Windows.Forms.Label();
            this.lbnumhs = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.lbgv = new System.Windows.Forms.Label();
            this.lbsum = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(20, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(339, 45);
            this.label2.TabIndex = 0;
            this.label2.Text = "Thống Kê Tổng Quan";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.lbsum);
            this.panel1.Controls.Add(this.lbSumGv);
            this.panel1.Controls.Add(this.lbnumgv);
            this.panel1.Location = new System.Drawing.Point(20, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1400, 80);
            this.panel1.TabIndex = 1;
            // 
            // lbSumGv
            // 
            this.lbSumGv.AutoSize = true;
            this.lbSumGv.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbSumGv.Location = new System.Drawing.Point(20, 25);
            this.lbSumGv.Name = "lbSumGv";
            this.lbSumGv.Size = new System.Drawing.Size(229, 32);
            this.lbSumGv.TabIndex = 0;
            this.lbSumGv.Text = "Tổng Người Dùng:";
            // 
            // lbnumgv
            // 
            this.lbnumgv.AutoSize = true;
            this.lbnumgv.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbnumgv.Location = new System.Drawing.Point(200, 25);
            this.lbnumgv.Name = "lbnumgv";
            this.lbnumgv.Size = new System.Drawing.Size(28, 32);
            this.lbnumgv.TabIndex = 1;
            this.lbnumgv.Text = "0";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.chart1);
            this.flowLayoutPanel1.Controls.Add(this.lbSumhs);
            this.flowLayoutPanel1.Controls.Add(this.lbnumhs);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(20, 160);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(636, 304);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.BackColor = System.Drawing.Color.White;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(3, 3);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Name = "Series1";
            series1.YValuesPerPoint = 4;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(633, 238);
            this.chart1.TabIndex = 0;
            // 
            // lbSumhs
            // 
            this.lbSumhs.AutoSize = true;
            this.lbSumhs.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lbSumhs.Location = new System.Drawing.Point(3, 244);
            this.lbSumhs.Name = "lbSumhs";
            this.lbSumhs.Size = new System.Drawing.Size(163, 30);
            this.lbSumhs.TabIndex = 1;
            this.lbSumhs.Text = "Tổng Học Sinh";
            // 
            // lbnumhs
            // 
            this.lbnumhs.AutoSize = true;
            this.lbnumhs.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lbnumhs.Location = new System.Drawing.Point(172, 244);
            this.lbnumhs.Name = "lbnumhs";
            this.lbnumhs.Size = new System.Drawing.Size(26, 30);
            this.lbnumhs.TabIndex = 2;
            this.lbnumhs.Text = "0";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.chart2);
            this.flowLayoutPanel2.Controls.Add(this.label1);
            this.flowLayoutPanel2.Controls.Add(this.lbgv);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(700, 160);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(538, 304);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // chart2
            // 
            this.chart2.BackColor = System.Drawing.Color.WhiteSmoke;
            chartArea2.BackColor = System.Drawing.Color.White;
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            this.chart2.Location = new System.Drawing.Point(3, 3);
            this.chart2.Name = "chart2";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Name = "Series1";
            this.chart2.Series.Add(series2);
            this.chart2.Size = new System.Drawing.Size(535, 229);
            this.chart2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 235);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tổng Giáo Viên";
            // 
            // lbgv
            // 
            this.lbgv.AutoSize = true;
            this.lbgv.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lbgv.Location = new System.Drawing.Point(180, 235);
            this.lbgv.Name = "lbgv";
            this.lbgv.Size = new System.Drawing.Size(26, 30);
            this.lbgv.TabIndex = 2;
            this.lbgv.Text = "0";
            // 
            // lbsum
            // 
            this.lbsum.AutoSize = true;
            this.lbsum.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lbsum.Location = new System.Drawing.Point(264, 27);
            this.lbsum.Name = "lbsum";
            this.lbsum.Size = new System.Drawing.Size(26, 30);
            this.lbsum.TabIndex = 3;
            this.lbsum.Text = "0";
            // 
            // UC_Admin_ThongKe
            // 
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Name = "UC_Admin_ThongKe";
            this.Size = new System.Drawing.Size(1500, 550);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbnumgv;
        private System.Windows.Forms.Label lbSumGv;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label lbnumhs;
        private System.Windows.Forms.Label lbSumhs;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbgv;
        private System.Windows.Forms.Label lbsum;
    }
}
