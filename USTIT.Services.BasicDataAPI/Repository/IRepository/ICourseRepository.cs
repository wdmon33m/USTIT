using USTIT.Services.BasicDataAPI.Models;

namespace USTIT.Services.BasicDataAPI.Repository.IRepository
{
    public interface ICourseRepository : IRepository<Course>
    {
        Task<Course> UpdateAsync(Course entity);
    }
}
