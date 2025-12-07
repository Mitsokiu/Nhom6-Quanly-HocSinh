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
            MessageBox.Show("Số dòng: " + stats.Count);
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




        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
