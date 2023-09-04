using System.ComponentModel.DataAnnotations;

namespace USTIT.Services.BasicDataAPI.Models.Dto
{
    public class DepartmentDto
    {
        public string DeptCode { get; set; }
        [Required]
        [MaxLength(30)]
        public string DeptName { get; set; }
        public string DeptNameArb { get; set; }
        [Required]
        public int SemCount { get; set; }
    }
}
