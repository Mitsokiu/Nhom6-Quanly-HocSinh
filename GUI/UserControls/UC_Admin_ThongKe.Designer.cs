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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 =
                new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 =
                new System.Windows.Forms.DataVisualization.Charting.Series();

            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 =
                new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 =
                new System.Windows.Forms.DataVisualization.Charting.Series();

            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 =
                new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 =
                new System.Windows.Forms.DataVisualization.Charting.Series();


            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbnumgv = new System.Windows.Forms.Label();
            this.lbSumGv = new System.Windows.Forms.Label();

            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lbSumhs = new System.Windows.Forms.Label();
            this.lbnumhs = new System.Windows.Forms.Label();

            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();

            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label4 = new System.Windows.Forms.Label();


            // MAIN TITLE
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(20, 15);
            this.label2.Text = "Thống Kê Tổng Quan";

            // PANEL TOP (Tổng người dùng)
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Location = new System.Drawing.Point(20, 60);
            this.panel1.Size = new System.Drawing.Size(1400, 80);

            this.lbSumGv.AutoSize = true;
            this.lbSumGv.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbSumGv.Location = new System.Drawing.Point(20, 25);
            this.lbSumGv.Text = "Tổng Người Dùng:";

            this.lbnumgv.AutoSize = true;
            this.lbnumgv.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbnumgv.Location = new System.Drawing.Point(200, 25);
            this.lbnumgv.Text = "0";

            this.panel1.Controls.Add(this.lbSumGv);
            this.panel1.Controls.Add(this.lbnumgv);

            // CHART 1 – Học sinh
            this.flowLayoutPanel1.Location = new System.Drawing.Point(20, 160);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(650, 380);

            chartArea1.BackColor = System.Drawing.Color.White;
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Legends.Clear();
            this.chart1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chart1.Size = new System.Drawing.Size(640, 300);

            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            this.chart1.Series.Add(series1);

            this.lbSumhs.AutoSize = true;
            this.lbSumhs.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lbSumhs.Text = "Tổng Học Sinh";

            this.lbnumhs.AutoSize = true;
            this.lbnumhs.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lbnumhs.Text = "0";

            this.flowLayoutPanel1.Controls.Add(this.chart1);
            this.flowLayoutPanel1.Controls.Add(this.lbSumhs);
            this.flowLayoutPanel1.Controls.Add(this.lbnumhs);

            // CHART 2 – Giáo viên
            this.flowLayoutPanel2.Location = new System.Drawing.Point(700, 160);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(650, 380);

            chartArea2.BackColor = System.Drawing.Color.White;
            this.chart2.ChartAreas.Add(chartArea2);
            this.chart2.Legends.Clear();
            this.chart2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chart2.Size = new System.Drawing.Size(640, 300);

            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            this.chart2.Series.Add(series2);

            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label1.Text = "Tổng Giáo Viên";

            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label3.Text = "0";

            this.flowLayoutPanel2.Controls.Add(this.chart2);
            this.flowLayoutPanel2.Controls.Add(this.label1);
            this.flowLayoutPanel2.Controls.Add(this.label3);

            // CHART 3 – Lớp học
            this.flowLayoutPanel3.Location = new System.Drawing.Point(20, 560);
            this.flowLayoutPanel3.Size = new System.Drawing.Size(1330, 380);

            chartArea3.BackColor = System.Drawing.Color.White;
            this.chart3.ChartAreas.Add(chartArea3);
            this.chart3.Legends.Clear();
            this.chart3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chart3.Size = new System.Drawing.Size(1320, 300);

            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.BorderWidth = 3;
            this.chart3.Series.Add(series3);

            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label4.Text = "Thống Kê Lớp Học";

            this.flowLayoutPanel3.Controls.Add(this.chart3);
            this.flowLayoutPanel3.Controls.Add(this.label4);

            // ADD TO CONTROL
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel3);

            this.Size = new System.Drawing.Size(1500, 1000);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart3;
        private System.Windows.Forms.Label label4;
    }
}
