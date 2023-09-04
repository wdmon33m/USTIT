using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace USTIT.Services.BasicDataAPI.Models
{
    public class CourseEnrollment
    {
        [Required]
        [MaxLength(50)]
        public string CENo { get; set; }

        [Required]
        [MaxLength(50)]
        public string DeptCode { get; set; }

        [Required]
        [MaxLength(50)]
        public string CourseCode { get; set; }

        [Required]
        public int ClassNo { get; set; }

        [Required]
        public int SemNo { get; set; }

        [MaxLength(15)]
        [Required]
        public string TeacherNo { get; set; }
        [ForeignKey("TeacherNo")]
        public Teacher Teacher { get; set; }

        [Required]
        public int AcYear { get; set; }

        [Required]
        public int LectureWeight { get; set; }

        [Required]
        public int TutorialWeight { get; set; }

        [Required]
        public int LabWeight { get; set; }

        public int? CourseWeight { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserID { get; set; }

        [Required]
        public bool HasTutorial { get; set; }
    }

}
