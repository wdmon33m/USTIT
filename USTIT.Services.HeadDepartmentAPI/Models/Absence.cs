using System;
using System.ComponentModel.DataAnnotations;

namespace USTIT.Services.HeadDepartmentAPI.Models
{
    public class Absence
    {
        public string ANo { get; set; }

        public DateTime ADate { get; set; }
        public string CENo { get; set; }
        public string StdGroupNo { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string? UserID { get; set; }
    }
}
