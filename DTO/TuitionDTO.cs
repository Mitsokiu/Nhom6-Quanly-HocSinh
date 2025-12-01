using System;

namespace DTO
{
    public class TuitionDTO
    {
        public int TuitionId { get; set; }
        public int StudentId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; } // "unpaid" / "paid"

        public string OldDescription { get; set; }
        public decimal OldAmount { get; set; }
        public DateTime OldDueDate { get; set; }

        public string StudentName { get; set; }
        public string ClassName { get; set; }
        public DateTime DOB { get; set; }
        public DateTime? PaidDate { get; set; }

        public string name { get; set; }

        public int TuitionID { get; set; }
        public string FeeName { get; set; }
       

        //Properties phụ để hiển thị lên DataGridView
        public string StatusDisplay => (Status == "Paid") ? "Đã thanh toán" : "Chưa thanh toán";
        public string AmountDisplay => string.Format("{0:N0} VNĐ", Amount);

    }
}
