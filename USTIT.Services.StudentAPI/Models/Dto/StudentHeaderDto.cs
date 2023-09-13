namespace USTIT.Services.StudentAPI.Models.Dto
{
    public class StudentHeaderDto
    {
        public string FullStdID { get; set; }
        public int AcYear { get; set; }
        public string DeptCode { get; set; }
        public DepartmentDto Department { get; set; }
        public StudentNamesDto StudentNames { get; set; }
        public int StdNo { get; set; }
    }
}
