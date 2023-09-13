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

        public DbSet<StudentHeader> StudentHeaders { get; set; }
        public DbSet<StudentNames> StudentNames { get; set; }
        public DbSet<Religion> Religions { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<StudentBasicInfo> StudentBasicInfos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StudentHeader>().HasKey(p => p.FullStdID);
            modelBuilder.Entity<StudentHeader>()
                .Property(a => a.FullStdID).IsRequired().HasMaxLength(13)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<StudentNames>().HasKey(p => p.FullStdID);
            modelBuilder.Entity<StudentNames>()
                .Property(a => a.FullStdID).IsRequired().HasMaxLength(13).ValueGeneratedNever();

            modelBuilder.Entity<StudentHeader>()
              .HasOne(s => s.StudentNames)
              .WithOne(s => s.Student)
              .HasForeignKey<StudentNames>(s => s.FullStdID)
              .IsRequired();

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
