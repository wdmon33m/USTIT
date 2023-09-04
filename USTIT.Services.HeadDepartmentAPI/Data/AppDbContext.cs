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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Absence>()
                .Property(t => t.ANo)
                .HasComputedColumnSql(@"'A-' + CAST(StdGroupNo AS NVARCHAR(50)) + '-' + SUBSTRING(CENo, 13, LEN(CENo)) + '-' + CAST(ADate AS NVARCHAR(20))");

            // Set AbsenceId as the primary key
            modelBuilder.Entity<Absence>().HasKey(p => p.AbsenceId);
        }
    }
}
