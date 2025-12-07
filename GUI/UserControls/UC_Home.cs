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
    public partial class UC_Home : UserControl
    {
        public UC_Home()
        {
            InitializeComponent();
            LoadLatestNotification();
        }

        private void UC_Home_Load(object sender, EventArgs e)
        {

        }

        private void LoadLatestNotification()
        {
            var n = NotificationBUS.GetLatest();
            if (n != null)
            {
                labeltitle.Text = n.Title;
                labelmes.Text = n.Message;
                labeldate.Text = n.CreatedAt.ToString("dd/MM/yyyy HH:mm");
            }
            else
            {
                labeltitle.Text = "";
                labelmes.Text = "";
                labeldate.Text = "";
            }
         }

    }
}
