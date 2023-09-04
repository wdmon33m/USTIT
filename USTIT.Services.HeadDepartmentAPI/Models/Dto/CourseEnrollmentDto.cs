using USTIT.Services.BasicDataAPI.Models.Dto;

namespace USTIT.Services.HeadDepartmentAPI.Models.Dto
{
    public class CourseEnrollmentDto
    {
        public int CourseId { get; set; }
        public string CENo { get; set; }
        public string DeptCode { get; set; }
        public string CourseCode { get; set; }
        public int ClassNo { get; set; }
        public int SemNo { get; set; }
        public string TeacherNo { get; set; }
        public TeacherDto? Teacher { get; set; }

        public int AcYear { get; set; }
        public int LectureWeight { get; set; }
        public int TutorialWeight { get; set; }
        public int LabWeight { get; set; }
        public int CourseWeight { get; set; }
        public bool HasTutorial { get; set; }
    }
}
