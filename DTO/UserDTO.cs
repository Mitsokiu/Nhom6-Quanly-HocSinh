using System;

namespace DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }             // ID người dùng
        public string Username { get; set; }        // Tên đăng nhập
        public string Password { get; set; }        // Mật khẩu
        public string Fullname { get; set; }        // Họ tên đầy đủ
        public string Email { get; set; }           // Email
        public string Phone { get; set; }           // Số điện thoại
        public DateTime CreatedAt { get; set; }     // Ngày tạo
        public string RoleName { get; set; }        // Tên vai trò (admin/teacher/student/parent)

        // Optional: Hàm trim dữ liệu (nếu muốn)
        public void TrimAll()
        {
            Username = Username?.Trim();
            Password = Password?.Trim();
            Fullname = Fullname?.Trim();
            Email = Email?.Trim();
            Phone = Phone?.Trim();
            RoleName = RoleName?.Trim();
        }
    }
}
