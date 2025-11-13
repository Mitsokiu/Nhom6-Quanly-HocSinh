using System;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI.UserControls
{
    public partial class UC_Admin_Class_Phancong : UserControl
    {
        private PhanCongBUS bus = new PhanCongBUS();

        public UC_Admin_Class_Phancong()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            dataGridView1.Rows.Clear();
            foreach (var pc in bus.GetAll())
            {
                dataGridView1.Rows.Add(pc.Lop, pc.Mon, pc.GiaoVien);
            }
        }

        private void button4_Click(object sender, EventArgs e) // Thêm
        {
            PhanCongDTO pc = new PhanCongDTO
            {
                Lop = comboBox1.Text,
                Mon = comboBox2.Text,
                GiaoVien = comboBox3.Text
            };
            bus.Add(pc);
            LoadData();
        }

        private void button5_Click(object sender, EventArgs e) // Sửa
        {
            PhanCongDTO pc = new PhanCongDTO
            {
                Lop = comboBox1.Text,
                Mon = comboBox2.Text,
                GiaoVien = comboBox3.Text
            };
            if (bus.Update(pc))
                LoadData();
        }

        private void button6_Click(object sender, EventArgs e) // Xóa
        {
            string lop = comboBox1.Text;
            string mon = comboBox2.Text;
            if (bus.Delete(lop, mon))
                LoadData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dataGridView1.Rows[e.RowIndex];
            comboBox1.Text = row.Cells[0].Value?.ToString();
            comboBox2.Text = row.Cells[1].Value?.ToString();
            comboBox3.Text = row.Cells[2].Value?.ToString();
        }
    }
}
