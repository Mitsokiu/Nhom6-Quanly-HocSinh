using System;
using System.Drawing;
using System.Windows.Forms;
namespace GUI.UserControls
{
    partial class UC_Admin_NamHoc_TKB
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Day = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Period = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Class = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Teacher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Room = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBoxYear = new System.Windows.Forms.ComboBox();
            this.comboBoxHocKi = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCreat = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Day,
            this.Period,
            this.Class,
            this.Subject,
            this.Teacher,
            this.Room});
            this.dataGridView1.Location = new System.Drawing.Point(358, 14);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(1004, 446);
            this.dataGridView1.TabIndex = 2;
            // 
            // Day
            // 
            this.Day.HeaderText = "Thứ";
            this.Day.MinimumWidth = 8;
            this.Day.Name = "Day";
            this.Day.Width = 150;
            // 
            // Period
            // 
            this.Period.HeaderText = "Tiết";
            this.Period.MinimumWidth = 8;
            this.Period.Name = "Period";
            this.Period.Width = 150;
            // 
            // Class
            // 
            this.Class.HeaderText = "Lớp";
            this.Class.MinimumWidth = 8;
            this.Class.Name = "Class";
            this.Class.Width = 150;
            // 
            // Subject
            // 
            this.Subject.HeaderText = "Môn";
            this.Subject.MinimumWidth = 8;
            this.Subject.Name = "Subject";
            this.Subject.Width = 150;
            // 
            // Teacher
            // 
            this.Teacher.HeaderText = "Gíao Viên";
            this.Teacher.MinimumWidth = 8;
            this.Teacher.Name = "Teacher";
            this.Teacher.Width = 150;
            // 
            // Room
            // 
            this.Room.HeaderText = "Phòng";
            this.Room.MinimumWidth = 8;
            this.Room.Name = "Room";
            this.Room.Width = 150;
            // 
            // comboBoxYear
            // 
            this.comboBoxYear.FormattingEnabled = true;
            this.comboBoxYear.Location = new System.Drawing.Point(83, 15);
            this.comboBoxYear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxYear.Name = "comboBoxYear";
            this.comboBoxYear.Size = new System.Drawing.Size(83, 28);
            this.comboBoxYear.TabIndex = 0;
            // 
            // comboBoxHocKi
            // 
            this.comboBoxHocKi.FormattingEnabled = true;
            this.comboBoxHocKi.Location = new System.Drawing.Point(258, 15);
            this.comboBoxHocKi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxHocKi.Name = "comboBoxHocKi";
            this.comboBoxHocKi.Size = new System.Drawing.Size(80, 28);
            this.comboBoxHocKi.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Năm Học";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(190, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Học Kì";
            // 
            // btnCreat
            // 
            this.btnCreat.Location = new System.Drawing.Point(3, 64);
            this.btnCreat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCreat.Name = "btnCreat";
            this.btnCreat.Size = new System.Drawing.Size(77, 27);
            this.btnCreat.TabIndex = 9;
            this.btnCreat.Text = "Tạo TKB";
            this.btnCreat.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCreat);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comboBoxHocKi);
            this.panel1.Controls.Add(this.comboBoxYear);
            this.panel1.Location = new System.Drawing.Point(3, 14);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 446);
            this.panel1.TabIndex = 0;
            // 
            // UC_Admin_NamHoc_TKB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UC_Admin_NamHoc_TKB";
            this.Size = new System.Drawing.Size(1365, 482);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Day;
        private DataGridViewTextBoxColumn Period;
        private DataGridViewTextBoxColumn Class;
        private DataGridViewTextBoxColumn Subject;
        private DataGridViewTextBoxColumn Teacher;
        private DataGridViewTextBoxColumn Room;
        private ComboBox comboBoxYear;
        private ComboBox comboBoxHocKi;
        private Label label1;
        private Label label2;
        private Button btnCreat;
        private Panel panel1;
    }
}
