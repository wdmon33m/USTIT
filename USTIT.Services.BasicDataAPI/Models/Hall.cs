using System.ComponentModel.DataAnnotations;

namespace USTIT.Services.BasicDataAPI.Models
{
    public class Hall
    {
        [Key]
        public int HallNo { get; set; }
        public string HallName { get; set; }
        public int LectureCapacity { get; set; }
        public int ExamCapacity { get; set; }
        public string? Notes { get; set; }
    }
}
