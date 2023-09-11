using Microsoft.EntityFrameworkCore;
using USTIT.Services.StudentAPI.Models;

namespace USTIT.Services.StudentAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<StudentNames> StudentNames { get; set; }
        public DbSet<Religion> Religions { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<StudentBasicInfo> StudentBasicInfos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().HasKey(p => p.FullStdID);
            modelBuilder.Entity<Student>()
                .Property(a => a.FullStdID).IsRequired().HasMaxLength(13)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<StudentNames>().HasKey(p => p.FullStdID);
            modelBuilder.Entity<StudentNames>()
                .Property(a => a.FullStdID).IsRequired().HasMaxLength(13).ValueGeneratedNever();

            modelBuilder.Entity<StudentBasicInfo>().HasKey(p => p.FullStdID);
            modelBuilder.Entity<StudentBasicInfo>()
                .Property(a => a.FullStdID).IsRequired().HasMaxLength(13).ValueGeneratedNever();

            modelBuilder.Entity<StudentNames>()
                .Property(a => a.ArFullName)
                .HasComputedColumnSql("[ArFirstName] + ' ' + [ArSecondName] + ' ' + [ArThirdName] + ' ' + [ArFourthName]");

            modelBuilder.Entity<StudentNames>()
                .Property(a => a.EnFullName)
                .HasComputedColumnSql("[EnFirstName] + ' ' + [EnSecondName] + ' ' + [EnThirdName] + ' ' + [EnFourthName]");

            modelBuilder.ReligionMB();

        }
    }
}
