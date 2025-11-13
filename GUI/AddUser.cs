using BUS;
using DAO;
using DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace GUI
{
    public partial class AddUser : Form
    {
        private UserBUS userBUS = new UserBUS();

        public AddUser()
        {
            InitializeComponent();
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            LoadRolesToComboBox();
        }

        private void LoadRolesToComboBox()
        {
            try
            {
                // Lấy danh sách role từ DB để load vào comboBox
                using (var conn = DbConnect.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT role_id, role_name FROM roles";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        Dictionary<int, string> roleMap = new Dictionary<int, string>();

                        while (reader.Read())
                        {
                            roleMap.Add(reader.GetInt32("role_id"), reader.GetString("role_name"));
                        }

                        comboRole.DataSource = new BindingSource(roleMap, null);
                        comboRole.DisplayMember = "Value";
                        comboRole.ValueMember = "Key";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách quyền: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string email = txtEmail.Text.Trim();
            string fullname = txtFullName.Text.Trim();
            string phone = txtPhone.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin bắt buộc!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboRole.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn quyền người dùng!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int roleId = ((KeyValuePair<int, string>)comboRole.SelectedItem).Key;

            UserDTO user = new UserDTO
            {
                Username = username,
                Password = password, // Sau này nên mã hóa
                Email = email,
                Fullname = fullname,
                Phone = phone,
                RoleId = roleId
            };

            bool result = userBUS.AddUser(user);

            if (result)
            {
                MessageBox.Show($"Đã thêm user: {username}", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Thêm user thất bại!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
