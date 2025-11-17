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
    public partial class HocPhiControl : UserControl
    {
        public HocPhiControl()
        {
            InitializeComponent();
        }

        private void btnThemKhoanPhi_Click(object sender, EventArgs e)
        {
            ThemHocPhi themHocPhiForm = new ThemHocPhi();
            themHocPhiForm.ShowDialog();
        }

        private void lblValueQuaHan_Click(object sender, EventArgs e)
        {

        }
    }
}
