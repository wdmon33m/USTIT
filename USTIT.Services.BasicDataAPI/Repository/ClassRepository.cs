using System.Linq.Expressions;
using USTIT.Services.BasicDataAPI.Data;
using USTIT.Services.BasicDataAPI.Models;
using USTIT.Services.BasicDataAPI.Repository.IRepository;

namespace USTIT.Services.BasicDataAPI.Repository
{
    public class ClassRepository : IClassRepository
    {
        private readonly List<Class> classesList = new List<Class>() {
            new Class { ClassNo = 1, ClassNameArb = "الأول", ClassNameEng = "First"} ,
            new Class { ClassNo = 2, ClassNameArb = "الثاني", ClassNameEng = "Second"} ,
            new Class { ClassNo = 3, ClassNameArb = "الثالث", ClassNameEng = "Third"} ,
            new Class { ClassNo = 4, ClassNameArb = "الرابع", ClassNameEng = "Fourth"}};

        public Task CreateAsync(Class entity)
        {
            throw new NotImplementedException();
        }

        public Class GetAsync(Func<Class, bool> filter = null)
        {
            Class obj = new Class();
            if (filter != null)
            {
                obj = classesList.FirstOrDefault(filter);
            }
            else
            {
                obj = new Class();
            }
            return obj;
        }

        public List<Class> GetAllAsync()
        {
            return classesList;
        }
    }
}
