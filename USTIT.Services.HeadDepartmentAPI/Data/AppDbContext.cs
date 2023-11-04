using Microsoft.EntityFrameworkCore;
using USTIT.Services.HeadDepartmentAPI.Models;

namespace USTIT.Services.HeadDepartmentAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Absence> Absences { get; set; }
        public DbSet<AbsenceDetails> AbsenceDetails { get; set; }
        public DbSet<CourseEnrollment> CourseEnrollments { get; set; }
        public DbSet<LectureTime> LectureTimes { get; set; }
        public DbSet<StudentGroup> StudentGroups { get; set; }
        public DbSet<LectureSchedule> LectureSchedules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Absence>().HasKey(p => p.ANo);
            modelBuilder.Entity<Absence>()
                .Property(a => a.ANo).IsRequired()
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<AbsenceDetails>().HasKey(p => p.ANo);
            modelBuilder.Entity<AbsenceDetails>()
                .Property(a => a.ANo).IsRequired()
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<CourseEnrollment>().HasKey(p => p.CENo);
            modelBuilder.Entity<CourseEnrollment>()
                .Property(a => a.CENo).IsRequired()
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<CourseEnrollment>()
               .Property(c => c.CourseWeight)
               .HasComputedColumnSql(@"(([LectureWeight]+[TutorialWeight])+[LabWeight])");

            modelBuilder.LectureTimeMB();
            modelBuilder.LecureScheduleVM();
        }
    }
}
