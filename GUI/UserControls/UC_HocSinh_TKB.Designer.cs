namespace GUI.UserControls
{
    partial class UC_HocSinh_TKB
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Các control giao diện
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelWeekWrapper;
        private System.Windows.Forms.Label lblWeekTitle;
        public System.Windows.Forms.ComboBox cboWeek;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.TableLayoutPanel tblTimetable;

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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelWeekWrapper = new System.Windows.Forms.Panel();
            this.cboWeek = new System.Windows.Forms.ComboBox();
            this.lblWeekTitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.tblTimetable = new System.Windows.Forms.TableLayoutPanel();
            this.panelHeader.SuspendLayout();
            this.panelWeekWrapper.SuspendLayout();
            this.panelContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.panelWeekWrapper);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(20, 20);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(960, 60);
            this.panelHeader.TabIndex = 0;
            // 
            // panelWeekWrapper
            // 
            this.panelWeekWrapper.Controls.Add(this.cboWeek);
            this.panelWeekWrapper.Controls.Add(this.lblWeekTitle);
            this.panelWeekWrapper.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelWeekWrapper.Location = new System.Drawing.Point(510, 0);
            this.panelWeekWrapper.Name = "panelWeekWrapper";
            this.panelWeekWrapper.Size = new System.Drawing.Size(450, 60);
            this.panelWeekWrapper.TabIndex = 1;
            // 
            // cboWeek
            // 
            this.cboWeek.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWeek.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboWeek.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboWeek.FormattingEnabled = true;
            this.cboWeek.Location = new System.Drawing.Point(125, 15);
            this.cboWeek.Name = "cboWeek";
            this.cboWeek.Size = new System.Drawing.Size(310, 31);
            this.cboWeek.TabIndex = 1;
            // 
            // lblWeekTitle
            // 
            this.lblWeekTitle.AutoSize = true;
            this.lblWeekTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblWeekTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.lblWeekTitle.Location = new System.Drawing.Point(16, 18);
            this.lblWeekTitle.Name = "lblWeekTitle";
            this.lblWeekTitle.Size = new System.Drawing.Size(108, 23);
            this.lblWeekTitle.TabIndex = 0;
            this.lblWeekTitle.Text = "Chọn học kỳ:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(263, 46);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Thời Khóa Biểu";
            // 
            // panelContainer
            // 
            this.panelContainer.Controls.Add(this.tblTimetable);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(20, 80);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.panelContainer.Size = new System.Drawing.Size(960, 500);
            this.panelContainer.TabIndex = 1;
            // 
            // tblTimetable
            // 
            this.tblTimetable.BackColor = System.Drawing.Color.White;
            this.tblTimetable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tblTimetable.ColumnCount = 7;

            // --- BUNG VÒNG LẶP COLUMN RA THÀNH TỪNG DÒNG ---
            this.tblTimetable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F)); // Cột Tiết
            this.tblTimetable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F)); // Thứ 2
            this.tblTimetable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F)); // Thứ 3
            this.tblTimetable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F)); // Thứ 4
            this.tblTimetable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F)); // Thứ 5
            this.tblTimetable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F)); // Thứ 6
            this.tblTimetable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F)); // Thứ 7

            this.tblTimetable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblTimetable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.tblTimetable.Location = new System.Drawing.Point(0, 10);
            this.tblTimetable.Name = "tblTimetable";
            this.tblTimetable.RowCount = 6;

            // --- BUNG VÒNG LẶP ROW RA THÀNH TỪNG DÒNG ---
            this.tblTimetable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F)); // Header row
            this.tblTimetable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F)); // Tiết 1
            this.tblTimetable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F)); // Tiết 2
            this.tblTimetable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F)); // Tiết 3
            this.tblTimetable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F)); // Tiết 4
            this.tblTimetable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F)); // Tiết 5

            this.tblTimetable.Size = new System.Drawing.Size(960, 490);
            this.tblTimetable.TabIndex = 0;
            // 
            // UC_HocSinh_TKB
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panelHeader);
            this.Name = "UC_HocSinh_TKB";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Size = new System.Drawing.Size(1000, 600);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelWeekWrapper.ResumeLayout(false);
            this.panelWeekWrapper.PerformLayout();
            this.panelContainer.ResumeLayout(false);
            this.tblTimetable.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}