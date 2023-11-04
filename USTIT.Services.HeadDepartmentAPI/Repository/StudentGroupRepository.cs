using USTIT.Services.HeadDepartmentAPI.Data;
using USTIT.Services.HeadDepartmentAPI.Models;
using USTIT.Services.HeadDepartmentAPI.Repository.IRepository;

namespace USTIT.Services.HeadDepartmentAPI.Repository
{
    public class StudentGroupRepository : Repository<StudentGroup>, IStudentGroupRepository
    {
        private readonly AppDbContext _db;

        public StudentGroupRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<StudentGroup> UpdateAsync(StudentGroup entity)
        {
            _db.StudentGroups.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
