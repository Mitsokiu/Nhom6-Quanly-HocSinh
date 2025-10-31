namespace Studenapp.UserControls
{
    partial class UC_Admin_Class_KhoiLop
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
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            dataGridView1 = new DataGridView();
            id = new DataGridViewTextBoxColumn();
            Khoi = new DataGridViewTextBoxColumn();
            Lop = new DataGridViewTextBoxColumn();
            GVCN = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // textBox3
            // 
            textBox3.Location = new Point(117, 123);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(281, 31);
            textBox3.TabIndex = 20;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(117, 217);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(281, 31);
            textBox2.TabIndex = 19;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(117, 40);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(281, 31);
            textBox1.TabIndex = 18;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 123);
            label3.Name = "label3";
            label3.Size = new Size(42, 25);
            label3.TabIndex = 17;
            label3.Text = "Lớp";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 223);
            label2.Name = "label2";
            label2.Size = new Size(59, 25);
            label2.TabIndex = 16;
            label2.Text = "GVCN";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 46);
            label1.Name = "label1";
            label1.Size = new Size(47, 25);
            label1.TabIndex = 15;
            label1.Text = "Khối";
            // 
            // button6
            // 
            button6.Location = new Point(330, 434);
            button6.Name = "button6";
            button6.Size = new Size(112, 34);
            button6.TabIndex = 14;
            button6.Text = "Xóa";
            button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(175, 434);
            button5.Name = "button5";
            button5.Size = new Size(112, 34);
            button5.TabIndex = 13;
            button5.Text = "Sửa";
            button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(7, 434);
            button4.Name = "button4";
            button4.Size = new Size(112, 34);
            button4.TabIndex = 12;
            button4.Text = "Thêm";
            button4.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { id, Khoi, Lop, GVCN });
            dataGridView1.Location = new Point(448, 15);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(666, 474);
            dataGridView1.TabIndex = 11;
            // 
            // id
            // 
            id.HeaderText = "ID";
            id.MinimumWidth = 8;
            id.Name = "id";
            id.Width = 150;
            // 
            // Khoi
            // 
            Khoi.HeaderText = "Khối";
            Khoi.MinimumWidth = 8;
            Khoi.Name = "Khoi";
            Khoi.Width = 150;
            // 
            // Lop
            // 
            Lop.HeaderText = "Lop";
            Lop.MinimumWidth = 8;
            Lop.Name = "Lop";
            Lop.Width = 150;
            // 
            // GVCN
            // 
            GVCN.HeaderText = "GVCN";
            GVCN.MinimumWidth = 8;
            GVCN.Name = "GVCN";
            GVCN.Width = 150;
            // 
            // UC_Admin_Class_KhoiLop
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(dataGridView1);
            Name = "UC_Admin_Class_KhoiLop";
            Size = new Size(1123, 505);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button button6;
        private Button button5;
        private Button button4;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn Khoi;
        private DataGridViewTextBoxColumn Lop;
        private DataGridViewTextBoxColumn GVCN;
    }
}
