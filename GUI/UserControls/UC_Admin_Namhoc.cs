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
    public partial class UC_Admin_Namhoc : UserControl
    {
        public UC_Admin_Namhoc()
        {
            InitializeComponent();
            LoadUserControl(new UC_Admin_Namhoc_HocKi());

        }


        private void LoadUserControl(UserControl uc)
        {
            panel1.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panel1.Controls.Add(uc);
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)

        {
            LoadUserControl(new UC_Admin_Namhoc_HocKi());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UC_Admin_NamHoc_TKB());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UC_Admin_NamHoc_HocPhi());
        }


        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
