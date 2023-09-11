using USTIT.Services.StudentAPI.Models.Dto;

namespace USTIT.Services.StudentAPI.Models.Dto
{
    public class StudentDto
    {
        public string FullStdID { get; set; }
        public int AcYear { get; set; }
        public string DeptCode { get; set; }
        public DepartmentDto Department { get; set; }
        public int StdNo { get; set; }
    }
}
