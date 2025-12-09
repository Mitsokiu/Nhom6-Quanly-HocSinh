using BUS;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GUI.UserControls
{
    public partial class UC_Admin_ThongKe : UserControl
    {
        private StatisticBUS statBUS = new StatisticBUS();

        public UC_Admin_ThongKe()
        {
            InitializeComponent();

            // 1. Cập nhật Items cho ComboBox
            cboCriteria.Items.Clear();
            cboCriteria.Items.AddRange(new object[] {
                "Thống kê HS theo khối",
                "Thống kê HS theo lớp",
                "Thống kê HS theo giới tính"
            });

            cboCriteria.SelectedIndexChanged += CboCriteria_SelectedIndexChanged;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!this.DesignMode)
            {
                LoadDashboardTotals();
                cboCriteria.SelectedIndex = 0; // Mặc định chọn cái đầu

                // 2. Nhúng các UserControl con vào Tab
                LoadSubTabs();
            }
        }

        private void LoadSubTabs()
        {
            // Tab Điểm Số
            UC_Admin_ThongKe_DiemSo ucDiem = new UC_Admin_ThongKe_DiemSo();
            ucDiem.Dock = DockStyle.Fill;
            tabDiemSo.Controls.Add(ucDiem);

            // Tab Học Phí
            UC_Admin_ThongKe_HocPhi ucHocPhi = new UC_Admin_ThongKe_HocPhi();
            ucHocPhi.Dock = DockStyle.Fill;
            tabHocPhi.Controls.Add(ucHocPhi);
        }

        private void LoadDashboardTotals()
        {
            try
            {
                lblNumStudents.Text = statBUS.GetTotalStudents().ToString();
                lblNumTeachers.Text = statBUS.GetTotalTeachers().ToString();
                lblNumClasses.Text = statBUS.GetTotalClasses().ToString();
            }
            catch (Exception ex)
            {
                // Silent fail or log
            }
        }

        private void CboCriteria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCriteria.SelectedItem == null) return;
            string criteria = cboCriteria.SelectedItem.ToString();
            LoadStatistics(criteria);
        }

        private void LoadStatistics(string criteria)
        {
            try
            {
                DataTable dt = statBUS.GetStudentStats(criteria);
                dgvStats.DataSource = dt;
                DrawChart(dt, criteria);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thống kê chi tiết: " + ex.Message);
            }
        }

        private void DrawChart(DataTable dt, string title)
        {
            chartStats.Series.Clear();
            chartStats.Titles.Clear();
            chartStats.Titles.Add(new Title(title) { Font = new Font("Segoe UI", 12, FontStyle.Bold) });

            // Tạo Series
            Series series = new Series();
            // 3. Sửa lỗi chú thích: Đặt tên Series chính là tiêu đề để Legend hiện đúng
            series.Name = title;
            series.IsValueShownAsLabel = true;

            if (title == "Thống kê HS theo giới tính")
            {
                series.ChartType = SeriesChartType.Pie;
            }
            else
            {
                series.ChartType = SeriesChartType.Column;
                series.Palette = ChartColorPalette.SeaGreen;
                // Ẩn lưới thừa
                chartStats.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                chartStats.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            }

            foreach (DataRow row in dt.Rows)
            {
                string category = row["Danh Mục"].ToString();
                int value = Convert.ToInt32(row["Số Lượng"]);
                series.Points.AddXY(category, value);
            }

            chartStats.Series.Add(series);
        }
    }
}