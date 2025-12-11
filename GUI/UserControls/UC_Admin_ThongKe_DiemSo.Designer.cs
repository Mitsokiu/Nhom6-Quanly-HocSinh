namespace GUI.UserControls
{
    partial class UC_Admin_ThongKe_DiemSo
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();

            this.panelControl = new System.Windows.Forms.Panel();
            this.btnFilter = new System.Windows.Forms.Button();
            this.cboSemester = new System.Windows.Forms.ComboBox();
            this.lblSemester = new System.Windows.Forms.Label();
            this.cboGrade = new System.Windows.Forms.ComboBox();
            this.lblGrade = new System.Windows.Forms.Label();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.gbDistribution = new System.Windows.Forms.GroupBox();
            this.chartDistribution = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.gbTop10 = new System.Windows.Forms.GroupBox();
            this.dgvTop10 = new System.Windows.Forms.DataGridView();

            this.panelControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.gbDistribution.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDistribution)).BeginInit();
            this.gbTop10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTop10)).BeginInit();
            this.SuspendLayout();

            // 
            // panelControl (Thanh lọc dữ liệu trên cùng)
            // 
            this.panelControl.BackColor = System.Drawing.Color.White;
            this.panelControl.Controls.Add(this.btnFilter);
            this.panelControl.Controls.Add(this.cboSemester);
            this.panelControl.Controls.Add(this.lblSemester);
            this.panelControl.Controls.Add(this.cboGrade);
            this.panelControl.Controls.Add(this.lblGrade);
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl.Location = new System.Drawing.Point(10, 10);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(980, 70);
            this.panelControl.TabIndex = 0;

            // 
            // lblGrade
            // 
            this.lblGrade.AutoSize = true;
            this.lblGrade.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrade.Location = new System.Drawing.Point(15, 23);
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Size = new System.Drawing.Size(95, 23);
            this.lblGrade.TabIndex = 0;
            this.lblGrade.Text = "Chọn Khối:";

            // 
            // cboGrade
            // 
            this.cboGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrade.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGrade.FormattingEnabled = true;
            this.cboGrade.Location = new System.Drawing.Point(116, 20);
            this.cboGrade.Name = "cboGrade";
            this.cboGrade.Size = new System.Drawing.Size(180, 31);
            this.cboGrade.TabIndex = 1;

            // 
            // lblSemester
            // 
            this.lblSemester.AutoSize = true;
            this.lblSemester.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSemester.Location = new System.Drawing.Point(320, 23);
            this.lblSemester.Name = "lblSemester";
            this.lblSemester.Size = new System.Drawing.Size(116, 23);
            this.lblSemester.TabIndex = 2;
            this.lblSemester.Text = "Chọn Học Kỳ:";

            // 
            // cboSemester
            // 
            this.cboSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSemester.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSemester.FormattingEnabled = true;
            this.cboSemester.Location = new System.Drawing.Point(442, 20);
            this.cboSemester.Name = "cboSemester";
            this.cboSemester.Size = new System.Drawing.Size(180, 31);
            this.cboSemester.TabIndex = 3;

            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.Location = new System.Drawing.Point(660, 16);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(140, 38);
            this.btnFilter.TabIndex = 4;
            this.btnFilter.Text = "Xem Dữ Liệu";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);

            // 
            // splitMain (Container chia đôi màn hình)
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(10, 80);
            this.splitMain.Name = "splitMain";
            this.splitMain.Orientation = System.Windows.Forms.Orientation.Vertical;
            // 
            // splitMain.Panel1 (Phần trên chứa Biểu đồ)
            // 
            this.splitMain.Panel1.Controls.Add(this.gbDistribution);
            this.splitMain.Panel1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            // 
            // splitMain.Panel2 (Phần dưới chứa Bảng Top 10)
            // 
            this.splitMain.Panel2.Controls.Add(this.gbTop10);
            this.splitMain.Size = new System.Drawing.Size(980, 610);
            this.splitMain.SplitterDistance = 300; // Chiều cao cho phần biểu đồ
            this.splitMain.TabIndex = 1;

            // 
            // gbDistribution (Groupbox Biểu đồ)
            // 
            this.gbDistribution.BackColor = System.Drawing.Color.White;
            this.gbDistribution.Controls.Add(this.chartDistribution);
            this.gbDistribution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDistribution.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDistribution.Location = new System.Drawing.Point(0, 10);
            this.gbDistribution.Name = "gbDistribution";
            this.gbDistribution.Size = new System.Drawing.Size(980, 280);
            this.gbDistribution.TabIndex = 0;
            this.gbDistribution.TabStop = false;
            this.gbDistribution.Text = "Tỉ Lệ Phổ Điểm Trung Bình (DTB) Toàn Khối";

            // 
            // chartDistribution
            // 
            chartArea1.Name = "ChartArea1";
            this.chartDistribution.ChartAreas.Add(chartArea1);
            this.chartDistribution.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Right;
            this.chartDistribution.Legends.Add(legend1);
            this.chartDistribution.Location = new System.Drawing.Point(3, 27);
            this.chartDistribution.Name = "chartDistribution";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.IsValueShownAsLabel = true;
            series1.LabelFormat = "{0}%"; // Hiển thị phần trăm nếu muốn
            series1.Legend = "Legend1";
            series1.Name = "DTB_Distribution";
            this.chartDistribution.Series.Add(series1);
            this.chartDistribution.Size = new System.Drawing.Size(974, 250);
            this.chartDistribution.TabIndex = 0;
            this.chartDistribution.Text = "chart1";

            // 
            // gbTop10 (Groupbox Bảng Top 10)
            // 
            this.gbTop10.BackColor = System.Drawing.Color.White;
            this.gbTop10.Controls.Add(this.dgvTop10);
            this.gbTop10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbTop10.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTop10.Location = new System.Drawing.Point(0, 0);
            this.gbTop10.Name = "gbTop10";
            this.gbTop10.Size = new System.Drawing.Size(980, 306);
            this.gbTop10.TabIndex = 0;
            this.gbTop10.TabStop = false;
            this.gbTop10.Text = "TOP 10 Học Sinh Có Điểm Trung Bình Cao Nhất Khối";

            // 
            // dgvTop10
            // 
            this.dgvTop10.AllowUserToAddRows = false;
            this.dgvTop10.AllowUserToDeleteRows = false;
            this.dgvTop10.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTop10.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvTop10.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTop10.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTop10.ColumnHeadersHeight = 35;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTop10.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTop10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTop10.EnableHeadersVisualStyles = false;
            this.dgvTop10.GridColor = System.Drawing.Color.LightGray;
            this.dgvTop10.Location = new System.Drawing.Point(3, 27);
            this.dgvTop10.Name = "dgvTop10";
            this.dgvTop10.ReadOnly = true;
            this.dgvTop10.RowHeadersVisible = false;
            this.dgvTop10.RowHeadersWidth = 51;
            this.dgvTop10.RowTemplate.Height = 30;
            this.dgvTop10.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTop10.Size = new System.Drawing.Size(974, 276);
            this.dgvTop10.TabIndex = 0;

            // 
            // UC_Admin_ThongKe_DiemSo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.panelControl);
            this.Name = "UC_Admin_ThongKe_DiemSo";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(1000, 700);
            this.Load += new System.EventHandler(this.UC_Admin_ThongKe_DiemSo_Load);
            this.panelControl.ResumeLayout(false);
            this.panelControl.PerformLayout();
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.gbDistribution.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartDistribution)).EndInit();
            this.gbTop10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTop10)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelControl;
        private System.Windows.Forms.Label lblGrade;
        private System.Windows.Forms.ComboBox cboGrade;
        private System.Windows.Forms.Label lblSemester;
        private System.Windows.Forms.ComboBox cboSemester;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.GroupBox gbDistribution;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDistribution;
        private System.Windows.Forms.GroupBox gbTop10;
        private System.Windows.Forms.DataGridView dgvTop10;
    }
}