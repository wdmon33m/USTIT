using USTIT.Services.StudentAPI.Models;

namespace USTIT.Services.StudentAPI.Repository.IRepository
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<Student> UpdateAsync(Student entity);
    }
}
