using USTIT.Services.BasicDataAPI.Data;
using USTIT.Services.BasicDataAPI.Models;
using USTIT.Services.BasicDataAPI.Repository.IRepository;

namespace USTIT.Services.BasicDataAPI.Repository
{
    public class WeekDayRepository : Repository<WeekDay>, IWeekDayRepository
    {
        private readonly AppDbContext _db;

        public WeekDayRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<WeekDay> UpdateAsync(WeekDay entity)
        {
            _db.WeekDays.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
