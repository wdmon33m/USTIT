namespace USTIT.Services.HeadDepartmentAPI.Models.Dto
{
    public class StudentGroupDto
    {
        public string StdGroupNo { get; set; }
        public string DeptCode { get; set; }
        public DepartmentDto Department { get; set; }

        public int AcYear { get; set; }
        public int ClassNo { get; set; }
        public ClassDto Class { get; set; }

        public int SemNo { get; set; }
        public SemesterDto Semester { get; set; }

        public int StdCount { get; set; }
        public DateTime CreationDate { get; set; }
        public string FromStd { get; set; }
        public string ToStd { get; set; }
        public int GroupNo { get; set; }
    }
}
