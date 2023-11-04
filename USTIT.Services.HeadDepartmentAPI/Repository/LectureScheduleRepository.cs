using USTIT.Services.HeadDepartmentAPI.Data;
using USTIT.Services.HeadDepartmentAPI.Models;
using USTIT.Services.HeadDepartmentAPI.Repository.IRepository;

namespace USTIT.Services.HeadDepartmentAPI.Repository
{
    public class LectureScheduleRepository : Repository<LectureSchedule>, ILectureScheduleRepository
    {
        private readonly AppDbContext _db;

        public LectureScheduleRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<LectureSchedule> UpdateAsync(LectureSchedule entity)
        {
            //entity.UpdatedDate = DateTime.Now;
            _db.LectureSchedules.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
