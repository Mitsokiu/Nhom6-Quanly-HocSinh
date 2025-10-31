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
    public partial class UC_Admin_NamHoc_HocPhi : UserControl
    {
        public UC_Admin_NamHoc_HocPhi()
        {
            InitializeComponent();
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoadUserControl(UserControl uc)
        {
            panel1.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panel1.Controls.Add(uc);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UC_Admin_NamHoc_HocPhi());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UC_Admin_NamHoc_HocPhi_PhieuThu());
        }
    }
}
