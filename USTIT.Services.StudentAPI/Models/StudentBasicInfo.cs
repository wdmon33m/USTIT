using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace USTIT.Services.StudentAPI.Models
{
    public class StudentBasicInfo
    {
        public string FullStdID { get; set; }
        public int Batch { get; set; }
        public int Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? NationalityNo { get; set; }
        
        public int? NationalityId { get; set; }
        [ForeignKey("NationalityId")]
        public Nationality Nationality { get; set; }

        public int? ReligionId { get; set; }
        [ForeignKey("ReligionId")]
        public Religion Religion { get; set; }
        
    }
}
