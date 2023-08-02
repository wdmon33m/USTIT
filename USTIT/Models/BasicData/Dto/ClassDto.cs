using System.ComponentModel.DataAnnotations;

namespace USTITAPI.Models.BasicData.Dto
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
