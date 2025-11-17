using System;
using System.Windows.Forms;
using DTO;
using BUS;

namespace GUI.UserControls
{
    public partial class UC_Admin_NamHoc_TKB : UserControl
    {
       
        public UC_Admin_NamHoc_TKB()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            
        }

        private void button4_Click(object sender, EventArgs e) // Thêm
        {
           
        }

        private void button5_Click(object sender, EventArgs e) // Sửa
        {
           
        }

        private void button6_Click(object sender, EventArgs e) // Xóa
        {
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            // code khi chọn học kì
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            // code khi chọn thứ
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // code khi click cell nếu cần
        }

        private void label5_Click(object sender, EventArgs e)
        {
            // code khi click label nếu cần
        }
    }
}
