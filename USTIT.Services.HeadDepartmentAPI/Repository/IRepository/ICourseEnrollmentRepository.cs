using USTIT.Services.HeadDepartmentAPI.Models;

namespace USTIT.Services.HeadDepartmentAPI.Repository.IRepository
{
    public interface ICourseEnrollmentRepository : IRepository<CourseEnrollment>
    {
        Task<CourseEnrollment> UpdateAsync(CourseEnrollment entity);
    }
}
