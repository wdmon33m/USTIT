using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using USTIT.Services.StudentAPI.Models.Dto;

namespace USTIT.Services.StudentAPI.Models
{
    public class StudentHeader
    {
        public string FullStdID { get; private set;}
        [Required]
        public int AcYear { get; set; }
        [Required]
        public string DeptCode { get; set; }
        [NotMapped]
        public DepartmentDto Department { get; set; }

        public StudentNames StudentNames { get; set; }

        [Required]
        public int StdNo { get; set; }

        public DateTime? CreationDate { get; set; } = DateTime.Now;

        [MaxLength(250)]
        public string? UserID { get; set; } = string.Empty;
    }

}
