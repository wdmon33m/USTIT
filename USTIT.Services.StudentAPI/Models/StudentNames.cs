using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace USTIT.Services.StudentAPI.Models
{
    public class StudentNames
    {
        public string FullStdID { get; set; }
        [ForeignKey("FullStdID")]
        public Student Student { get; set; }
        public string? ArFirstName { get; set; }
        public string? ArSecondName { get; set; }
        public string? ArThirdName { get; set; }
        public string? ArFourthName { get; set; }
        public string? ArFullName { get; set; }
        public string? EnFirstName { get; set; }
        public string? EnSecondName { get; set; }
        public string? EnThirdName { get; set; }
        public string? EnFourthName { get; set; }
        public string? EnFullName { get; set; }
    }
}
