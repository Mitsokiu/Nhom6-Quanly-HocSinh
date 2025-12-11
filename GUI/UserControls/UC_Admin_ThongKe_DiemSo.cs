using BUS;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GUI.UserControls
{
    public partial class UC_Admin_ThongKe_DiemSo : UserControl
    {
        private StatisticBUS statBUS = new StatisticBUS();

        public UC_Admin_ThongKe_DiemSo()
        {
            InitializeComponent();
        }

        private void UC_Admin_ThongKe_DiemSo_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                LoadFilterData();
                // Tự động chọn giá trị đầu tiên nếu có
                if (cboGrade.Items.Count > 0) cboGrade.SelectedIndex = 0;
                if (cboSemester.Items.Count > 0) cboSemester.SelectedIndex = 0;

                // Gọi filter lần đầu
                if (cboGrade.SelectedValue != null && cboSemester.SelectedValue != null)
                {
                    btnFilter_Click(null, null);
                }
            }
        }

        private void LoadFilterData()
        {
            try
            {
                // 1. Load Khối
                DataTable dtGrades = statBUS.GetGradeLevels();
                cboGrade.DataSource = dtGrades;
                cboGrade.DisplayMember = "grade_name";
                cboGrade.ValueMember = "grade_id";

                // 2. Load Học Kỳ [CẬP NHẬT]
                // DataTable trả về từ DAO giờ có cột 'semester_display' (VD: HK1 - 2024-2025) và 'semester_id'
                DataTable dtSemesters = statBUS.GetSemesters();
                cboSemester.DataSource = dtSemesters;
                cboSemester.DisplayMember = "semester_display"; // Hiển thị: HK1 - 2024-2025
                cboSemester.ValueMember = "semester_id";        // Giá trị: ID (int)
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu lọc: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            // Kiểm tra null an toàn hơn
            if (cboGrade.SelectedValue == null || cboSemester.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ Khối và Học kỳ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy ID (int) thay vì string name
            if (int.TryParse(cboGrade.SelectedValue.ToString(), out int gradeId) &&
                int.TryParse(cboSemester.SelectedValue.ToString(), out int semesterId))
            {
                LoadScoreDistribution(gradeId, semesterId);
                LoadTopTenStudents(gradeId, semesterId);
            }
            else
            {
                MessageBox.Show("Dữ liệu chọn không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadScoreDistribution(int gradeId, int semesterId)
        {
            try
            {
                DataTable dt = statBUS.GetOverallAverageScoreDistribution(gradeId, semesterId);

                // Xóa series cũ nếu cần thiết hoặc clear points
                Series distributionSeries = chartDistribution.Series["DTB_Distribution"];
                distributionSeries.Points.Clear();

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    // Thêm dữ liệu vào biểu đồ
                    distributionSeries.Points.AddXY("Dưới 5", row["Dưới 5"]);
                    distributionSeries.Points.AddXY("5 - 6.4", row["5 - 6.4"]);
                    distributionSeries.Points.AddXY("6.5 - 7.9", row["6.5 - 7.9"]);
                    distributionSeries.Points.AddXY("8 - 10", row["8 - 10"]);

                    // Đặt màu sắc cho trực quan
                    distributionSeries.Points[0].Color = Color.FromArgb(231, 76, 60);  // Đỏ (Yếu)
                    distributionSeries.Points[1].Color = Color.FromArgb(243, 156, 18); // Cam (TB)
                    distributionSeries.Points[2].Color = Color.FromArgb(52, 152, 219); // Xanh dương (Khá)
                    distributionSeries.Points[3].Color = Color.FromArgb(46, 204, 113); // Xanh lá (Giỏi)

                    distributionSeries.IsValueShownAsLabel = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải biểu đồ: " + ex.Message);
            }
        }

        private void LoadTopTenStudents(int gradeId, int semesterId)
        {
            try
            {
                DataTable dt = statBUS.GetTopTenStudentsByAvgScore(gradeId, semesterId);
                dgvTop10.DataSource = dt;

                // Format lại cột điểm cho đẹp (nếu cần)
                if (dgvTop10.Columns["DTB"] != null)
                {
                    dgvTop10.Columns["DTB"].DefaultCellStyle.Format = "N2"; // 2 chữ số thập phân
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách Top 10: " + ex.Message);
            }
        }
    }
}