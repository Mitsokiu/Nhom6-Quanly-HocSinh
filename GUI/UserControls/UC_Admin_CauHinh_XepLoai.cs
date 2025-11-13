using System;
using System.Windows.Forms;
using DTO;
using BUS;

namespace GUI.UserControls
{
    public partial class UC_Admin_CauHinh_XepLoai : UserControl
    {
        private XepLoaiBUS bus = new XepLoaiBUS();
        private XepLoaiDTO currentXepLoai = null;

        public UC_Admin_CauHinh_XepLoai()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            var list = bus.GetAll();
            if (list.Count > 0)
            {
                currentXepLoai = list[0];
                numericUpDown1.Value = (decimal)currentXepLoai.Gioi;
                numericUpDown2.Value = (decimal)currentXepLoai.Kha;
                numericUpDown3.Value = (decimal)currentXepLoai.TrungBinh;
                numericUpDown4.Value = (decimal)currentXepLoai.Yeu;
                comboBox1.Text = currentXepLoai.HanhKiem;
                textBox1.Text = currentXepLoai.CongThucTB;
            }
        }

        private void button1_Click(object sender, EventArgs e) // Lưu
        {
            if (currentXepLoai == null)
            {
                currentXepLoai = new XepLoaiDTO();
                bus.Add(currentXepLoai);
            }

            currentXepLoai.Gioi = (float)numericUpDown1.Value;
            currentXepLoai.Kha = (float)numericUpDown2.Value;
            currentXepLoai.TrungBinh = (float)numericUpDown3.Value;
            currentXepLoai.Yeu = (float)numericUpDown4.Value;
            currentXepLoai.HanhKiem = comboBox1.Text;
            currentXepLoai.CongThucTB = textBox1.Text;

            bus.Update(currentXepLoai);
            MessageBox.Show("Lưu xếp loại thành công!");
        }
    }
}
