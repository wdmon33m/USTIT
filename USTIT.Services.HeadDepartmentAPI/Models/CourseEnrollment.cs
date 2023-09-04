using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using USTIT.Services.BasicDataAPI.Models.Dto;
using USTIT.Services.HeadDepartmentAPI.Models.Dto;

namespace USTIT.Services.HeadDepartmentAPI.Models
{
    public class CourseEnrollment
    {
        [Key]
        public int CEId { get; set; }

        [Required]
        [MaxLength(250)]
        public string CENo { get; set; }

        [Required]
        public string DeptCode { get; set; }
        [NotMapped]
        public DepartmentDto Department { get; set; }


        [Required]
        public string CourseCode { get; set; }
        [NotMapped]
        public CourseDto Course { get; set; }


        [Required]
        public int ClassNo { get; set; }
        [NotMapped]
        public ClassDto Class { get; set; }


        [Required]
        public int SemNo { get; set; }
        [NotMapped]
        public SemesterDto Semester { get; set; }

        [MaxLength(15)]
        [Required]
        public string TeacherNo { get; set; }
        [NotMapped]
        public TeacherDto Teacher { get; set; }

        [Required]
        public int AcYear { get; set; }

        [Required]
        public int LectureWeight { get; set; }

        [Required]
        public int TutorialWeight { get; set; }

        [Required]
        public int LabWeight { get; set; }

        public int? CourseWeight { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;

        [Required]
        [MaxLength(50)]
        public string UserID { get; set; } = string.Empty;

        [Required]
        public bool HasTutorial { get; set; }
    }

}
