using System;

namespace DTO
{
    public class HocPhiDTO
    {
        public int Id { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string Lop { get; set; }
        public string KhoanThu { get; set; }
        public decimal SoTien { get; set; }
        public string TrangThai { get; set; }  // Ví dụ: "Đã đóng", "Chưa đóng"
        public DateTime NgayDong { get; set; }
    }
}
