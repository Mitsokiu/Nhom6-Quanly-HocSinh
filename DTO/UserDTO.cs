using System;

namespace DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedAt { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; } // khi join roles để hiển thị
    }
}
