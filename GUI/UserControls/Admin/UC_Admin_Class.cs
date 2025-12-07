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
    public partial class UC_Admin_Class : UserControl
    {
        public UC_Admin_Class()
        {
            InitializeComponent();
            LoadUserControl(new UC_Admin_Class_KhoiLop());
        }
        private void LoadUserControl(UserControl uc)
        {
            panel1.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panel1.Controls.Add(uc);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UC_Admin_Class_KhoiLop());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UC_Admin_Class_Monhoc());
        }


        private void button3_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UC_Admin_Class_Phancong());
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void napel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UC_Admin_PhanCong_gvcn());
        }
    }
}
