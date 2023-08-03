using USTITAPI.Data;
using USTITAPI.Models.BasicData;
using USTITAPI.Repository.IRepository.BasicData;

namespace USTITAPI.Repository.BasicData
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        private readonly ApplicationDbContext _db;

        public CourseRepository(ApplicationDbContext db) : base(db)
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
