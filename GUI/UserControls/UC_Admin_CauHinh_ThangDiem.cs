using System;
using System.Windows.Forms;
using DTO;
using BUS;

namespace GUI.UserControls
{
    public partial class UC_Admin_CauHinh_ThangDiem : UserControl
    {
        private ThangDiemBUS bus = new ThangDiemBUS();

        public UC_Admin_CauHinh_ThangDiem()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            comboBox1.Items.Clear();
            foreach (var td in bus.GetAll())
            {
                comboBox1.Items.Add(td.LoaiThangDiem);
            }
        }

        private void button1_Click(object sender, EventArgs e) // Lưu
        {
            var td = new ThangDiemDTO
            {
                LoaiThangDiem = comboBox1.Text,
                DiemMieng = float.TryParse(textBox1.Text, out var dm) ? dm : 0,
                Diem15P = float.TryParse(textBox2.Text, out var d15) ? d15 : 0,
                Diem1Tiet = float.TryParse(textBox3.Text, out var d1t) ? d1t : 0,
                HocKi = textBox4.Text
            };

            // Nếu LoaiThangDiem đã tồn tại -> update, ngược lại add mới
            var existing = bus.GetAll().Find(x => x.LoaiThangDiem == td.LoaiThangDiem);
            if (existing != null)
            {
                td.Id = existing.Id;
                bus.Update(td);
            }
            else
            {
                bus.Add(td);
            }
            LoadData();
            MessageBox.Show("Lưu thang điểm thành công!");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var td = bus.GetAll().Find(x => x.LoaiThangDiem == comboBox1.Text);
            if (td != null)
            {
                textBox1.Text = td.DiemMieng.ToString();
                textBox2.Text = td.Diem15P.ToString();
                textBox3.Text = td.Diem1Tiet.ToString();
                textBox4.Text = td.HocKi;
            }
        }
    }
}
