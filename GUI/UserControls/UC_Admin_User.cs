
using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI.UserControls
{
    public partial class UC_Admin_User : UserControl
    {
        public UC_Admin_User()
        {
            InitializeComponent();
            LoadUserData();
        }

        private UserBUS userBUS = new UserBUS();

        private void Add_Click(object sender, EventArgs e)
        {
            AddUser formAdd = new AddUser();
            formAdd.StartPosition = FormStartPosition.CenterParent; // cho form hiện giữa màn hình
          
            if (formAdd.ShowDialog() == DialogResult.OK) // chỉ reload nếu có user mới
            {
                LoadUserData(); // reload GridView
            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void LoadUserData()
        {
            dataGridView1.Rows.Clear();

            List<UserDTO> users = userBUS.GetAllUsers();

            foreach (var user in users)
            {
                dataGridView1.Rows.Add(
                    user.Username,
                    user.Password,
                    user.FullName,
                    user.Email,
                    user.Phone,
                    user.CreatedAt.ToString("yyyy-MM-dd"),
                    user.UserRoles
                );
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // tránh header
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Gán giá trị vào các TextBox/ComboBox
                textBox2.Text = row.Cells["Taikhoan"].Value?.ToString();
                textBox3.Text = row.Cells["MatKhau"].Value?.ToString();
                textBox4.Text = row.Cells["HoTen"].Value?.ToString();
                textBox5.Text = row.Cells["Email"].Value?.ToString();
                textBox6.Text = row.Cells["SDT"].Value?.ToString();
                dateTimePicker1.Value = DateTime.TryParse(row.Cells["NgayTao"].Value?.ToString(), out DateTime dt) ? dt : DateTime.Now;
                comboBox1.Text = row.Cells["Role"].Value?.ToString();
               
            }
        }

        private void combo_chucvu(object sender, EventArgs e)
        {

        }

        private void UC_Admin_User_Load(object sender, EventArgs e)
        {

        }

        private void btn_sua_Click(object sender, EventArgs e) // nút Sửa
        {
            UserDTO user = new UserDTO()
            {
                Username = textBox2.Text,
                Password = textBox3.Text,
                FullName = textBox4.Text,
                Email = textBox5.Text,
                Phone = textBox6.Text,
                UserRoles = comboBox1.Text,
             
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

        private void btn_xoa_Click(object sender, EventArgs e) // nút Xóa
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

    }
}
