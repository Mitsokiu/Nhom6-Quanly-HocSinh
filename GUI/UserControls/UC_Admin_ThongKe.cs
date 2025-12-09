using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GUI.UserControls
{
    public partial class UC_Admin_ThongKe : UserControl
    {
        UserBUS userBus = new UserBUS();
        private int totalUsers, totalStudents, totalTeachers,totalgvcn,totalgvbm;
        public UC_Admin_ThongKe()
        {
            InitializeComponent();
           
            totalStudents = userBus.GetTotalStudents();
            totalTeachers = userBus.GetTotalTeachers();
            totalUsers = userBus.GetTotalUsers();
            totalgvcn= userBus.GetTotalGVCN();
            totalgvbm= userBus.GetTotalGVBM();
            LoadDashboard();
            LoadCharts();
            LoadStudentLineChart();
            LoadStudentChart(1);


        }


        private void LoadDashboard()
        {
         lbsum.Text = totalUsers.ToString();
            lbnumhs.Text = totalStudents.ToString();
            lbgv.Text = totalTeachers.ToString();
        }


        private void LoadCharts()
        {
           
            chart2.Series[0].Points.Clear();

          

            // Chart giáo viên Pie
            chart2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            chart2.Series[0].Points.AddXY("Giáo Viên CN", totalgvcn);
            chart2.Series[0].Points.AddXY("Giaó Viên BM ", totalgvbm);
        }

        private void LoadStudentLineChart()
        {
            var stats = userBus.GetStudentStatsByDate();
           
            chart1.Series.Clear();
            chart1.ChartAreas[0].AxisX.Interval = 1;

            var series = new Series("Học Sinh")
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 3,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 7
            };

            foreach (var item in stats)
            {
                series.Points.AddXY(item.CreatedDate.ToString("dd/MM"), item.Count);
            }

            chart1.Series.Add(series);
        }


        private void LoadStudentChart(int currentYearId)
        {
            // 1. Lấy dữ liệu từ BUS
            DataTable dtStudentCount = StudentBUS.GetStudentCountByClass(currentYearId);

            // 2. Xóa dữ liệu cũ và thiết lập biểu đồ
            chart3.Series.Clear();
            chart3.Titles.Clear();

            // Thêm tiêu đề
            chart3.Titles.Add("Biểu Đồ So Sánh Số Lượng Học Sinh Theo Lớp");

            // 3. Tạo Series (chuỗi dữ liệu) cho biểu đồ cột
            Series series = new Series("Số lượng Học Sinh")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true // Hiển thị giá trị trên cột
            };

            // 4. Đổ dữ liệu từ DataTable vào Series
            if (dtStudentCount.Rows.Count > 0)
            {
                foreach (DataRow row in dtStudentCount.Rows)
                {
                    string className = row["ClassName"].ToString();
                    int studentCount = Convert.ToInt32(row["StudentCount"]);

                    // Thêm điểm dữ liệu (Tên lớp là trục X, Số lượng là trục Y)
                    series.Points.AddXY(className, studentCount);
                }
            }
            else
            {
                // Xử lý trường hợp không có dữ liệu
                series.Points.AddXY("Không có dữ liệu", 0);
            }

            // 5. Thêm Series vào Chart control
            chart3.Series.Add(series);
        }



        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
