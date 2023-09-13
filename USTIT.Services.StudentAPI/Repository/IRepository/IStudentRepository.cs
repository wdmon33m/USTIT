using USTIT.Services.StudentAPI.Models;

namespace USTIT.Services.StudentAPI.Repository.IRepository
{
    public interface IStudentRepository : IRepository<StudentHeader>
    {
        Task<StudentHeader> UpdateAsync(StudentHeader entity);
    }
}
