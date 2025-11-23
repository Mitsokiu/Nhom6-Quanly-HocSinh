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

        
    }
}
