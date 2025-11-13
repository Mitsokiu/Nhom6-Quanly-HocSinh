using System;
using System.Windows.Forms;
using DTO;
using BUS;

namespace GUI.UserControls
{
    public partial class UC_Admin_NamHoc_TKB : UserControl
    {
        private TKBBUS bus = new TKBBUS();

        public UC_Admin_NamHoc_TKB()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            dataGridView1.Rows.Clear();
            foreach (var tkb in bus.GetAll())
            {
                dataGridView1.Rows.Add(
                    tkb.Tiet,
                    tkb.Thu == "2" ? tkb.MonHoc : "",
                    tkb.Thu == "3" ? tkb.MonHoc : "",
                    tkb.Thu == "4" ? tkb.MonHoc : "",
                    tkb.Thu == "5" ? tkb.MonHoc : "",
                    tkb.Thu == "6" ? tkb.MonHoc : "",
                    tkb.Thu == "7" ? tkb.MonHoc : ""
                );
            }
        }

        private void button4_Click(object sender, EventArgs e) // Thêm
        {
            var tkb = new TKBDTO
            {
                NamHoc = comboBox1.Text,
                HocKi = comboBox3.Text,
                Lop = comboBox2.Text,
                Thu = comboBox4.Text,
                Tiet = comboBox5.Text,
                GiaoVien = comboBox6.Text,
                MonHoc = comboBox7.Text,
                Phong = textBox1.Text
            };
            bus.Add(tkb);
            LoadData();
        }

        private void button5_Click(object sender, EventArgs e) // Sửa
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int idx = dataGridView1.SelectedRows[0].Index;
                var tkb = bus.GetAll()[idx];
                tkb.NamHoc = comboBox1.Text;
                tkb.HocKi = comboBox3.Text;
                tkb.Lop = comboBox2.Text;
                tkb.Thu = comboBox4.Text;
                tkb.Tiet = comboBox5.Text;
                tkb.GiaoVien = comboBox6.Text;
                tkb.MonHoc = comboBox7.Text;
                tkb.Phong = textBox1.Text;
                bus.Update(tkb);
                LoadData();
            }
        }

        private void button6_Click(object sender, EventArgs e) // Xóa
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int idx = dataGridView1.SelectedRows[0].Index;
                var tkb = bus.GetAll()[idx];
                bus.Delete(tkb.Id);
                LoadData();
            }
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
