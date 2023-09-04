namespace USTIT.WEB.Areas.BasicData.Models.Dto
{
    public class TeacherDto
    {
        public string TeacherNo { get; set; }
        public string TeacherName { get; set; }
        public AcademicDegreeDto AcademicDegree { get; set; }
        public int AcademicDegreeID { get; set; }
        public bool IsLecturer { get; set; }
        public bool IsTeacherAssistant { get; set; }
        public bool IsCollaborator { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public bool IsActive { get; set; }
        public string Notes { get; set; }
    }
}
