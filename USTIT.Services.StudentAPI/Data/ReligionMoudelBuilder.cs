using Microsoft.EntityFrameworkCore;
using USTIT.Services.StudentAPI.Models;

namespace USTIT.Services.StudentAPI.Data
{
    public static class ReligionMoudelBuilder
    {
        public static ModelBuilder ReligionMB(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Religion>().HasData(new Religion
            {
                ReligionId = 1,
                ReligionNameAr = "مسلم",
                ReligionNameEn = "MUSLIM",
            });

            modelBuilder.Entity<Religion>().HasData(new Religion
            {
                ReligionId = 2,
                ReligionNameAr = "مسيحي",
                ReligionNameEn = "CHRISTIAN",
            });

            return modelBuilder;
        }
    }
}
