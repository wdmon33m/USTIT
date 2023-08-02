using System.ComponentModel.DataAnnotations;

namespace USTITAPI.Models.BasicData.Dto
{
    public class CourseDto
    {
        public string CourseCode { get; set; }
        [Required]
        [MaxLength(30)]
        public string CourseTitle { get; set; }
        public string Notes { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
