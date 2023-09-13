using System.ComponentModel.DataAnnotations;

namespace USTIT.Services.HeadDepartmentAPI.Models
{
    public class AbsenceDetails
    {
        public string ANo { get; set; }
        [MaxLength(13),Required]
        public string FullStdId { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string? UserID { get; set; }
    }
}
