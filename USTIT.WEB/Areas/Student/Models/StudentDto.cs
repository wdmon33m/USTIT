using USTIT.WEB.Areas.BasicData.Models.Dto;

namespace USTIT.WEB.Areas.Student.Models
{
    public class StudentDto
    {
        public string FullStdID { get; private set;}
        public int AcYear { get; set; }
        public string DeptCode { get; set; }
        public DepartmentDto Department { get; set; }
        public StudentNamesDto StudentNames { get; set; }
        public int StdNo { get; set; }
    }
}
