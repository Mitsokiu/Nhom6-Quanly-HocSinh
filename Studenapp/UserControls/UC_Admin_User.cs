using StudentMan;
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
    public partial class UC_Admin_User : UserControl
    {
        public UC_Admin_User()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            AddUserForm formAdd = new AddUserForm();
            formAdd.StartPosition = FormStartPosition.CenterParent; // cho form hiện giữa màn hình
            formAdd.ShowDialog(); // hiển thị form (modal)


        }

    }
}
