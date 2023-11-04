using Microsoft.EntityFrameworkCore;
using USTIT.Services.HeadDepartmentAPI.Models;

namespace USTIT.Services.HeadDepartmentAPI.Data
{
    public static class LecureScheduleMoudelBuilder
    {
        public static ModelBuilder LecureScheduleVM(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LectureSchedule>().HasIndex(c => c.CENo).IsUnique();
            modelBuilder.Entity<LectureSchedule>().HasIndex(c => c.DayOfWeek).IsUnique();
            modelBuilder.Entity<LectureSchedule>().HasIndex(c => c.StdGroupNo).IsUnique();

            return modelBuilder;
        }
    }
}
