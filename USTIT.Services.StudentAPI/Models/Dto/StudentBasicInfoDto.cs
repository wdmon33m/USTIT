namespace USTIT.Services.StudentAPI.Models.Dto
{
    public class StudentBasicInfoDto
    {
        public string FullStdID { get; set; }
        public int Batch { get; set; }
        public int Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? NationalityNo { get; set; }
        
        public int? NationalityId { get; set; }
        public NationalityDto Nationality { get; set; }

        public int? ReligionId { get; set; }
        public ReligionDto Religion { get; set; }
        
    }
}
