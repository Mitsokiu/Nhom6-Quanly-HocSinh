using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI.UserControls
{
    partial class UC_GVBM_TKB
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.cbBoxnamhoc = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxhk = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Day = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Class = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sub = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Period = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Room = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cbBoxnamhoc);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.comboBoxhk);
            this.panel1.Location = new System.Drawing.Point(3, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(297, 643);
            this.panel1.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(12, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 23);
            this.label7.TabIndex = 18;
            this.label7.Text = "Năm Học";
            // 
            // cbBoxnamhoc
            // 
            this.cbBoxnamhoc.Location = new System.Drawing.Point(112, 21);
            this.cbBoxnamhoc.Name = "cbBoxnamhoc";
            this.cbBoxnamhoc.Size = new System.Drawing.Size(167, 28);
            this.cbBoxnamhoc.TabIndex = 19;
            this.cbBoxnamhoc.SelectedIndexChanged += new System.EventHandler(this.CbBoxnamhoc_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 16;
            this.label5.Text = "HocKI";
            // 
            // comboBoxhk
            // 
            this.comboBoxhk.Location = new System.Drawing.Point(112, 70);
            this.comboBoxhk.Name = "comboBoxhk";
            this.comboBoxhk.Size = new System.Drawing.Size(164, 28);
            this.comboBoxhk.TabIndex = 17;
            this.comboBoxhk.SelectedIndexChanged += new System.EventHandler(this.ComboBoxhk_SelectedIndexChanged);
            this.comboBoxhk.SelectedValueChanged += new System.EventHandler(this.ComboBoxhk_SelectedValueChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Location = new System.Drawing.Point(323, 18);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(831, 643);
            this.panel2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Day,
            this.Class,
            this.Sub,
            this.Period,
            this.Room});
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(821, 625);
            this.dataGridView1.TabIndex = 0;
            // 
            // Day
            // 
            this.Day.HeaderText = "Thứ";
            this.Day.MinimumWidth = 8;
            this.Day.Name = "Day";
            this.Day.Width = 150;
            // 
            // Class
            // 
            this.Class.HeaderText = "Lớp";
            this.Class.MinimumWidth = 8;
            this.Class.Name = "Class";
            this.Class.Width = 150;
            // 
            // Sub
            // 
            this.Sub.HeaderText = "Môn";
            this.Sub.MinimumWidth = 8;
            this.Sub.Name = "Sub";
            this.Sub.Width = 150;
            // 
            // Period
            // 
            this.Period.HeaderText = "Tiết";
            this.Period.MinimumWidth = 8;
            this.Period.Name = "Period";
            this.Period.Width = 150;
            // 
            // Room
            // 
            this.Room.HeaderText = "Phòng";
            this.Room.MinimumWidth = 8;
            this.Room.Name = "Room";
            this.Room.Width = 150;
            // 
            // UC_GVBM_TKB
            // 
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "UC_GVBM_TKB";
            this.Size = new System.Drawing.Size(1219, 837);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label7;
        private ComboBox cbBoxnamhoc;
        private Label label5;
        private ComboBox comboBoxhk;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Day;
        private DataGridViewTextBoxColumn Class;
        private DataGridViewTextBoxColumn Sub;
        private DataGridViewTextBoxColumn Period;
        private DataGridViewTextBoxColumn Room;
    }
}
