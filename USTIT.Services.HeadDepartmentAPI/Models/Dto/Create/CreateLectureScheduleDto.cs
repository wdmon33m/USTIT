namespace USTIT.Services.HeadDepartmentAPI.Models.Dto.Create
{
    public class CreateLectureScheduleDto
    {
        public int HallNo { get; set; }
        public int LectureTimeId { get; set; }
        public string CENo { get; set; }
        public string StdGroupNo { get; set; }
        public int DayOfWeek { get; set; }
    }
}
