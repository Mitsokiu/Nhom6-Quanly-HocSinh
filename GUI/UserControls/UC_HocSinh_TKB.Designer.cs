using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    partial class ThoiKhoaBieuControl
    {
        private IContainer components = null;

        // Header
        private Panel panelHeader;
        private Label lblTitle;

        // Wrapper chứa cụm chọn tuần
        private Panel panelWeekWrapper;
        private Label lblWeekTitle;
        public ComboBox cboWeek;

        // Main Layout
        private Panel panelContainer;
        private TableLayoutPanel tblTimetable;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelWeekWrapper = new System.Windows.Forms.Panel();
            this.lblWeekTitle = new System.Windows.Forms.Label();
            this.cboWeek = new System.Windows.Forms.ComboBox();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.tblTimetable = new System.Windows.Forms.TableLayoutPanel();

            this.panelHeader.SuspendLayout();
            this.panelWeekWrapper.SuspendLayout();
            this.panelContainer.SuspendLayout();
            this.SuspendLayout();

            // 
            // ThoiKhoaBieuControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Size = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panelHeader);

            // 
            // panelHeader
            // 
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Height = 60;
            this.panelHeader.Controls.Add(this.panelWeekWrapper);
            this.panelHeader.Controls.Add(this.lblTitle);

            // 
            // panelWeekWrapper
            // 
            this.panelWeekWrapper.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelWeekWrapper.Width = 450;
            this.panelWeekWrapper.Controls.Add(this.cboWeek);
            this.panelWeekWrapper.Controls.Add(this.lblWeekTitle);

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            this.lblTitle.Location = new System.Drawing.Point(0, 5);
            this.lblTitle.Text = "Thời Khóa Biểu";

            // 
            // lblWeekTitle
            // 
            this.lblWeekTitle.AutoSize = true;
            this.lblWeekTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblWeekTitle.ForeColor = System.Drawing.Color.FromArgb(73, 80, 87);
            this.lblWeekTitle.Location = new System.Drawing.Point(40, 18);
            this.lblWeekTitle.Text = "Chọn tuần:";

            // 
            // cboWeek
            // 
            this.cboWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWeek.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboWeek.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboWeek.FormattingEnabled = true;
            this.cboWeek.Location = new System.Drawing.Point(125, 15);
            this.cboWeek.Size = new System.Drawing.Size(310, 28);
            this.cboWeek.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            // 
            // panelContainer
            // 
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.panelContainer.Controls.Add(this.tblTimetable);

            // 
            // tblTimetable
            // 
            this.tblTimetable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblTimetable.BackColor = System.Drawing.Color.White;
            this.tblTimetable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tblTimetable.ForeColor = System.Drawing.Color.FromArgb(222, 226, 230);
            this.tblTimetable.ColumnCount = 7;
            this.tblTimetable.RowCount = 6;

            // Clean styles
            this.tblTimetable.ColumnStyles.Clear();
            this.tblTimetable.RowStyles.Clear();

            // Setup Column Styles (Thủ công để tránh lỗi Designer)
            this.tblTimetable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F)); // Cot Tiet
            this.tblTimetable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66F));
            this.tblTimetable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66F));
            this.tblTimetable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66F));
            this.tblTimetable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66F));
            this.tblTimetable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66F));
            this.tblTimetable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66F));

            // Setup Row Styles
            this.tblTimetable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F)); // Header Row
            this.tblTimetable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblTimetable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblTimetable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblTimetable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblTimetable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));

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