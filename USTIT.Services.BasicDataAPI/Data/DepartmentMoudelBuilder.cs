using Microsoft.EntityFrameworkCore;
using USTIT.Services.BasicDataAPI.Models;

namespace USTIT.Services.BasicDataAPI.Data
{
    public static class DepartmentMoudelBuilder
    {
        public static ModelBuilder DepartmentMB(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasKey(d => d.DeptCode);
            modelBuilder.Entity<Department>().Property(p => p.DeptCode).ValueGeneratedNever();
            modelBuilder.Entity<Department>().HasIndex(c => c.DepartmentNameEng).IsUnique();
            modelBuilder.Entity<Department>().HasIndex(c => c.DepartmentNameArb).IsUnique();

            modelBuilder.Entity<Department>().HasData(new Department
            {
                DeptCode = "CSCSB",
                DepartmentNameEng = "Computer Science (B.Sc.)",
                DepartmentNameArb = "علوم الحاسوب",
                SemCount = 8,
            });

            modelBuilder.Entity<Department>().HasData(new Department
            {
                DeptCode = "CSTCB",
                DepartmentNameEng = "Information and Communication Technology (B.Sc.)",
                DepartmentNameArb = "تكنولوجيا المعلومات و الاتصالات",
                SemCount = 8,
            });

            modelBuilder.Entity<Department>().HasData(new Department
            {
                DeptCode = "ITISB",
                DepartmentNameEng = "Information System (B.Sc.)",
                DepartmentNameArb = "نظم المعلومات",
                SemCount = 8,
            });

            modelBuilder.Entity<Department>().HasData(new Department
            {
                DeptCode = "ITITB" ,
                DepartmentNameEng = "Information Technology (B.Sc.)",
                DepartmentNameArb = "بكالوريوس تقنية المـعلومات",
                SemCount = 8,
            });

            modelBuilder.Entity<Department>().HasData(new Department
            {
                DeptCode = "ITITD",
                DepartmentNameEng = "Information Technology (ASc.)",
                DepartmentNameArb = "دبلوم تقنية المعلومات",
                SemCount = 6,
            });

            modelBuilder.Entity<Department>().HasData(new Department
            {
                DeptCode = "ITNWD",
                DepartmentNameEng = "Networking (ASc.)",
                DepartmentNameArb = "دبلوم تقنية نظم شبكات الحاسوب",
                SemCount = 6,
            });

            return modelBuilder;
        }
    }
}
