using System.ComponentModel.DataAnnotations;

namespace USTIT.Services.BasicDataAPI.Models
{
    public class AcademicDegree
    {
        [Key]
        public int Id { get; set; }
        public string AcademicDegreeArb { get; set; }
        public string AcademicDegreeEng { get; set; }
    }
}
