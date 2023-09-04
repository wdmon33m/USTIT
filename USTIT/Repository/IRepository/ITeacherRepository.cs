using USTIT.Services.BasicDataAPI.Models;

namespace USTIT.Services.BasicDataAPI.Repository.IRepository
{
    public interface ITeacherRepository : IRepository<Teacher>
    {
        Task<Teacher> UpdateAsync(Teacher entity);
    }
}
