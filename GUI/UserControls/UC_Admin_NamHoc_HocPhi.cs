using System;
using System.Windows.Forms;
using DTO;
using BUS;

namespace GUI.UserControls
{
    public partial class UC_Admin_NamHoc_HocPhi : UserControl
    {
        private HocPhiBUS bus = new HocPhiBUS();

        public UC_Admin_NamHoc_HocPhi()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            dataGridView1.Rows.Clear();
            foreach (var hp in bus.GetAll())
            {
                dataGridView1.Rows.Add(hp.HoTen, hp.NgaySinh.ToShortDateString(), hp.Lop, hp.KhoanThu, hp.SoTien, hp.TrangThai, hp.NgayDong.ToShortDateString());
            }
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
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int idx = dataGridView1.SelectedRows[0].Index;
                var hp = bus.GetAll()[idx];
                hp.HoTen = textBox2.Text;
                hp.Lop = comboBox1.SelectedItem?.ToString();
                hp.TrangThai = textBox3.Text;
                hp.NgayDong = dateTimePicker1.Value;
                bus.Update(hp);
                LoadData();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Optional: custom painting
        }
    }
}
