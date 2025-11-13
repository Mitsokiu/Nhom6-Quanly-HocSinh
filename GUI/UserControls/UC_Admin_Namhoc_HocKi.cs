using System;
using System.Windows.Forms;
using DTO;
using BUS;

namespace GUI.UserControls
{
    public partial class UC_Admin_Namhoc_HocKi : UserControl
    {
        private HocKiBUS bus = new HocKiBUS();

        public UC_Admin_Namhoc_HocKi()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            dataGridView1.Rows.Clear();
            foreach (var hk in bus.GetAll())
            {
                dataGridView1.Rows.Add(hk.NamHoc, hk.HocKi, hk.NgayBatDau.ToShortDateString(), hk.NgayKetThuc.ToShortDateString(), hk.TrangThai);
            }
        }

        private void button4_Click(object sender, EventArgs e) // Thêm
        {
            var hk = new HocKiDTO
            {
                Id = bus.GetAll().Count + 1,
                NamHoc = textBox1.Text,
                HocKi = textBox2.Text,
                NgayBatDau = dateTimePicker1.Value,
                NgayKetThuc = dateTimePicker2.Value,
                TrangThai = textBox3.Text
            };
            bus.Add(hk);
            LoadData();
        }

        private void button5_Click(object sender, EventArgs e) // Sửa
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int idx = dataGridView1.SelectedRows[0].Index;
                var hk = bus.GetAll()[idx];
                hk.NamHoc = textBox1.Text;
                hk.HocKi = textBox2.Text;
                hk.NgayBatDau = dateTimePicker1.Value;
                hk.NgayKetThuc = dateTimePicker2.Value;
                hk.TrangThai = textBox3.Text;
                bus.Update(hk);
                LoadData();
            }
        }

        private void button6_Click(object sender, EventArgs e) // Xóa
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int idx = dataGridView1.SelectedRows[0].Index;
                var hk = bus.GetAll()[idx];
                bus.Delete(hk.Id);
                LoadData();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                dateTimePicker1.Value = DateTime.Parse(row.Cells[2].Value.ToString());
                dateTimePicker2.Value = DateTime.Parse(row.Cells[3].Value.ToString());
                textBox3.Text = row.Cells[4].Value.ToString();
            }
        }
    }
}
