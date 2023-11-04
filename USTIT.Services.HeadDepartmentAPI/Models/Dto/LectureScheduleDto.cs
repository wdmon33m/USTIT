namespace USTIT.Services.HeadDepartmentAPI.Models.Dto
{
    public class LectureScheduleDto
    {
        public int Id { get; set; }
        public int HallNo { get; set; }
        public int LectureTimeId { get; set; }
        public LectureTimeDto? LectureTime { get; set; }
        public string CENo { get; set; }
        public CourseEnrollmentDto? CourseEnrollment { get; set; }
        public string StdGroupNo { get; set; }
        public StudentGroupDto? StudentGroup { get; set; }

    }
}
