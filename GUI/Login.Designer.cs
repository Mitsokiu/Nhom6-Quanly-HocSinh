namespace GUI
{
    partial class Login
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
            this.panelLeft = new System.Windows.Forms.Panel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.linkForgot = new System.Windows.Forms.LinkLabel();
            this.panelPassContainer = new System.Windows.Forms.Panel();
            this.picShowPass = new System.Windows.Forms.PictureBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.picPassIcon = new System.Windows.Forms.PictureBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.panelUserContainer = new System.Windows.Forms.Panel();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.picUserIcon = new System.Windows.Forms.PictureBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.panelRight = new System.Windows.Forms.Panel();
            this.lblBrandSubtitle = new System.Windows.Forms.Label();
            this.lblBrandTitle = new System.Windows.Forms.Label();
            this.picBrandLogo = new System.Windows.Forms.PictureBox();
            this.panelLeft.SuspendLayout();
            this.panelPassContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picShowPass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPassIcon)).BeginInit();
            this.panelUserContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUserIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBrandLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.White;
            this.panelLeft.Controls.Add(this.btnLogin);
            this.panelLeft.Controls.Add(this.linkForgot);
            this.panelLeft.Controls.Add(this.panelPassContainer);
            this.panelLeft.Controls.Add(this.lblPass);
            this.panelLeft.Controls.Add(this.panelUserContainer);
            this.panelLeft.Controls.Add(this.lblUser);
            this.panelLeft.Controls.Add(this.lblSubtitle);
            this.panelLeft.Controls.Add(this.lblTitle);
            this.panelLeft.Controls.Add(this.picLogo);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(733, 738);
            this.panelLeft.TabIndex = 0;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(100, 566);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(533, 62);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // linkForgot
            // 
            this.linkForgot.AutoSize = true;
            this.linkForgot.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkForgot.Location = new System.Drawing.Point(503, 517);
            this.linkForgot.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkForgot.Name = "linkForgot";
            this.linkForgot.Size = new System.Drawing.Size(116, 20);
            this.linkForgot.TabIndex = 3;
            this.linkForgot.TabStop = true;
            this.linkForgot.Text = "Quên mật khẩu?";
            // 
            // panelPassContainer
            // 
            this.panelPassContainer.BackColor = System.Drawing.Color.White;
            this.panelPassContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPassContainer.Controls.Add(this.picShowPass);
            this.panelPassContainer.Controls.Add(this.txtPass);
            this.panelPassContainer.Controls.Add(this.picPassIcon);
            this.panelPassContainer.Location = new System.Drawing.Point(100, 449);
            this.panelPassContainer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelPassContainer.Name = "panelPassContainer";
            this.panelPassContainer.Size = new System.Drawing.Size(533, 55);
            this.panelPassContainer.TabIndex = 1;
            // 
            // picShowPass
            // 
            this.picShowPass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picShowPass.Location = new System.Drawing.Point(487, 12);
            this.picShowPass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picShowPass.Name = "picShowPass";
            this.picShowPass.Size = new System.Drawing.Size(33, 31);
            this.picShowPass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picShowPass.TabIndex = 2;
            this.picShowPass.TabStop = false;
            // 
            // txtPass
            // 
            this.txtPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPass.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.ForeColor = System.Drawing.Color.Gray;
            this.txtPass.Location = new System.Drawing.Point(60, 16);
            this.txtPass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(413, 22);
            this.txtPass.TabIndex = 0;
            this.txtPass.Text = "Nhập mật khẩu của bạn";
            // 
            // picPassIcon
            // 
            this.picPassIcon.Location = new System.Drawing.Point(13, 12);
            this.picPassIcon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picPassIcon.Name = "picPassIcon";
            this.picPassIcon.Size = new System.Drawing.Size(33, 31);
            this.picPassIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPassIcon.TabIndex = 0;
            this.picPassIcon.TabStop = false;
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPass.Location = new System.Drawing.Point(100, 418);
            this.lblPass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(82, 23);
            this.lblPass.TabIndex = 6;
            this.lblPass.Text = "Mật khẩu";
            // 
            // panelUserContainer
            // 
            this.panelUserContainer.BackColor = System.Drawing.Color.White;
            this.panelUserContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelUserContainer.Controls.Add(this.txtUser);
            this.panelUserContainer.Controls.Add(this.picUserIcon);
            this.panelUserContainer.Location = new System.Drawing.Point(100, 338);
            this.panelUserContainer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelUserContainer.Name = "panelUserContainer";
            this.panelUserContainer.Size = new System.Drawing.Size(533, 55);
            this.panelUserContainer.TabIndex = 0;
            // 
            // txtUser
            // 
            this.txtUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUser.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser.ForeColor = System.Drawing.Color.Gray;
            this.txtUser.Location = new System.Drawing.Point(60, 16);
            this.txtUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(460, 22);
            this.txtUser.TabIndex = 0;
            this.txtUser.Text = "Nhập tên đăng nhập của bạn";
            // 
            // picUserIcon
            // 
            this.picUserIcon.Location = new System.Drawing.Point(13, 12);
            this.picUserIcon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picUserIcon.Name = "picUserIcon";
            this.picUserIcon.Size = new System.Drawing.Size(33, 31);
            this.picUserIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picUserIcon.TabIndex = 0;
            this.picUserIcon.TabStop = false;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(100, 308);
            this.lblUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(124, 23);
            this.lblUser.TabIndex = 3;
            this.lblUser.Text = "Tên đăng nhập";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle.ForeColor = System.Drawing.Color.Gray;
            this.lblSubtitle.Location = new System.Drawing.Point(220, 246);
            this.lblSubtitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(332, 23);
            this.lblSubtitle.TabIndex = 2;
            this.lblSubtitle.Text = "Đăng nhập vào hệ thống quản lý học sinh";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(233, 196);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(309, 46);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Chào mừng trở lại";
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(337, 79);
            this.picLogo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(107, 98);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(247)))));
            this.panelRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelRight.Controls.Add(this.lblBrandSubtitle);
            this.panelRight.Controls.Add(this.lblBrandTitle);
            this.panelRight.Controls.Add(this.picBrandLogo);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(733, 0);
            this.panelRight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(600, 738);
            this.panelRight.TabIndex = 1;
            // 
            // lblBrandSubtitle
            // 
            this.lblBrandSubtitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblBrandSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblBrandSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrandSubtitle.ForeColor = System.Drawing.Color.Black;
            this.lblBrandSubtitle.Location = new System.Drawing.Point(67, 455);
            this.lblBrandSubtitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBrandSubtitle.Name = "lblBrandSubtitle";
            this.lblBrandSubtitle.Size = new System.Drawing.Size(467, 74);
            this.lblBrandSubtitle.TabIndex = 2;
            this.lblBrandSubtitle.Text = "Hệ thống toàn diện giúp theo dõi và phát triển \r\ntiềm năng của mỗi học sinh.";
            this.lblBrandSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBrandTitle
            // 
            this.lblBrandTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblBrandTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblBrandTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrandTitle.ForeColor = System.Drawing.Color.Black;
            this.lblBrandTitle.Location = new System.Drawing.Point(67, 394);
            this.lblBrandTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBrandTitle.Name = "lblBrandTitle";
            this.lblBrandTitle.Size = new System.Drawing.Size(467, 49);
            this.lblBrandTitle.TabIndex = 1;
            this.lblBrandTitle.Text = "Nâng cao hiệu quả quản lý";
            this.lblBrandTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picBrandLogo
            // 
            this.picBrandLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picBrandLogo.BackColor = System.Drawing.Color.Transparent;
            this.picBrandLogo.Location = new System.Drawing.Point(233, 246);
            this.picBrandLogo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picBrandLogo.Name = "picBrandLogo";
            this.picBrandLogo.Size = new System.Drawing.Size(133, 123);
            this.picBrandLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBrandLogo.TabIndex = 0;
            this.picBrandLogo.TabStop = false;
            // 
            // Login
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 738);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.panelPassContainer.ResumeLayout(false);
            this.panelPassContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picShowPass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPassIcon)).EndInit();
            this.panelUserContainer.ResumeLayout(false);
            this.panelUserContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUserIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.panelRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBrandLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Panel panelUserContainer;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.PictureBox picUserIcon;
        private System.Windows.Forms.Panel panelPassContainer;
        private System.Windows.Forms.PictureBox picShowPass;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.PictureBox picPassIcon;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.LinkLabel linkForgot;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.PictureBox picBrandLogo;
        private System.Windows.Forms.Label lblBrandTitle;
        private System.Windows.Forms.Label lblBrandSubtitle;
    }
}