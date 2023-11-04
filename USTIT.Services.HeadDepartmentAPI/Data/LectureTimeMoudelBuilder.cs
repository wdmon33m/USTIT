using Microsoft.EntityFrameworkCore;
using USTIT.Services.HeadDepartmentAPI.Models;

namespace USTIT.Services.HeadDepartmentAPI.Data
{
    public static class LectureTimeMoudelBuilder
    {
        public static ModelBuilder LectureTimeMB(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LectureTime>().HasData(new LectureTime
            {
                Id = 1,
                NameArb = "المحاضرة الأولى",
                NameEng = "First Lecture",
                StartAt = new TimeOnly(08,30),
                EndAt = new TimeOnly(10,30)
            });

            modelBuilder.Entity<LectureTime>().HasData(new LectureTime
            {
                Id = 2,
                NameArb = "المحاضرة الثانية",
                NameEng = "Second Lecture",
                StartAt = new TimeOnly(11, 00),
                EndAt = new TimeOnly(13, 00)
            });

            modelBuilder.Entity<LectureTime>().HasData(new LectureTime
            {
                Id = 3,
                NameArb = "المحاضرة الثالثة",
                NameEng = "Third Lecture",
                StartAt = new TimeOnly(14, 00),
                EndAt = new TimeOnly(16, 00)
            });

            modelBuilder.Entity<LectureTime>().HasData(new LectureTime
            {
                Id = 4,
                NameArb = "المحاضرة الرابعة",
                NameEng = "Forth Lecture",
                StartAt = new TimeOnly(16, 00),
                EndAt = new TimeOnly(18, 00)
            });

            return modelBuilder;
        }
    }
}
