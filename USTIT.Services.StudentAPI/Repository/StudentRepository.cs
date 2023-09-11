using USTIT.Services.StudentAPI.Data;
using USTIT.Services.StudentAPI.Models;
using USTIT.Services.StudentAPI.Repository.IRepository;

namespace USTIT.Services.StudentAPI.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private readonly AppDbContext _db;

        public StudentRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Student> UpdateAsync(Student entity)
        {
            //entity.UpdatedDate = DateTime.Now;
            _db.Students.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
