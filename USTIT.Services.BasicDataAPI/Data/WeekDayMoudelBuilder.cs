using Microsoft.EntityFrameworkCore;
using USTIT.Services.BasicDataAPI.Models;

namespace USTIT.Services.BasicDataAPI.Data
{
    public static class WeekDayMoudelMoudelBuilder
    {
        public static ModelBuilder WeekDayMB(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeekDay>().HasIndex(c => c.Day).IsUnique();
            modelBuilder.Entity<WeekDay>().HasIndex(c => c.DayArb).IsUnique();

            modelBuilder.Entity<WeekDay>().HasData(new WeekDay
            {
                Id = 1,
                Day = DayOfWeek.Saturday.ToString(),
                DayArb = "السبت",
            });

            modelBuilder.Entity<WeekDay>().HasData(new WeekDay
            {
                Id = 2,
                Day = DayOfWeek.Sunday.ToString(),
                DayArb = "الأحد",
            });

            modelBuilder.Entity<WeekDay>().HasData(new WeekDay
            {
                Id = 3,
                Day = DayOfWeek.Monday.ToString(),
                DayArb = "الإثنين",
            });

            modelBuilder.Entity<WeekDay>().HasData(new WeekDay
            {
                Id = 4,
                Day = DayOfWeek.Tuesday.ToString(),
                DayArb = "الثلاثاء",
            });

            modelBuilder.Entity<WeekDay>().HasData(new WeekDay
            {
                Id = 5,
                Day = DayOfWeek.Wednesday.ToString(),
                DayArb = "الأربعاء",
            });

            modelBuilder.Entity<WeekDay>().HasData(new WeekDay
            {
                Id = 6,
                Day = DayOfWeek.Thursday.ToString(),
                DayArb = "الخميس",
            });

            modelBuilder.Entity<WeekDay>().HasData(new WeekDay
            {
                Id = 7,
                Day = DayOfWeek.Friday.ToString(),
                DayArb = "الجمعة",
            });

            return modelBuilder;
        }
    }
}
