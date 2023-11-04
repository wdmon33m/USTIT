using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace USTIT.Services.HeadDepartmentAPI.Models
{
    public class LectureSchedule
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Hall")]
        public int HallNo { get; set; }
        [Display(Name = "Time")]
        public int LectureTimeId { get; set; }
        [ForeignKey(nameof(LectureTimeId))]
        public LectureTime LectureTime { get; set; }
        [MaxLength(50)]
        public string CENo { get; set; }
        [ForeignKey(nameof(CENo))]
        public CourseEnrollment CourseEnrollment { get; set; }
        public string StdGroupNo { get; set; }
        [ForeignKey(nameof(StdGroupNo))]
        public StudentGroup StudentGroup { get; set; }

        public int DayOfWeek { get; set; }
    }
}
