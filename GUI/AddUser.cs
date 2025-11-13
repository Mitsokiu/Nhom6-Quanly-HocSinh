using BUS;
using DTO;
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
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string email = txtFullName.Text.Trim();
            string fullname = txtFullName.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string role = comboRole.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UserDTO user = new UserDTO
            {
                Username = username,
                Password = password,
                Email = email,
                FullName = fullname,
                Phone = phone,
                UserRoles = role
            };

            UserBUS bus = new UserBUS();
            bool result = bus.AddUser(user);

            if (result)
            {
                MessageBox.Show($"Đã thêm user: {username}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Thêm user thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
