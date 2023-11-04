using USTIT.Services.HeadDepartmentAPI.Models;

namespace USTIT.Services.HeadDepartmentAPI.Repository.IRepository
{
    public interface ILectureScheduleRepository : IRepository<LectureSchedule>
    {
        Task<LectureSchedule> UpdateAsync(LectureSchedule entity);
    }
}
