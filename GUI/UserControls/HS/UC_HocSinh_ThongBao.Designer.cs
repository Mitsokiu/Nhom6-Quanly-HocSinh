namespace GUI.UserControls
{
    partial class UC_HocSinh_ThongBao
    {
        private System.ComponentModel.IContainer components = null;

        // Header
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cboFilter; // ComboBox lọc

        // Body
        private System.Windows.Forms.FlowLayoutPanel flowPanelNotifications;

        // Footer (Phân trang)
        private System.Windows.Forms.Panel panelPagination;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPage1;
        private System.Windows.Forms.Button btnPage2;
        private System.Windows.Forms.Label lblDots;

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
            this.cboFilter = new System.Windows.Forms.ComboBox();
            this.flowPanelNotifications = new System.Windows.Forms.FlowLayoutPanel();
            this.panelPagination = new System.Windows.Forms.Panel();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnPage1 = new System.Windows.Forms.Button();
            this.btnPage2 = new System.Windows.Forms.Button();
            this.lblDots = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelPagination.SuspendLayout();
            this.SuspendLayout();

            // 
            // UC_HocSinh_ThongBao
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.flowPanelNotifications);
            this.Controls.Add(this.panelPagination);
            this.Controls.Add(this.panelHeader);
            this.Padding = new System.Windows.Forms.Padding(30);
            this.Size = new System.Drawing.Size(1100, 700);

            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.Transparent;
            this.panelHeader.Controls.Add(this.cboFilter); // Add ComboBox
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Height = 60;
            this.panelHeader.Location = new System.Drawing.Point(30, 30);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1040, 60);
            this.panelHeader.TabIndex = 0;

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(184, 45);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Thông báo";

            // 
            // cboFilter (ComboBox lọc)
            // 
            this.cboFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilter.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboFilter.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboFilter.FormattingEnabled = true;
            this.cboFilter.Location = new System.Drawing.Point(840, 15);
            this.cboFilter.Name = "cboFilter";
            this.cboFilter.Size = new System.Drawing.Size(200, 25);
            this.cboFilter.TabIndex = 1;

            // 
            // flowPanelNotifications
            // 
            this.flowPanelNotifications.AutoScroll = true;
            this.flowPanelNotifications.BackColor = System.Drawing.Color.Transparent;
            this.flowPanelNotifications.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanelNotifications.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowPanelNotifications.Location = new System.Drawing.Point(30, 90);
            this.flowPanelNotifications.Name = "flowPanelNotifications";
            this.flowPanelNotifications.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.flowPanelNotifications.Size = new System.Drawing.Size(1040, 520);
            this.flowPanelNotifications.TabIndex = 1;
            this.flowPanelNotifications.WrapContents = false;

            // 
            // panelPagination
            // 
            this.panelPagination.BackColor = System.Drawing.Color.Transparent;
            this.panelPagination.Controls.Add(this.btnNext);
            this.panelPagination.Controls.Add(this.lblDots);
            this.panelPagination.Controls.Add(this.btnPage2);
            this.panelPagination.Controls.Add(this.btnPage1);
            this.panelPagination.Controls.Add(this.btnPrev);
            this.panelPagination.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelPagination.Location = new System.Drawing.Point(30, 610);
            this.panelPagination.Name = "panelPagination";
            this.panelPagination.Size = new System.Drawing.Size(1040, 60);
            this.panelPagination.TabIndex = 2;

            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(350, 10);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(40, 40);
            this.btnPrev.TabIndex = 0;
            this.btnPrev.Text = "<";

            // 
            // btnPage1
            // 
            this.btnPage1.Location = new System.Drawing.Point(400, 10);
            this.btnPage1.Name = "btnPage1";
            this.btnPage1.Size = new System.Drawing.Size(40, 40);
            this.btnPage1.TabIndex = 1;
            this.btnPage1.Text = "1";

            // 
            // btnPage2
            // 
            this.btnPage2.Location = new System.Drawing.Point(450, 10);
            this.btnPage2.Name = "btnPage2";
            this.btnPage2.Size = new System.Drawing.Size(40, 40);
            this.btnPage2.TabIndex = 2;
            this.btnPage2.Text = "2";

            // 
            // lblDots
            // 
            this.lblDots.AutoSize = true;
            this.lblDots.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblDots.Location = new System.Drawing.Point(500, 15);
            this.lblDots.Name = "lblDots";
            this.lblDots.Size = new System.Drawing.Size(22, 21);
            this.lblDots.TabIndex = 3;
            this.lblDots.Text = "...";

            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(530, 10);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(40, 40);
            this.btnNext.TabIndex = 4;
            this.btnNext.Text = ">";

            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelPagination.ResumeLayout(false);
            this.panelPagination.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
    }
}