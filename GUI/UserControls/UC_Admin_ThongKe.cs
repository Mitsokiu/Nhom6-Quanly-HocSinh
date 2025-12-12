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

            // Chọn mặc định để tránh lỗi null
            cboCriteria.SelectedIndex = 0;
            cboCriteria.SelectedIndexChanged += CboCriteria_SelectedIndexChanged;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!this.DesignMode)
            {
                LoadDashboardTotals();
                // Load lần đầu nếu chưa kích hoạt sự kiện change
                if (cboCriteria.SelectedItem != null)
                    LoadStatistics(cboCriteria.SelectedItem.ToString());

                LoadSubTabs();
            }
        }

        private void LoadSubTabs()
        {
            // Tab Điểm Số
            // Kiểm tra để tránh add trùng nếu Load được gọi nhiều lần
            if (tabDiemSo.Controls.Count == 0)
            {
                UC_Admin_ThongKe_DiemSo ucDiem = new UC_Admin_ThongKe_DiemSo();
                ucDiem.Dock = DockStyle.Fill;
                tabDiemSo.Controls.Add(ucDiem);
            }

            // Tab Học Phí
            if (tabHocPhi.Controls.Count == 0)
            {
                UC_Admin_ThongKe_HocPhi ucHocPhi = new UC_Admin_ThongKe_HocPhi();
                ucHocPhi.Dock = DockStyle.Fill;
                tabHocPhi.Controls.Add(ucHocPhi);
            }
        }

        private void LoadDashboardTotals()
        {
            try
            {
                lblNumStudents.Text = statBUS.GetTotalStudents().ToString();
                lblNumTeachers.Text = statBUS.GetTotalTeachers().ToString();
                lblNumClasses.Text = statBUS.GetTotalClasses().ToString();
            }
            catch (Exception)
            {
                // Silent fail
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

        // --- HÀM VẼ BIỂU ĐỒ ĐÃ ĐƯỢC SỬA LẠI ---
        private void DrawChart(DataTable dt, string title)
        {
            // 1. Reset biểu đồ
            chartStats.Series.Clear();
            chartStats.Titles.Clear();
            chartStats.Titles.Add(new Title(title) { Font = new Font("Segoe UI", 12, FontStyle.Bold) });

            // 2. Xử lý theo từng loại biểu đồ
            if (title == "Thống kê HS theo giới tính")
            {
                // --- BIỂU ĐỒ TRÒN (PIE) ---
                // Pie Chart chỉ cần 1 Series, Legend tự động lấy theo Point Label
                Series series = new Series("GioiTinh");
                series.ChartType = SeriesChartType.Pie;
                series.IsValueShownAsLabel = true;

                foreach (DataRow row in dt.Rows)
                {
                    series.Points.AddXY(row["Danh Mục"], row["Số Lượng"]);
                }
                chartStats.Series.Add(series);
            }
            else
            {
                // --- BIỂU ĐỒ CỘT (COLUMN) - KHỐI/LỚP ---
                // Tạo Series riêng cho mỗi dòng dữ liệu để Legend hiển thị đúng tên (Khối 6, Khối 7...)

                foreach (DataRow row in dt.Rows)
                {
                    string categoryName = row["Danh Mục"].ToString(); // VD: Khối 6
                    int value = Convert.ToInt32(row["Số Lượng"]);

                    // Tạo 1 Series mới cho mỗi cột
                    Series s = new Series(categoryName);
                    s.ChartType = SeriesChartType.Column;
                    s.IsValueShownAsLabel = true;

                    // Thêm điểm dữ liệu duy nhất vào Series này
                    s.Points.AddXY(categoryName, value);

                    chartStats.Series.Add(s);
                }

                // Tinh chỉnh giao diện trục sau khi thêm dữ liệu
                if (chartStats.ChartAreas.Count > 0)
                {
                    chartStats.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                    chartStats.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
                    chartStats.ChartAreas[0].AxisX.Interval = 1; // Đảm bảo hiện đủ nhãn trục X
                }
            }
        }
    }
}