using USTIT.Services.BasicDataAPI.Models;

namespace USTIT.Services.BasicDataAPI.Repository.IRepository
{
    public interface IClassRepository
    {
        List<Class> GetAllAsync();
        Class GetAsync(Func<Class, bool> filter = null);
    }
}
