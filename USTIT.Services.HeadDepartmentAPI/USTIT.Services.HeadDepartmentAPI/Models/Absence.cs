using System;
using System.ComponentModel.DataAnnotations;

namespace USTIT.Services.HeadDepartmentAPI.Models
{
    public class Absence
    {
        [Key]
        public int AbsenceId { get; set; } // Primary key
        [MaxLength(500)]
        public string ANo { get; set; } // Computed column

        public DateTime ADate { get; set; }
        public string CENo { get; set; }
        public string StdGroupNo { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string? UserID { get; set; }
    }
}
