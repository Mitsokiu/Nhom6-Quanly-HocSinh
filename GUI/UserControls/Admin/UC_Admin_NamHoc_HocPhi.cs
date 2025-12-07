using System;
using System.Windows.Forms;
using DTO;
using BUS;

namespace GUI.UserControls
{
    public partial class UC_Admin_NamHoc_HocPhi : UserControl
    {
       

        public UC_Admin_NamHoc_HocPhi()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
          
        }

        private void button1_Click(object sender, EventArgs e) // Quản lý học phí
        {
            // Hiển thị panel1 hoặc thao tác quản lý
            panel1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e) // Thiết lập khoảng thu
        {
            MessageBox.Show("Chức năng thiết lập khoảng thu");
        }

        private void button3_Click(object sender, EventArgs e) // Cập nhật
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Optional: custom painting
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
