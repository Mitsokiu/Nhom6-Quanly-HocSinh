using System;
using System.Windows.Forms;
using DTO;
using BUS;

namespace GUI.UserControls
{
    public partial class UC_Admin_NamHoc_HocPhi_PhieuThu : UserControl
    {
        private PhieuThuBUS bus = new PhieuThuBUS();

        public UC_Admin_NamHoc_HocPhi_PhieuThu()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            dataGridView1.Rows.Clear();
            foreach (var pt in bus.GetAll())
            {
                dataGridView1.Rows.Add(pt.MaKhoanThu, pt.TenKhoanThu, pt.SoTien, pt.NamHoc);
            }
        }

        private void button4_Click(object sender, EventArgs e) // Thêm
        {
            var pt = new PhieuThuDTO
            {
                MaKhoanThu = textBox1.Text,
                TenKhoanThu = textBox2.Text,
                SoTien = decimal.TryParse(textBox3.Text, out var st) ? st : 0,
                NamHoc = textBox4.Text
            };
            bus.Add(pt);
            LoadData();
        }

        private void button5_Click(object sender, EventArgs e) // Sửa
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int idx = dataGridView1.SelectedRows[0].Index;
                var pt = bus.GetAll()[idx];
                pt.MaKhoanThu = textBox1.Text;
                pt.TenKhoanThu = textBox2.Text;
                pt.SoTien = decimal.TryParse(textBox3.Text, out var st) ? st : 0;
                pt.NamHoc = textBox4.Text;
                bus.Update(pt);
                LoadData();
            }
        }

        private void button6_Click(object sender, EventArgs e) // Xóa
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int idx = dataGridView1.SelectedRows[0].Index;
                var pt = bus.GetAll()[idx];
                bus.Delete(pt.Id);
                LoadData();
            }
        }
    }
}
