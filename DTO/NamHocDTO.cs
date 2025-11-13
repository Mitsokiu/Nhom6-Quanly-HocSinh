using System;

namespace DTO
{
    public class NamHocDTO
    {
        public int Id { get; set; }
        public string NamHoc { get; set; }      // Ví dụ: "2025-2026"
        public string HocKi { get; set; }       // Ví dụ: "Học kì 1"
        public string TKB { get; set; }         // Lưu trữ thông tin thời khóa biểu (chuỗi hoặc JSON)
        public decimal HocPhi { get; set; }     // Học phí của năm học
    }
}
