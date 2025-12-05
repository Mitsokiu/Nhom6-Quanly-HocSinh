namespace GUI.UserControls
{
    partial class UC_HocSinh_HocPhi
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSemester; // Label "Chọn học kỳ"
        private System.Windows.Forms.ComboBox cboSemester; // ComboBox đây
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.DataGridView dgvHocPhi;
        private System.Windows.Forms.Panel panelPagination;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnPage1;
        private System.Windows.Forms.Button btnPage2;
        private System.Windows.Forms.Button btnPage3;
        private System.Windows.Forms.Label lblDots;
        private System.Windows.Forms.Button btnPageLast;
        private System.Windows.Forms.Button btnNext;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.cboSemester = new System.Windows.Forms.ComboBox();
            this.lblSemester = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.dgvHocPhi = new System.Windows.Forms.DataGridView();
            this.panelPagination = new System.Windows.Forms.Panel();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPageLast = new System.Windows.Forms.Button();
            this.lblDots = new System.Windows.Forms.Label();
            this.btnPage3 = new System.Windows.Forms.Button();
            this.btnPage2 = new System.Windows.Forms.Button();
            this.btnPage1 = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHocPhi)).BeginInit();
            this.panelPagination.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.Transparent;
            this.panelHeader.Controls.Add(this.cboSemester);
            this.panelHeader.Controls.Add(this.lblSemester);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Height = 80;
            this.panelHeader.Location = new System.Drawing.Point(30, 30);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1040, 80);
            this.panelHeader.TabIndex = 0;
            // 
            // cboSemester
            // 
            this.cboSemester.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSemester.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboSemester.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cboSemester.FormattingEnabled = true;
            this.cboSemester.Location = new System.Drawing.Point(720, 35);
            this.cboSemester.Name = "cboSemester";
            this.cboSemester.Size = new System.Drawing.Size(300, 33);
            this.cboSemester.TabIndex = 2;
            // 
            // lblSemester
            // 
            this.lblSemester.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSemester.AutoSize = true;
            this.lblSemester.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSemester.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.lblSemester.Location = new System.Drawing.Point(720, 8);
            this.lblSemester.Name = "lblSemester";
            this.lblSemester.Size = new System.Drawing.Size(108, 23);
            this.lblSemester.TabIndex = 1;
            this.lblSemester.Text = "Chọn học kỳ:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(369, 54);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Thông Tin Học Phí";
            // 
            // panelContainer
            // 
            this.panelContainer.BackColor = System.Drawing.Color.White;
            this.panelContainer.Controls.Add(this.dgvHocPhi);
            this.panelContainer.Controls.Add(this.panelPagination);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(30, 110);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Padding = new System.Windows.Forms.Padding(20);
            this.panelContainer.Size = new System.Drawing.Size(1040, 560);
            this.panelContainer.TabIndex = 1;
            // 
            // dgvHocPhi
            // 
            this.dgvHocPhi.AllowUserToAddRows = false;
            this.dgvHocPhi.AllowUserToResizeRows = false;
            this.dgvHocPhi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHocPhi.BackgroundColor = System.Drawing.Color.White;
            this.dgvHocPhi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHocPhi.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvHocPhi.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(120)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(120)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHocPhi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHocPhi.ColumnHeadersHeight = 50;
            this.dgvHocPhi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHocPhi.EnableHeadersVisualStyles = false;
            this.dgvHocPhi.Location = new System.Drawing.Point(20, 20);
            this.dgvHocPhi.Name = "dgvHocPhi";
            this.dgvHocPhi.RowHeadersVisible = false;
            this.dgvHocPhi.RowHeadersWidth = 51;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.dgvHocPhi.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHocPhi.RowTemplate.Height = 60;
            this.dgvHocPhi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHocPhi.Size = new System.Drawing.Size(1000, 460);
            this.dgvHocPhi.TabIndex = 0;
            // 
            // panelPagination
            // 
            this.panelPagination.Controls.Add(this.btnNext);
            this.panelPagination.Controls.Add(this.btnPageLast);
            this.panelPagination.Controls.Add(this.lblDots);
            this.panelPagination.Controls.Add(this.btnPage3);
            this.panelPagination.Controls.Add(this.btnPage2);
            this.panelPagination.Controls.Add(this.btnPage1);
            this.panelPagination.Controls.Add(this.btnPrev);
            this.panelPagination.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelPagination.Location = new System.Drawing.Point(20, 480);
            this.panelPagination.Name = "panelPagination";
            this.panelPagination.Size = new System.Drawing.Size(1000, 60);
            this.panelPagination.TabIndex = 1;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(630, 10);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(40, 40);
            this.btnNext.TabIndex = 6;
            // 
            // btnPageLast
            // 
            this.btnPageLast.Location = new System.Drawing.Point(580, 10);
            this.btnPageLast.Name = "btnPageLast";
            this.btnPageLast.Size = new System.Drawing.Size(40, 40);
            this.btnPageLast.TabIndex = 5;
            // 
            // lblDots
            // 
            this.lblDots.AutoSize = true;
            this.lblDots.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblDots.Location = new System.Drawing.Point(550, 15);
            this.lblDots.Name = "lblDots";
            this.lblDots.Size = new System.Drawing.Size(28, 28);
            this.lblDots.TabIndex = 4;
            this.lblDots.Text = "...";
            // 
            // btnPage3
            // 
            this.btnPage3.Location = new System.Drawing.Point(500, 10);
            this.btnPage3.Name = "btnPage3";
            this.btnPage3.Size = new System.Drawing.Size(40, 40);
            this.btnPage3.TabIndex = 3;
            // 
            // btnPage2
            // 
            this.btnPage2.Location = new System.Drawing.Point(450, 10);
            this.btnPage2.Name = "btnPage2";
            this.btnPage2.Size = new System.Drawing.Size(40, 40);
            this.btnPage2.TabIndex = 2;
            // 
            // btnPage1
            // 
            this.btnPage1.Location = new System.Drawing.Point(400, 10);
            this.btnPage1.Name = "btnPage1";
            this.btnPage1.Size = new System.Drawing.Size(40, 40);
            this.btnPage1.TabIndex = 1;
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(350, 10);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(40, 40);
            this.btnPrev.TabIndex = 0;
            // 
            // UC_HocSinh_HocPhi
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panelHeader);
            this.Name = "UC_HocSinh_HocPhi";
            this.Padding = new System.Windows.Forms.Padding(30);
            this.Size = new System.Drawing.Size(1100, 700);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHocPhi)).EndInit();
            this.panelPagination.ResumeLayout(false);
            this.panelPagination.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}