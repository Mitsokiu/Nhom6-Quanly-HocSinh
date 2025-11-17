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
            string fullname = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string role = comboRole.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(fullname) || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            UserDTO user = new UserDTO
            {
                Username = username,
                Password = password,
                Fullname = fullname,
                Email = email,
                Phone = phone,
                RoleName = role
            };

            UserBUS bus = new UserBUS();
            bool result = bus.AddUser(user);

            if (result)
            {
                MessageBox.Show("Thêm user thành công.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Lỗi: Không thể thêm user.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
