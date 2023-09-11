using System.ComponentModel.DataAnnotations;

namespace USTIT.Services.StudentAPI.Models
{
    public class Religion
    {
        [Key]
        public int ReligionId { get; set; }
        [Required]
        public string ReligionNameAr { get; set; }
        [Required]
        public string ReligionNameEn { get; set; }
    }
}
