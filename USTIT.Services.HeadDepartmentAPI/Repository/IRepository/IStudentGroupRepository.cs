using USTIT.Services.HeadDepartmentAPI.Models;

namespace USTIT.Services.HeadDepartmentAPI.Repository.IRepository
{
    public interface IStudentGroupRepository : IRepository<StudentGroup>
    {
        Task<StudentGroup> UpdateAsync(StudentGroup entity);
    }
}
