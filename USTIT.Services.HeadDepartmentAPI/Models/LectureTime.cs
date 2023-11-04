namespace USTIT.Services.HeadDepartmentAPI.Models
{
    public class LectureTime
    {
        public int Id { get; set; }
        public TimeOnly StartAt { get; set; }
        public TimeOnly EndAt { get; set; }
        public string NameArb { get; set; }
        public string NameEng { get; set; }
    }
}
