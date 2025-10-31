using System;
using System.Drawing;
using System.Windows.Forms;
namespace GUI.UserControls
{
    partial class UC_HocSinh_TKB
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            Thu2 = new DataGridViewTextBoxColumn();
            Thu3 = new DataGridViewTextBoxColumn();
            Thu4 = new DataGridViewTextBoxColumn();
            Thu5 = new DataGridViewTextBoxColumn();
            Thu6 = new DataGridViewTextBoxColumn();
            Thu7 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Thu2, Thu3, Thu4, Thu5, Thu6, Thu7 });
            dataGridView1.Location = new Point(20, 15);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(919, 496);
            dataGridView1.TabIndex = 0;
            // 
            // Thu2
            // 
            Thu2.HeaderText = "Thứ 2";
            Thu2.MinimumWidth = 8;
            Thu2.Name = "Thu2";
            Thu2.Width = 150;
            // 
            // Thu3
            // 
            Thu3.HeaderText = "Thứ 3";
            Thu3.MinimumWidth = 8;
            Thu3.Name = "Thu3";
            Thu3.Width = 150;
            // 
            // Thu4
            // 
            Thu4.HeaderText = "Thứ 4";
            Thu4.MinimumWidth = 8;
            Thu4.Name = "Thu4";
            Thu4.Width = 150;
            // 
            // Thu5
            // 
            Thu5.HeaderText = "Thứ 5";
            Thu5.MinimumWidth = 8;
            Thu5.Name = "Thu5";
            Thu5.Width = 150;
            // 
            // Thu6
            // 
            Thu6.HeaderText = "Thứ 6";
            Thu6.MinimumWidth = 8;
            Thu6.Name = "Thu6";
            Thu6.Width = 150;
            // 
            // Thu7
            // 
            Thu7.HeaderText = "Thứ 7";
            Thu7.MinimumWidth = 8;
            Thu7.Name = "Thu7";
            Thu7.Width = 150;
            // 
            // UC_HocSinh_TKB
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridView1);
            Name = "UC_HocSinh_TKB";
            Size = new Size(951, 547);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Thu2;
        private DataGridViewTextBoxColumn Thu3;
        private DataGridViewTextBoxColumn Thu4;
        private DataGridViewTextBoxColumn Thu5;
        private DataGridViewTextBoxColumn Thu6;
        private DataGridViewTextBoxColumn Thu7;
    }
}
