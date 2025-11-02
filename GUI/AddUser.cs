using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string email = txtEmail.Text;
            string role = comboRole.Text;
            string phone = txtPhone.Text;

            // Kiểm tra đơn giản
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // TODO: thêm xử lý lưu vào DB hoặc danh sách người dùng
            MessageBox.Show($"Đã thêm user:\nTên: {username}\nEmail: {email}\nRole: {role}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }




    }
}
