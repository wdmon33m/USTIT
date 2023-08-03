using USTITAPI.Models;
using System.Linq.Expressions;
using USTITAPI.Models.BasicData;

namespace USTITAPI.Repository.IRepository.BasicData
{
    public interface ICourseRepository : IRepository<Course>
    {
        Task<Course> UpdateAsync(Course entity);
    }
}
