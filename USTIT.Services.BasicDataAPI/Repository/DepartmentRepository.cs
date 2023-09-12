using USTIT.Services.BasicDataAPI.Data;
using USTIT.Services.BasicDataAPI.Models;
using USTIT.Services.BasicDataAPI.Repository.IRepository;

namespace USTIT.Services.BasicDataAPI.Repository
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        private readonly AppDbContext _db;

        public DepartmentRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Department> UpdateAsync(Department entity)
        {
            _db.Departments.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
