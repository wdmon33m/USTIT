using USTIT.Services.BasicDataAPI.Models;

namespace USTIT.Services.BasicDataAPI.Repository.IRepository
{
    public interface IWeekDayRepository : IRepository<WeekDay>
    {
        Task<WeekDay> UpdateAsync(WeekDay entity);
    }
}
