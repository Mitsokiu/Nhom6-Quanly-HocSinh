using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Sidebar : UserControl
    {
        public event EventHandler BtnNhapDiemClick;
        public event EventHandler BtnXemDiemClick;
        public event EventHandler BtnHocSinhClick;
        public event EventHandler BtnHocPhiClick;
        public Sidebar()
        {
            InitializeComponent();
        }

        private void btnXemDiem_Click(object sender, EventArgs e)
        {

        }

        private void btnDiemDanh_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lbInfo_Click(object sender, EventArgs e)
        {

        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {

        }

        private void btnNhapDiem_Click(object sender, EventArgs e)
        {
            BtnNhapDiemClick?.Invoke(this, EventArgs.Empty);
        }

        private void btnXemDiem_Click_1(object sender, EventArgs e)
        {
            BtnXemDiemClick?.Invoke(this, EventArgs.Empty);
        }

        private void btnHocSinh_Click(object sender, EventArgs e)
        {
            BtnHocSinhClick?.Invoke(this, EventArgs.Empty);
        }

        private void btnHocPhi_Click_1(object sender, EventArgs e)
        {
            BtnHocPhiClick?.Invoke(this, EventArgs.Empty);
        }
    }
}
