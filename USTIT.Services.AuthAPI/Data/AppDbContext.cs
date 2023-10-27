using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using USTIT.Services.AuthAPI.Models;
using USTIT.Services.AuthAPI.Utility;

namespace USTIT.Services.AuthAPI.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUsers  { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles  { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationRole>().HasData(new ApplicationRole
            {
                Name = SD.RoleAdmin,
                NormalizedName = SD.RoleAdmin.ToUpper(),
            });
            modelBuilder.Entity<ApplicationRole>().HasData(new ApplicationRole
            {
                Name = SD.RoleCustomer,
                NormalizedName = SD.RoleCustomer.ToUpper(),
            });
        }
    }
}
