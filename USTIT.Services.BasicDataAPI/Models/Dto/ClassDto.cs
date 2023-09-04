using System.ComponentModel.DataAnnotations;

namespace USTIT.Services.BasicDataAPI.Models.Dto
{
    public class ClassDto
    {
        public int ClassNo { get; set; }
        [Required]
        [MaxLength(30)]
        public string ClassName { get; set; }
        public string ClassNameArb { get; set; }
    }
}
