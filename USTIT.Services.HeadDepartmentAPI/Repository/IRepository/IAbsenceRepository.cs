using USTIT.Services.HeadDepartmentAPI.Models;

namespace USTIT.Services.HeadDepartmentAPI.Repository.IRepository
{
    public interface IAbsenceRepository : IRepository<Absence>
    {
        Task<Absence> UpdateAsync(Absence entity);
    }
}
