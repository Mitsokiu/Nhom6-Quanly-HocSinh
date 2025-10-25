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
    public partial class MainForm : Form
    {
        private Sidebar sidebar;
        public MainForm()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;

            sidebar = new Sidebar();
            sidebar.Dock = DockStyle.Left;
            sidebar.Width = sidebar.PreferredSize.Width;
            sidebar.Height = sidebar.PreferredSize.Height;
            this.Controls.Add(sidebar); 
        }
    }
}
