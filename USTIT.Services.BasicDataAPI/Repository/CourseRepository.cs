using USTIT.Services.BasicDataAPI.Data;
using USTIT.Services.BasicDataAPI.Models;
using USTIT.Services.BasicDataAPI.Repository.IRepository;

namespace USTIT.Services.BasicDataAPI.Repository
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        private readonly AppDbContext _db;

        public CourseRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Course> UpdateAsync(Course entity)
        {
            //entity.UpdatedDate = DateTime.Now;
            _db.Courses.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
