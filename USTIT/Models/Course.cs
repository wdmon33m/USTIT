using System.ComponentModel.DataAnnotations;

namespace USTIT.Services.BasicDataAPI.Models
{
    public class Course
    {
        [Key]
        public string CourseCode { get; set; }
        [Required]
        [MaxLength(50)]
        public string CourseTitle { get; set; }
        public string? Notes { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
