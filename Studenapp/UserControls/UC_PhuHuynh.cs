using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Studenapp.UserControls
{
    public partial class UC_PhuHuynh : UserControl
    {
        public UC_PhuHuynh()
        {
            InitializeComponent();
            LoadUserControl(new UC_PhuHuynh_Thongtin());
        }


        private void LoadUserControl(UserControl uc)
        {
            panel2.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panel2.Controls.Add(uc);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UC_HocSinh_Diem());
        }
        private void button2_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UC_PhuHuynh_NhanXet());
        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
