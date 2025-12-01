using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI.UserControls
{
    partial class UC_GVBM_TKB
    {
        private System.ComponentModel.IContainer components = null;
        private ComboBox cbSemester;
        private Label lblSemester;
        private DataGridView dataGridView1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cbSemester = new System.Windows.Forms.ComboBox();
            this.lblSemester = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeight = 52;
            this.dataGridView1.Location = new System.Drawing.Point(28, 77);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 92;
            this.dataGridView1.RowTemplate.Height = 50;
            this.dataGridView1.Size = new System.Drawing.Size(1441, 760);
            this.dataGridView1.TabIndex = 2;
            // 
            // cbSemester
            // 
            this.cbSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSemester.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbSemester.Location = new System.Drawing.Point(260, 15);
            this.cbSemester.Name = "cbSemester";
            this.cbSemester.Size = new System.Drawing.Size(553, 56);
            this.cbSemester.TabIndex = 1;
            this.cbSemester.SelectedIndexChanged += new System.EventHandler(this.cbSemester_SelectedIndexChanged);
            // 
            // lblSemester
            // 
            this.lblSemester.AutoSize = true;
            this.lblSemester.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSemester.Location = new System.Drawing.Point(20, 18);
            this.lblSemester.Name = "lblSemester";
            this.lblSemester.Size = new System.Drawing.Size(238, 48);
            this.lblSemester.TabIndex = 0;
            this.lblSemester.Text = "Chọn học kỳ:";
            // 
            // UC_GVBM_TKB
            // 
            this.Controls.Add(this.lblSemester);
            this.Controls.Add(this.cbSemester);
            this.Controls.Add(this.dataGridView1);
            this.Name = "UC_GVBM_TKB";
            this.Size = new System.Drawing.Size(1491, 860);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
