using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using USTIT.Services.HeadDepartmentAPI.Models.Dto;

namespace USTIT.Services.HeadDepartmentAPI.Models
{
    public class CourseEnrollment
    {
        public string CENo { get; set; }

        public string DeptCode { get; set; }
        [NotMapped]
        public DepartmentDto? Department { get; set; }

        public string CourseCode { get; set; }
        [NotMapped]
        public CourseDto? Course { get; set; }

        public int ClassNo { get; set; }
        [NotMapped]
        public ClassDto? Class { get; set; }

        public int SemNo { get; set; }
        [NotMapped]
        public SemesterDto? Semester { get; set; }

        [MaxLength(15)]
        public string TeacherNo { get; set; }
        [NotMapped]
        public TeacherDto? Teacher { get; set; }
        public int AcYear { get; set; }
        public int LectureWeight { get; set; }
        public int TutorialWeight { get; set; }
        public int LabWeight { get; set; }
        public int? CourseWeight { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;

        [MaxLength(50)]
        public string? UserID { get; set; } = string.Empty;
        public bool HasTutorial { get; set; }
        [MaxLength]
        public string? Notes { get; set; }
    }
}
