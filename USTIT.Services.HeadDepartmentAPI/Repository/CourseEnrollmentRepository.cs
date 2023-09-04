using USTIT.Services.HeadDepartmentAPI.Data;
using USTIT.Services.HeadDepartmentAPI.Models;
using USTIT.Services.HeadDepartmentAPI.Repository.IRepository;
namespace USTIT.Services.HeadDepartmentAPI.Repository
{
    public class CourseEnrollmentRepository : Repository<CourseEnrollment>, ICourseEnrollmentRepository
    {
        private readonly AppDbContext _db;

        public CourseEnrollmentRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<CourseEnrollment> UpdateAsync(CourseEnrollment entity)
        {
            //entity.UpdatedDate = DateTime.Now;
            _db.CourseEnrollments.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
