using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI.UserControls
{
    public partial class UC_Admin_User : UserControl
    {
        private UserBUS userBUS = new UserBUS();

        public UC_Admin_User()
        {
            InitializeComponent();
            LoadUserData();
        }

        // ==========================
        // Load dữ liệu user lên GridView
        // ==========================
        private void LoadUserData()
        {
            dataGridView1.Rows.Clear();

            List<UserDTO> users = userBUS.GetAllUsers();

            foreach (var user in users)
            {
                dataGridView1.Rows.Add(
                    user.Username,
                    user.Password,
                    user.Fullname,
                    user.Email,
                    user.Phone,
                    user.CreatedAt.ToString("yyyy-MM-dd"),
                    user.RoleName
                );
            }
        }

        // ==========================
        // Khi click vào GridView
        // ==========================
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // tránh header

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            textBox2.Text = row.Cells["Taikhoan"].Value?.ToString();
            textBox3.Text = row.Cells["MatKhau"].Value?.ToString();
            textBox4.Text = row.Cells["HoTen"].Value?.ToString();
            textBox5.Text = row.Cells["Email"].Value?.ToString();
            textBox6.Text = row.Cells["SDT"].Value?.ToString();
            dateTimePicker1.Value = DateTime.TryParse(row.Cells["NgayTao"].Value?.ToString(), out DateTime dt) ? dt : DateTime.Now;
            comboBox1.Text = row.Cells["Role"].Value?.ToString();
        }

        // ==========================
        // Thêm user mới
        // ==========================
        private void Add_Click(object sender, EventArgs e)
        {
            AddUser formAdd = new AddUser
            {
                StartPosition = FormStartPosition.CenterParent
            };

            if (formAdd.ShowDialog() == DialogResult.OK)
            {
                LoadUserData();
            }
        }

        // ==========================
        // Sửa user
        // ==========================
        private void btn_sua_Click(object sender, EventArgs e)
        {
            UserDTO user = new UserDTO
            {
                Username = textBox2.Text,
                Password = textBox3.Text,
                Fullname = textBox4.Text,
                Email = textBox5.Text,
                Phone = textBox6.Text,
                RoleName = comboBox1.Text
            };

            if (userBUS.UpdateUser(user))
            {
                MessageBox.Show("Cập nhật thành công!");
                LoadUserData();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!");
            }
        }

        // ==========================
        // Xóa user
        // ==========================
        private void btn_xoa_Click(object sender, EventArgs e)
        {
            string username = textBox2.Text;

            if (MessageBox.Show($"Bạn có chắc muốn xóa tài khoản {username}?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (userBUS.DeleteUser(username))
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadUserData();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!");
                }
            }
        }

        // ==========================
        // Placeholder cho ComboBox hoặc sự kiện khác nếu cần
        // ==========================
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // xử lý nếu cần
        }

        private void UC_Admin_User_Load(object sender, EventArgs e)
        {
            // khởi tạo nếu cần
        }
    }
}
