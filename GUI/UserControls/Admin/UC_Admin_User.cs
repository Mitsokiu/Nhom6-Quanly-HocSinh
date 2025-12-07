using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DTO;
using BUS;

namespace GUI.UserControls
{
    public partial class UC_Admin_User : UserControl
    {
        private UserBUS userBUS = new UserBUS();
        private int selectedUserId = -1; // Lưu user đang chọn

        public UC_Admin_User()
        {
            InitializeComponent();
        }

        private void UC_Admin_User_Load(object sender, EventArgs e)
        {
            LoadUserData();
        }

        // =========================
        // Load dữ liệu lên DataGridView
        // =========================
        private void LoadUserData()
        {
            dataGridView1.Rows.Clear();
            List<UserDTO> users = userBUS.GetAllUsers();

            foreach (var user in users)
            {
                dataGridView1.Rows.Add(
                    user.Username,
                    "*****", // Ẩn mật khẩu
                    user.Fullname,
                    user.Email,
                    user.Phone,
                    user.RoleName,
                    user.CreatedAt != DateTime.MinValue ? user.CreatedAt.ToString("yyyy-MM-dd") : ""
                );
            }
        }

        // =========================
        // Click vào DataGridView hiển thị bên trái
        // =========================
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                Text_tk.Text = row.Cells["Taikhoan"].Value?.ToString();
                Text_mk.Text = ""; // không hiển thị mật khẩu
                Text_ht.Text = row.Cells["HoTen"].Value?.ToString();
                Text_mail.Text = row.Cells["Email"].Value?.ToString();
                Text_sdt.Text = row.Cells["SDT"].Value?.ToString();
                combo_role.Text = row.Cells["Role"].Value?.ToString();

                // Lưu userId nếu muốn update/delete, giả sử username là unique
                var user = userBUS.GetUserInfo(Text_tk.Text.Trim());
                selectedUserId = user != null ? user.UserId : -1;
            }
        }

        // =========================
        // Nút Thêm
        // =========================
        private void Add_Click(object sender, EventArgs e)
        {
            AddUser addForm = new AddUser();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadUserData();
                ClearForm();
            }
        }
        // =========================
        // Nút Sửa
        // =========================
        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (selectedUserId == -1)
            {
                MessageBox.Show("Vui lòng chọn user để sửa.");
                return;
            }

            UserDTO user = new UserDTO
            {
                UserId = selectedUserId,
                Username = Text_tk.Text.Trim(),
                Password = Text_mk.Text.Trim(), // nếu để trống thì không đổi mật khẩu
                Fullname = Text_ht.Text.Trim(),
                Email = Text_mail.Text.Trim(),
                Phone = Text_sdt.Text.Trim(),
                RoleName = combo_role.Text.Trim()
            };

            bool result = userBUS.UpdateUser(user);
            if (result)
            {
                MessageBox.Show("Cập nhật thành công!");
                LoadUserData();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại.");
            }
        }

        // =========================
        // Nút Xóa
        // =========================
        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (selectedUserId == -1)
            {
                MessageBox.Show("Vui lòng chọn user để xóa.");
                return;
            }

            var confirm = MessageBox.Show("Bạn có chắc muốn xóa user này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                bool result = userBUS.DeleteUser(selectedUserId);
                if (result)
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadUserData();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!");
                }
            }
        }

        // =========================
        // Xóa thông tin bên trái
        // =========================
        private void ClearForm()
        {
            selectedUserId = -1;
            Text_tk.Text = "";
            Text_mk.Text = "";
            Text_ht.Text = "";
            Text_mail.Text = "";
            Text_sdt.Text = "";
            combo_role.SelectedIndex = -1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadGrid(userBUS.SearchUsers(txtSearch.Text.Trim()));
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string kw = txtSearch.Text.Trim();
            LoadGrid(userBUS.SearchUsers(kw));
        }

        private void LoadGrid(List<UserDTO> users)
        {
            dataGridView1.Rows.Clear();

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



    }
}
