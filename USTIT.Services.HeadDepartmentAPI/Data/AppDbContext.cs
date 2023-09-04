using Microsoft.EntityFrameworkCore;
using Stripe;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using USTIT.Services.HeadDepartmentAPI.Models;
using static System.Net.Mime.MediaTypeNames;

namespace USTIT.Services.HeadDepartmentAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Absence> Absences { get; set; }
        public DbSet<CourseEnrollment> CourseEnrollments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Absence>()
                .Property(a => a.ANo)
                .HasComputedColumnSql(@"'A-' + CAST(StdGroupNo AS NVARCHAR(50)) + '-' + SUBSTRING(CENo, 13, LEN(CENo)) + '-' + CAST(ADate AS NVARCHAR(20))");

            modelBuilder.Entity<Absence>().HasKey(p => p.AbsenceId);

            modelBuilder.Entity<CourseEnrollment>()
                .Property(c => c.CENo)
                .HasComputedColumnSql(@"CAST([DeptCode] AS NVARCHAR(10)) + '-' + CAST([AcYear] AS NVARCHAR(4)) + '-' + CAST([SemNo] AS NVARCHAR(2)) + '-' + CAST([CourseCode] AS NVARCHAR(50))");
            modelBuilder.Entity<CourseEnrollment>()
               .Property(c => c.CourseWeight)
               .HasComputedColumnSql(@"(([LectureWeight]+[TutorialWeight])+[LabWeight])");

            modelBuilder.Entity<Absence>().HasKey(p => p.AbsenceId);
        }
    }
}
