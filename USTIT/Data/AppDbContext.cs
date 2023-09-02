using Microsoft.EntityFrameworkCore;
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
    }
}
