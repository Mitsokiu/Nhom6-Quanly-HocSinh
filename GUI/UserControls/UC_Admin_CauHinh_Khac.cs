using System;
using System.Windows.Forms;
using DTO;
using BUS;

namespace GUI.UserControls
{
    public partial class UC_Admin_CauHinh_Khac : UserControl
    {
        private TruongBUS truongBus = new TruongBUS();
        private ThongBaoBUS tbBus = new ThongBaoBUS();
        private TruongDTO currentTruong = null;

        public UC_Admin_CauHinh_Khac()
        {
            InitializeComponent();
            LoadTruong();
        }

        private void LoadTruong()
        {
            var list = truongBus.GetAll();
            if (list.Count > 0)
            {
                currentTruong = list[0];
                textBox1.Text = currentTruong.TenTruong;
                textBox2.Text = currentTruong.DiaChi;
                textBox3.Text = currentTruong.Gmail;
                textBox4.Text = currentTruong.NamThanhLap.ToString();
                if (!string.IsNullOrEmpty(currentTruong.LogoPath))
                {
                    pictureBox1.ImageLocation = currentTruong.LogoPath;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e) // Lưu thông tin trường
        {
            if (currentTruong == null)
            {
                currentTruong = new TruongDTO();
                truongBus.Add(currentTruong);
            }

            currentTruong.TenTruong = textBox1.Text;
            currentTruong.DiaChi = textBox2.Text;
            currentTruong.Gmail = textBox3.Text;
            int.TryParse(textBox4.Text, out int nam);
            currentTruong.NamThanhLap = nam;

            if (pictureBox1.ImageLocation != null)
                currentTruong.LogoPath = pictureBox1.ImageLocation;

            truongBus.Update(currentTruong);
            MessageBox.Show("Lưu thông tin trường thành công!");
        }

        private void button2_Click(object sender, EventArgs e) // Tạo thông báo
        {
            if (!string.IsNullOrWhiteSpace(textBox5.Text))
            {
                ThongBaoDTO tb = new ThongBaoDTO { NoiDung = textBox5.Text };
                tbBus.Add(tb);
                MessageBox.Show("Thông báo đã được tạo!");
                textBox5.Clear();
            }
        }
    }
}
