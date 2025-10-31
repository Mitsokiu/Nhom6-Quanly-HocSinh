using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.UserControls
{
    public partial class UC_GVCN_QLHS : UserControl
    {
        public UC_GVCN_QLHS()
        {
            InitializeComponent();
            LoadUserControl(new UC_GVCN_DS());
        }
        private void LoadUserControl(UserControl uc)
        {
            panel2.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panel2.Controls.Add(uc);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UC_GVCN_DS());
        }
        private void button2_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UC_GVCN_HocPhi());
        }
    }
}
