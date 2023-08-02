using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using USTITAPI.Models.BasicData;

namespace USTITAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
    }
}
