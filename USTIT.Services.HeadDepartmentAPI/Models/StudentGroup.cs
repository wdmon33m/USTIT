using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using USTIT.Services.HeadDepartmentAPI.Models.Dto;

namespace USTIT.Services.HeadDepartmentAPI.Models
{
    public class StudentGroup
    {
        [Key]
        public string StdGroupNo { get; set; }
        public string DeptCode { get; set; }
        [NotMapped]
        public DepartmentDto Department { get; set; }

        public int AcYear { get; set; }
        public int ClassNo { get; set; }
        [NotMapped]
        public ClassDto Class { get; set; }

        public int SemNo { get; set; }
        [NotMapped]
        public SemesterDto Semester { get; set; }

        public int StdCount { get; set; }
        public DateTime CreationDate { get; set; }
        public string FromStd { get; set; }
        public string ToStd { get; set; }
        public int GroupNo { get; set; }
    }
}
