using Microsoft.EntityFrameworkCore;
using USTIT.Services.BasicDataAPI.Models;

namespace USTIT.Services.BasicDataAPI.Data
{
    public static class AcademicDegreeMoudelBuilder
    {
        public static ModelBuilder AcademicDegreeMB(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AcademicDegree>().HasData(new AcademicDegree
            {
                Id = 1,
                AcademicDegreeArb = "بروفيسور",
                AcademicDegreeEng = "Professor",
            });

            modelBuilder.Entity<AcademicDegree>().HasData(new AcademicDegree
            {
                Id = 2,
                AcademicDegreeArb = "دكتور",
                AcademicDegreeEng = "Doctor",
            });

            modelBuilder.Entity<AcademicDegree>().HasData(new AcademicDegree
            {
                Id = 3,
                AcademicDegreeArb = "ماجستير",
                AcademicDegreeEng = "Master's",
            });

            modelBuilder.Entity<AcademicDegree>().HasData(new AcademicDegree
            {
                Id = 4,
                AcademicDegreeArb = "بكلاريوس",
                AcademicDegreeEng = "Bachelor's",
            });

            modelBuilder.Entity<AcademicDegree>().HasData(new AcademicDegree
            {
                Id = 5,
                AcademicDegreeArb = "دبلوم",
                AcademicDegreeEng = "Diploma",
            });
            return modelBuilder;
        }
    }
}
