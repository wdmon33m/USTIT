namespace USTIT.WEB.Areas.BasicData.Models.Dto
{
    public class CourseDto
    {
        public string CourseCode { get; set; }
        public string CourseTitle { get; set; }
        public string? Notes { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreationDate { get; set; }
    }
}
