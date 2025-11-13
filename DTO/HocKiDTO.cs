using System;

namespace DTO
{
    public class HocKiDTO
    {
        public int Id { get; set; }
        public string NamHoc { get; set; }      // Ví dụ: "2025-2026"
        public string HocKi { get; set; }       // Ví dụ: "Học kì 1"
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public string TrangThai { get; set; }   // Ví dụ: "Đang học", "Đã kết thúc"
    }
}
