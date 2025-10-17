namespace Studenapp.UserControls
{
    partial class UC_Admin_Class_Monhoc
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
            components = new System.ComponentModel.Container();
            dataGridView1 = new DataGridView();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            label1 = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            textBox1 = new TextBox();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            mamon = new DataGridViewTextBoxColumn();
            Heso = new DataGridViewTextBoxColumn();
            NameMH = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { mamon, Heso, NameMH });
            dataGridView1.Location = new Point(438, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(515, 484);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(52, 63);
            label1.Name = "label1";
            label1.Size = new Size(49, 25);
            label1.TabIndex = 4;
            label1.Text = "Môn";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(24, 24);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // textBox1
            // 
            textBox1.Location = new Point(156, 60);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 31);
            textBox1.TabIndex = 6;
            // 
            // button6
            // 
            button6.Location = new Point(308, 401);
            button6.Name = "button6";
            button6.Size = new Size(112, 34);
            button6.TabIndex = 9;
            button6.Text = "Xóa";
            button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(169, 401);
            button5.Name = "button5";
            button5.Size = new Size(112, 34);
            button5.TabIndex = 8;
            button5.Text = "Sửa";
            button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(27, 401);
            button4.Name = "button4";
            button4.Size = new Size(112, 34);
            button4.TabIndex = 7;
            button4.Text = "Thêm";
            button4.UseVisualStyleBackColor = true;
            // 
            // mamon
            // 
            mamon.HeaderText = "Mã Môn";
            mamon.MinimumWidth = 8;
            mamon.Name = "mamon";
            mamon.Width = 150;
            // 
            // Heso
            // 
            Heso.HeaderText = "Hệ Số";
            Heso.MinimumWidth = 8;
            Heso.Name = "Heso";
            Heso.Width = 150;
            // 
            // NameMH
            // 
            NameMH.HeaderText = "Tên Môn Học";
            NameMH.MinimumWidth = 8;
            NameMH.Name = "NameMH";
            NameMH.Width = 150;
            // 
            // UC_Admin_Class_Monhoc
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "UC_Admin_Class_Monhoc";
            Size = new Size(956, 490);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label label1;
        private ContextMenuStrip contextMenuStrip1;
        private TextBox textBox1;
        private Button button6;
        private Button button5;
        private Button button4;
        private DataGridViewTextBoxColumn mamon;
        private DataGridViewTextBoxColumn Heso;
        private DataGridViewTextBoxColumn NameMH;
    }
}
