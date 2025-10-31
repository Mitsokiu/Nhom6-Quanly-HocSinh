namespace Studenapp.UserControls
{
    partial class UC_GVBM_TKB
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
            Thu = new DataGridViewTextBoxColumn();
            Tiet = new DataGridViewTextBoxColumn();
            Mon = new DataGridViewTextBoxColumn();
            Lop = new DataGridViewTextBoxColumn();
            Phong = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Thu, Tiet, Mon, Lop, Phong });
            dataGridView1.Location = new Point(30, 21);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(818, 589);
            dataGridView1.TabIndex = 0;
            // 
            // Thu
            // 
            Thu.HeaderText = "Thứ";
            Thu.MinimumWidth = 8;
            Thu.Name = "Thu";
            Thu.Width = 150;
            // 
            // Tiet
            // 
            Tiet.HeaderText = "Tiết";
            Tiet.MinimumWidth = 8;
            Tiet.Name = "Tiet";
            Tiet.Width = 150;
            // 
            // Mon
            // 
            Mon.HeaderText = "Môn";
            Mon.MinimumWidth = 8;
            Mon.Name = "Mon";
            Mon.Width = 150;
            // 
            // Lop
            // 
            Lop.HeaderText = "Lớp";
            Lop.MinimumWidth = 8;
            Lop.Name = "Lop";
            Lop.Width = 150;
            // 
            // Phong
            // 
            Phong.HeaderText = "Phòng";
            Phong.MinimumWidth = 8;
            Phong.Name = "Phong";
            Phong.Width = 150;
            // 
            // UC_GVBM_TKB
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridView1);
            Name = "UC_GVBM_TKB";
            Size = new Size(865, 639);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Thu;
        private DataGridViewTextBoxColumn Tiet;
        private DataGridViewTextBoxColumn Mon;
        private DataGridViewTextBoxColumn Lop;
        private DataGridViewTextBoxColumn Phong;
    }
}
