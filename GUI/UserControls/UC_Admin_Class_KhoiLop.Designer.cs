using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI.UserControls
{
    partial class UC_Admin_Class_KhoiLop
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.textBox4 = new TextBox(); // Mã
            this.textBox1 = new TextBox(); // Khối
            this.textBox3 = new TextBox(); // Lớp
            this.textBox2 = new TextBox(); // GVCN
            this.label4 = new Label();
            this.label1 = new Label();
            this.label3 = new Label();
            this.label2 = new Label();
            this.button4 = new Button(); // Thêm
            this.button5 = new Button(); // Sửa
            this.button6 = new Button(); // Xóa
            this.dataGridView1 = new DataGridView();
            this.ID = new DataGridViewTextBoxColumn();
            this.Khoi = new DataGridViewTextBoxColumn();
            this.Lop = new DataGridViewTextBoxColumn();
            this.GVCN = new DataGridViewTextBoxColumn();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();

            // Labels & TextBoxes
            label4.Text = "Mã"; label4.Location = new Point(29, 39);
            label1.Text = "Khối"; label1.Location = new Point(29, 94);
            label3.Text = "Lớp"; label3.Location = new Point(29, 149);
            label2.Text = "GVCN"; label2.Location = new Point(29, 219);

            textBox4.Location = new Point(105, 36);
            textBox1.Location = new Point(105, 91);
            textBox3.Location = new Point(105, 143);
            textBox2.Location = new Point(105, 219);

            // Buttons
            button4.Text = "Thêm"; button4.Location = new Point(6, 347);
            button4.Click += btnAdd_Click;
            button5.Text = "Sửa"; button5.Location = new Point(158, 347);
            button5.Click += btnSua_Click;
            button6.Text = "Xóa"; button6.Location = new Point(297, 347);
            button6.Click += btnXoa_Click;

            // DataGridView
            dataGridView1.Location = new Point(421, 13); dataGridView1.Size = new Size(700, 379);
            dataGridView1.Columns.AddRange(ID, Khoi, Lop, GVCN);
            dataGridView1.CellClick += DataGridView1_CellClick;

            ID.HeaderText = "Mã"; Khoi.HeaderText = "Khối"; Lop.HeaderText = "Lớp"; GVCN.HeaderText = "GVCN";

            // Add Controls
            Controls.Add(textBox4); Controls.Add(label4);
            Controls.Add(textBox1); Controls.Add(label1);
            Controls.Add(textBox3); Controls.Add(label3);
            Controls.Add(textBox2); Controls.Add(label2);
            Controls.Add(button4); Controls.Add(button5); Controls.Add(button6);
            Controls.Add(dataGridView1);

            AutoScaleMode = AutoScaleMode.Font;
            Size = new Size(1121, 404);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private TextBox textBox4, textBox1, textBox3, textBox2;
        private Label label4, label1, label3, label2;
        private Button button4, button5, button6;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn ID, Khoi, Lop, GVCN;
    }
}
