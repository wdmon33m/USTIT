using System.ComponentModel.DataAnnotations;

namespace USTIT.Services.StudentAPI.Models
{
    public class Nationality
    {
        [Key]
        public int NationalityId { get; set; }
        public string CountryCode { get; set; }
        public string NationalityAr { get; set; }
        public string NationalityEn { get; set; }
    }
}
