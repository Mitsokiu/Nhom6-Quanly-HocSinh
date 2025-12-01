namespace GUI
{
    partial class SuaThongBao
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlDivider;
        private System.Windows.Forms.Panel pnlEditor;
        private System.Windows.Forms.RichTextBox rtbContent;
        private System.Windows.Forms.Label lblContentHeader;
        private System.Windows.Forms.Panel pnlTitleInput;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblTitleHeader;

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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlDivider = new System.Windows.Forms.Panel();
            this.pnlEditor = new System.Windows.Forms.Panel();
            this.rtbContent = new System.Windows.Forms.RichTextBox();
            this.lblContentHeader = new System.Windows.Forms.Label();
            this.pnlTitleInput = new System.Windows.Forms.Panel();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTitleHeader = new System.Windows.Forms.Label();
            this.pnlCard.SuspendLayout();
            this.pnlEditor.SuspendLayout();
            this.pnlTitleInput.SuspendLayout();
            this.SuspendLayout();

            // lblPageTitle
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            this.lblPageTitle.Location = new System.Drawing.Point(30, 20);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(325, 45);
            this.lblPageTitle.Text = "Cập Nhật Thông Báo";

            // pnlCard
            this.pnlCard.BackColor = System.Drawing.Color.White;
            this.pnlCard.Controls.Add(this.btnSave);
            this.pnlCard.Controls.Add(this.btnCancel);
            this.pnlCard.Controls.Add(this.pnlDivider);
            this.pnlCard.Controls.Add(this.pnlEditor);
            this.pnlCard.Controls.Add(this.lblContentHeader);
            this.pnlCard.Controls.Add(this.pnlTitleInput);
            this.pnlCard.Controls.Add(this.lblTitleHeader);
            this.pnlCard.Location = new System.Drawing.Point(38, 80);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Size = new System.Drawing.Size(900, 500);

            // btnSave
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(13, 110, 253);
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(720, 430);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 40);
            this.btnSave.Text = "Lưu thay đổi";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(600, 430);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // pnlEditor
            this.pnlEditor.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.pnlEditor.Controls.Add(this.rtbContent);
            this.pnlEditor.Location = new System.Drawing.Point(34, 130);
            this.pnlEditor.Name = "pnlEditor";
            this.pnlEditor.Size = new System.Drawing.Size(830, 250);
            this.pnlEditor.Paint += new System.Windows.Forms.PaintEventHandler(this.Control_Paint_Border);

            // rtbContent
            this.rtbContent.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.rtbContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbContent.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rtbContent.Location = new System.Drawing.Point(0, 0);
            this.rtbContent.Name = "rtbContent";
            this.rtbContent.Padding = new System.Windows.Forms.Padding(10);
            this.rtbContent.Size = new System.Drawing.Size(830, 250);
            this.rtbContent.Text = "";

            // pnlTitleInput
            this.pnlTitleInput.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.pnlTitleInput.Controls.Add(this.txtTitle);
            this.pnlTitleInput.Location = new System.Drawing.Point(34, 50);
            this.pnlTitleInput.Name = "pnlTitleInput";
            this.pnlTitleInput.Size = new System.Drawing.Size(830, 40);
            this.pnlTitleInput.Paint += new System.Windows.Forms.PaintEventHandler(this.Control_Paint_Border);

            // txtTitle
            this.txtTitle.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.txtTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtTitle.Location = new System.Drawing.Point(15, 10);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(800, 20);
            this.txtTitle.Enter += new System.EventHandler(this.txtTitle_Enter);
            this.txtTitle.Leave += new System.EventHandler(this.txtTitle_Leave);

            // Labels & Divider
            this.lblContentHeader.AutoSize = true;
            this.lblContentHeader.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblContentHeader.Location = new System.Drawing.Point(30, 100);
            this.lblContentHeader.Text = "Nội dung";

            this.lblTitleHeader.AutoSize = true;
            this.lblTitleHeader.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitleHeader.Location = new System.Drawing.Point(30, 20);
            this.lblTitleHeader.Text = "Tiêu đề thông báo";

            this.pnlDivider.BackColor = System.Drawing.Color.FromArgb(233, 236, 239);
            this.pnlDivider.Location = new System.Drawing.Point(34, 400);
            this.pnlDivider.Size = new System.Drawing.Size(830, 1);

            // Form Settings
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.pnlCard);
            this.Controls.Add(this.lblPageTitle);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cập Nhật Thông Báo";
            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
            this.pnlEditor.ResumeLayout(false);
            this.pnlTitleInput.ResumeLayout(false);
            this.pnlTitleInput.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}