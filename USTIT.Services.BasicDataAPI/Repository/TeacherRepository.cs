using USTIT.Services.BasicDataAPI.Data;
using USTIT.Services.BasicDataAPI.Models;
using USTIT.Services.BasicDataAPI.Repository.IRepository;

namespace USTIT.Services.BasicDataAPI.Repository
{
    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        private readonly AppDbContext _db;

        public TeacherRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Teacher> UpdateAsync(Teacher entity)
        {
            _db.Teachers.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
