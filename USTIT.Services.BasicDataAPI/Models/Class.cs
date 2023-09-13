using System.ComponentModel.DataAnnotations;

namespace USTIT.Services.BasicDataAPI.Models
{
    public class Class
    {
        public int ClassNo { get; set; }
        [Required]
        [MaxLength(30)]
        public string ClassNameEng { get; set; }
        public string ClassNameArb { get; set; }
    }
}
