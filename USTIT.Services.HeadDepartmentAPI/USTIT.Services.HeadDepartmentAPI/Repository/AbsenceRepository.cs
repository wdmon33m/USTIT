using USTIT.Services.HeadDepartmentAPI.Data;
using USTIT.Services.HeadDepartmentAPI.Models;
using USTIT.Services.HeadDepartmentAPI.Repository.IRepository;

namespace USTIT.Services.HeadDepartmentAPI.Repository
{
    public class AbsenceRepository : Repository<Absence>, IAbsenceRepository
    {
        private readonly AppDbContext _db;

        public AbsenceRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Absence> UpdateAsync(Absence entity)
        {
            //entity.UpdatedDate = DateTime.Now;
            _db.Absences.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
