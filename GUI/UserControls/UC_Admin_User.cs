using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GUI.UserControls
{
    public partial class UC_Admin_User : UserControl
    {
        private UserBUS userBUS = new UserBUS();
        private int selectedUserId = -1; // Lưu user đang chọn

        private int pageSize = 10;          // số dòng mỗi trang
        private int currentPage = 1;        // trang hiện tại
        private int totalPage = 1;          // tổng số trang
        private List<UserDTO> allUsers;     // toàn bộ dữ liệu nguồn


        public UC_Admin_User()
        {
            InitializeComponent();
        }

        private void UC_Admin_User_Load(object sender, EventArgs e)
        {
            LoadUserData();

        }

        
        private void LoadUserData()
        {
            allUsers = userBUS.GetAllUsers();

            totalPage = (int)Math.Ceiling(allUsers.Count / (double)pageSize);

            currentPage = 1;

            LoadPage(currentPage);
        }
        private void LoadPage(int page)
        {
            dataGridView1.Rows.Clear();

            int start = (page - 1) * pageSize;

            var pageData = allUsers
                .Skip(start)
                .Take(pageSize)
                .ToList();

            foreach (var user in pageData)
            {
                dataGridView1.Rows.Add(
                    user.Username,
                    "*****",
                    user.Fullname,
                    user.Email,
                    user.Phone,
                    user.RoleName,
                    user.CreatedAt != DateTime.MinValue ? user.CreatedAt.ToString("yyyy-MM-dd") : ""
                );
            }

            // hiển thị số trang: vd "1/5"
            txtnumber.Text = $"{currentPage}/{totalPage}";
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


     
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string kw = txtSearch.Text.Trim();

            allUsers = userBUS.SearchUsers(kw);

            totalPage = (int)Math.Ceiling(allUsers.Count / (double)pageSize);

            currentPage = 1;

            LoadPage(currentPage);
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            allUsers = userBUS.SearchUsers(txtSearch.Text.Trim());

            totalPage = (int)Math.Ceiling(allUsers.Count / (double)pageSize);

            currentPage = 1;

            LoadPage(currentPage);
        }


       

        private void btnhead_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadPage(currentPage);
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadPage(currentPage);
            }
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPage)
            {
                currentPage++;
                LoadPage(currentPage);
            }
        }

        private void btntail_Click(object sender, EventArgs e)
        {
            currentPage = totalPage;
            LoadPage(currentPage);
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xlsx;*.xls";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                ImportUsersFromExcel(filePath);
            }
        }
        private void ImportUsersFromExcel(string filePath)
        {
            try
            {
                using (var workbook = new ClosedXML.Excel.XLWorkbook(filePath))
                {
                    var worksheet = workbook.Worksheet(1); // sheet đầu tiên
                    var rows = worksheet.RangeUsed().RowsUsed().Skip(1); // bỏ header

                    List<UserDTO> usersToAdd = new List<UserDTO>();

                    foreach (var row in rows)
                    {
                        UserDTO user = new UserDTO
                        {
                            Username = row.Cell(1).GetString().Trim(),
                            Password = row.Cell(2).GetString().Trim(),
                            Fullname = row.Cell(3).GetString().Trim(),
                            Email = row.Cell(4).GetString().Trim(),
                            Phone = row.Cell(5).GetString().Trim(),
                            RoleName = row.Cell(6).GetString().Trim()
                        };

                        usersToAdd.Add(user);
                    }

                    // Gọi BUS để thêm vào database
                    foreach (var user in usersToAdd)
                    {
                        userBUS.AddUser(user); // đảm bảo hàm AddUser trong BUS có xử lý username trùng
                    }

                    MessageBox.Show("Import thành công!");
                    LoadUserData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi import: " + ex.Message);
            }
        }


        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
