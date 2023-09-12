using USTIT.Services.BasicDataAPI.Models;

namespace USTIT.Services.BasicDataAPI.Repository.IRepository
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        Task<Department> UpdateAsync(Department entity);
    }
}
