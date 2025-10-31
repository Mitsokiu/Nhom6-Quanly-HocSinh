namespace GUI.UserControls
{
    partial class AddUserForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            labelTitle = new Label();
            labelUsername = new Label();
            labelPassword = new Label();
            labelEmail = new Label();
            labelRole = new Label();
            labelPhone = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            txtEmail = new TextBox();
            txtPhone = new TextBox();
            comboRole = new ComboBox();
            btnSave = new Button();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            labelTitle.ForeColor = Color.DarkSlateGray;
            labelTitle.Location = new Point(120, 20);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(157, 38);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Thêm User";
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.Location = new Point(30, 80);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(90, 25);
            labelUsername.TabIndex = 1;
            labelUsername.Text = "Tài khoản:";
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Location = new Point(30, 130);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(90, 25);
            labelPassword.TabIndex = 3;
            labelPassword.Text = "Mật khẩu:";
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Location = new Point(30, 180);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(58, 25);
            labelEmail.TabIndex = 5;
            labelEmail.Text = "Email:";
            // 
            // labelRole
            // 
            labelRole.AutoSize = true;
            labelRole.Location = new Point(30, 280);
            labelRole.Name = "labelRole";
            labelRole.Size = new Size(109, 25);
            labelRole.TabIndex = 9;
            labelRole.Text = "Phân quyền:";
            // 
            // labelPhone
            // 
            labelPhone.AutoSize = true;
            labelPhone.Location = new Point(30, 230);
            labelPhone.Name = "labelPhone";
            labelPhone.Size = new Size(48, 25);
            labelPhone.TabIndex = 7;
            labelPhone.Text = "SĐT:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(150, 77);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(250, 31);
            txtUsername.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(150, 127);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(250, 31);
            txtPassword.TabIndex = 4;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(150, 177);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(250, 31);
            txtEmail.TabIndex = 6;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(150, 227);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(250, 31);
            txtPhone.TabIndex = 8;
            // 
            // comboRole
            // 
            comboRole.DropDownStyle = ComboBoxStyle.DropDownList;
            comboRole.FormattingEnabled = true;
            comboRole.Items.AddRange(new object[] { "Admin", "Giáo viên", "Học sinh", "Phụ huynh" });
            comboRole.Location = new Point(150, 277);
            comboRole.Name = "comboRole";
            comboRole.Size = new Size(250, 33);
            comboRole.TabIndex = 10;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.MediumSeaGreen;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(300, 338);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 40);
            btnSave.TabIndex = 11;
            btnSave.Text = "Thêm";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // AddUserForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(450, 420);
            Controls.Add(btnSave);
            Controls.Add(comboRole);
            Controls.Add(labelRole);
            Controls.Add(txtPhone);
            Controls.Add(labelPhone);
            Controls.Add(txtEmail);
            Controls.Add(labelEmail);
            Controls.Add(txtPassword);
            Controls.Add(labelPassword);
            Controls.Add(txtUsername);
            Controls.Add(labelUsername);
            Controls.Add(labelTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddUserForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thêm người dùng";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitle;
        private Label labelUsername;
        private Label labelPassword;
        private Label labelEmail;
        private Label labelRole;
        private Label labelPhone;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private TextBox txtEmail;
        private TextBox txtPhone;
        private ComboBox comboRole;
        private Button btnSave;
    }
}
