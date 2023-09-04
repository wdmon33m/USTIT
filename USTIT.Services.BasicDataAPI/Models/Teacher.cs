using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace USTIT.Services.BasicDataAPI.Models
{
    public class Teacher
    {
        //public string TeacherId { get; set; }
        public string TeacherNo { get; set; }
        [Required]
        [MaxLength(100)]
        public string TeacherName { get; set; }
        [ForeignKey("AcademicDegreeID")]
        public AcademicDegree AcademicDegree { get; set; }
        public int AcademicDegreeID { get; set; }
        public bool IsLecturer { get; set; } = false;
        public bool IsTeacherAssistant { get; set; } = false;
        public bool IsCollaborator { get; set; } = false;
        public DateTime? RegistrationDate { get; set; }
        public bool IsActive { get; set; } = true;
        [MaxLength(500)]
        public string Notes { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
