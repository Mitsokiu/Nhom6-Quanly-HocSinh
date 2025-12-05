namespace GUI
{
    partial class XetHanhKiem
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblTitleConduct = new System.Windows.Forms.Label();
            this.cbbConduct = new System.Windows.Forms.ComboBox();
            this.lblTitleComment = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.lblName.Location = new System.Drawing.Point(20, 20);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(115, 30);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Họ và Tên";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblInfo.ForeColor = System.Drawing.Color.Gray;
            this.lblInfo.Location = new System.Drawing.Point(25, 55);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(50, 19);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "Mã số:";
            // 
            // lblTitleConduct
            // 
            this.lblTitleConduct.AutoSize = true;
            this.lblTitleConduct.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTitleConduct.Location = new System.Drawing.Point(25, 90);
            this.lblTitleConduct.Name = "lblTitleConduct";
            this.lblTitleConduct.Size = new System.Drawing.Size(85, 19);
            this.lblTitleConduct.TabIndex = 2;
            this.lblTitleConduct.Text = "Hạnh kiểm:";
            // 
            // cbbConduct
            // 
            this.cbbConduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.cbbConduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbConduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbbConduct.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cbbConduct.FormattingEnabled = true;
            this.cbbConduct.Items.AddRange(new object[] {
            "Tốt",
            "Khá",
            "Trung Bình",
            "Yếu"});
            this.cbbConduct.Location = new System.Drawing.Point(25, 115);
            this.cbbConduct.Name = "cbbConduct";
            this.cbbConduct.Size = new System.Drawing.Size(430, 28);
            this.cbbConduct.TabIndex = 3;
            // 
            // lblTitleComment
            // 
            this.lblTitleComment.AutoSize = true;
            this.lblTitleComment.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTitleComment.Location = new System.Drawing.Point(25, 160);
            this.lblTitleComment.Name = "lblTitleComment";
            this.lblTitleComment.Size = new System.Drawing.Size(166, 19);
            this.lblTitleComment.TabIndex = 4;
            this.lblTitleComment.Text = "Nhận xét của giáo viên:";
            // 
            // txtComment
            // 
            this.txtComment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtComment.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtComment.Location = new System.Drawing.Point(25, 185);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtComment.Size = new System.Drawing.Size(430, 150);
            this.txtComment.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(315, 370);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(140, 40);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Lưu đánh giá";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(25, 370);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(140, 40);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // XetHanhKiem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 480);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.lblTitleComment);
            this.Controls.Add(this.cbbConduct);
            this.Controls.Add(this.lblTitleConduct);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "XetHanhKiem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Xét Hạnh Kiểm Chi Tiết";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        // Khai báo biến (Public hoặc Private tùy chỉnh)
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblTitleConduct;
        private System.Windows.Forms.ComboBox cbbConduct;
        private System.Windows.Forms.Label lblTitleComment;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}