namespace GUI
{
    partial class ThemThongBao
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Label lblTitleHeader;
        private System.Windows.Forms.Panel pnlTitleInput;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblContentHeader;
        private System.Windows.Forms.Panel pnlEditor;
        private System.Windows.Forms.RichTextBox rtbContent;
        private System.Windows.Forms.Panel pnlDivider;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSubmit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.pnlCard = new System.Windows.Forms.Panel();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlDivider = new System.Windows.Forms.Panel();
            this.pnlEditor = new System.Windows.Forms.Panel();
            this.rtbContent = new System.Windows.Forms.RichTextBox();
            this.lblContentHeader = new System.Windows.Forms.Label();
            this.pnlTitleInput = new System.Windows.Forms.Panel();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTitleHeader = new System.Windows.Forms.Label();
            this.pnlCard.SuspendLayout();
            this.pnlTitleInput.SuspendLayout();
            this.pnlEditor.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblPageTitle.Location = new System.Drawing.Point(30, 20);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(295, 45);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "Tạo Thông Báo Mới";
            // 
            // pnlCard
            // 
            this.pnlCard.BackColor = System.Drawing.Color.White;
            this.pnlCard.Controls.Add(this.btnSubmit);
            this.pnlCard.Controls.Add(this.btnCancel);
            this.pnlCard.Controls.Add(this.pnlDivider);
            this.pnlCard.Controls.Add(this.pnlEditor);
            this.pnlCard.Controls.Add(this.lblContentHeader);
            this.pnlCard.Controls.Add(this.pnlTitleInput);
            this.pnlCard.Controls.Add(this.lblTitleHeader);
            this.pnlCard.Location = new System.Drawing.Point(38, 80);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Size = new System.Drawing.Size(900, 500);
            this.pnlCard.TabIndex = 1;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(720, 430);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(150, 40);
            this.btnSubmit.TabIndex = 9;
            this.btnSubmit.Text = "Tạo";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(600, 430);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlDivider
            // 
            this.pnlDivider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.pnlDivider.Location = new System.Drawing.Point(34, 400);
            this.pnlDivider.Name = "pnlDivider";
            this.pnlDivider.Size = new System.Drawing.Size(830, 1);
            this.pnlDivider.TabIndex = 7;
            // 
            // pnlEditor
            // 
            this.pnlEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlEditor.Controls.Add(this.rtbContent);
            this.pnlEditor.Location = new System.Drawing.Point(34, 130);
            this.pnlEditor.Name = "pnlEditor";
            this.pnlEditor.Size = new System.Drawing.Size(830, 250);
            this.pnlEditor.TabIndex = 6;
            this.pnlEditor.Paint += new System.Windows.Forms.PaintEventHandler(this.Control_Paint_Border);
            // 
            // rtbContent
            // 
            this.rtbContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.rtbContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbContent.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rtbContent.Location = new System.Drawing.Point(0, 0);
            this.rtbContent.Name = "rtbContent";
            this.rtbContent.Padding = new System.Windows.Forms.Padding(10);
            this.rtbContent.Size = new System.Drawing.Size(830, 250);
            this.rtbContent.TabIndex = 1;
            this.rtbContent.Text = "";
            // 
            // lblContentHeader
            // 
            this.lblContentHeader.AutoSize = true;
            this.lblContentHeader.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblContentHeader.Location = new System.Drawing.Point(30, 100);
            this.lblContentHeader.Name = "lblContentHeader";
            this.lblContentHeader.Size = new System.Drawing.Size(73, 20);
            this.lblContentHeader.TabIndex = 5;
            this.lblContentHeader.Text = "Nội dung";
            // 
            // pnlTitleInput
            // 
            this.pnlTitleInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlTitleInput.Controls.Add(this.txtTitle);
            this.pnlTitleInput.Location = new System.Drawing.Point(34, 50);
            this.pnlTitleInput.Name = "pnlTitleInput";
            this.pnlTitleInput.Size = new System.Drawing.Size(830, 40);
            this.pnlTitleInput.TabIndex = 1;
            this.pnlTitleInput.Paint += new System.Windows.Forms.PaintEventHandler(this.Control_Paint_Border);
            // 
            // txtTitle
            // 
            this.txtTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.txtTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtTitle.ForeColor = System.Drawing.Color.Gray;
            this.txtTitle.Location = new System.Drawing.Point(15, 10);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(800, 20);
            this.txtTitle.TabIndex = 0;
            this.txtTitle.Text = "Nhập tiêu đề...";
            this.txtTitle.Enter += new System.EventHandler(this.txtTitle_Enter);
            this.txtTitle.Leave += new System.EventHandler(this.txtTitle_Leave);
            // 
            // lblTitleHeader
            // 
            this.lblTitleHeader.AutoSize = true;
            this.lblTitleHeader.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitleHeader.Location = new System.Drawing.Point(30, 20);
            this.lblTitleHeader.Name = "lblTitleHeader";
            this.lblTitleHeader.Size = new System.Drawing.Size(142, 20);
            this.lblTitleHeader.TabIndex = 0;
            this.lblTitleHeader.Text = "Tiêu đề thông báo";
            // 
            // ThemThongBao
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.pnlCard);
            this.Controls.Add(this.lblPageTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ThemThongBao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tạo Thông Báo";
            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
            this.pnlTitleInput.ResumeLayout(false);
            this.pnlTitleInput.PerformLayout();
            this.pnlEditor.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}