using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TuitionDTO
    {
        public int TuitionID { get; set; }
        public string FeeName { get; set; }
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }

        //Properties phụ để hiển thị lên DataGridView
        public string StatusDisplay => (Status == "Paid") ? "Đã thanh toán" : "Chưa thanh toán";
        public string AmountDisplay => string.Format("{0:N0} VNĐ", Amount);
    }
}
