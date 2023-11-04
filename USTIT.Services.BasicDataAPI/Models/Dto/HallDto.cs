namespace USTIT.Services.BasicDataAPI.Models.Dto
{
    public class HallDto
    {
        public int HallNo { get; set; }
        public string? HallName { get; set; }
        public int LectureCapacity { get; set; }
        public int ExamCapacity { get; set; }
        public string? Notes { get; set; }
    }
}
