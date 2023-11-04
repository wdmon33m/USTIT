namespace USTIT.Services.HeadDepartmentAPI.Models.Dto
{
    public class LectureTimeDto
    {
        public int Id { get; set; }
        public TimeOnly StartAt { get; set; }
        public TimeOnly EndAt { get; set; }
        public string NameArb { get; set; }
        public string NameEng { get; set; }
    }
}
