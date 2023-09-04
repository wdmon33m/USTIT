using Microsoft.EntityFrameworkCore;
using Stripe;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using USTIT.Services.BasicDataAPI.Models;

namespace USTIT.Services.BasicDataAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<AcademicDegree> AcademicDegrees { get; set;}
        public DbSet<Teacher> Teachers { get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Teacher>().HasKey(p => p.TeacherNo);
            modelBuilder.Entity<Teacher>().Property(p => p.TeacherNo).ValueGeneratedNever();
            modelBuilder.Entity<Teacher>().HasIndex(c => c.TeacherName).IsUnique();

            modelBuilder.AcademicDegreeMB();
        }
    }
}
