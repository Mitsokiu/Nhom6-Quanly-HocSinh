using BUS; // Namespace của bạn
using DTO; // Namespace của bạn
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GUI.UserControls
{
    public partial class UC_Admin_ThongKe : UserControl
    {
        // StatisticBUS statisticBUS = new StatisticBUS();

        public UC_Admin_ThongKe()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!this.DesignMode)
            {
                LoadDataCoCau();
            }
        }

        // Hàm chỉ load dữ liệu cho Tab 1: Cơ Cấu
        public void LoadDataCoCau()
        {
            try
            {
                // 1. Load Số liệu tổng quan (3 Card màu)
                // lblNumStudents.Text = statisticBUS.GetTotalStudents().ToString();
                // lblNumTeachers.Text = statisticBUS.GetTotalTeachers().ToString();
                // lblNumClasses.Text = statisticBUS.GetTotalClasses().ToString();

                // Mock data
                lblNumStudents.Text = "270";
                lblNumTeachers.Text = "65";
                lblNumClasses.Text = "12";

                // 2. Load Biểu đồ Học sinh (Tròn - Giới tính)
                SetupPieChart(chartStudent, "Cơ cấu Giới tính HS");
                chartStudent.Series[0].Points.Clear();
                chartStudent.Series[0].Points.AddXY("Nam", 150);
                chartStudent.Series[0].Points.AddXY("Nữ", 120);

                // 3. Load Biểu đồ Giáo viên (Cột - Chức vụ)
                SetupColumnChart(chartTeacher, "Cơ cấu Giáo viên");
                chartTeacher.Series[0].Points.Clear();
                chartTeacher.Series[0].Points.AddXY("GVCN", 20);
                chartTeacher.Series[0].Points.AddXY("GVBM", 45);
                chartTeacher.Series[0].Palette = ChartColorPalette.SeaGreen;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thống kê cơ cấu: " + ex.Message);
            }
        }

        // Helper setup chart cho đẹp
        private void SetupPieChart(Chart chart, string title)
        {
            chart.Titles.Clear();
            Title t = new Title(title);
            t.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            chart.Titles.Add(t);
            chart.Series[0].ChartType = SeriesChartType.Pie;
            chart.Series[0].IsValueShownAsLabel = true;
        }

        private void SetupColumnChart(Chart chart, string title)
        {
            chart.Titles.Clear();
            Title t = new Title(title);
            t.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            chart.Titles.Add(t);
            chart.Series[0].ChartType = SeriesChartType.Column;
            chart.Series[0].IsValueShownAsLabel = true;
            chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
        }

        // Sau này khi bạn viết xong file UC_ThongKe_Diem, bạn sẽ dùng code này để add vào Tab 2
        /*
        private void LoadTabDiemSo()
        {
            UC_ThongKe_Diem ucDiem = new UC_ThongKe_Diem();
            ucDiem.Dock = DockStyle.Fill;
            tabDiemSo.Controls.Add(ucDiem);
        }
        */
    }
}