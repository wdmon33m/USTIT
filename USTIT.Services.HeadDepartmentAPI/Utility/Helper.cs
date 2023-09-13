using Microsoft.IdentityModel.Tokens;

namespace USTIT.Services.StudentAPI.Utility
{
    public static class Helper
    {
        public static bool IsEmpty(this object obj)
        {
            if (obj == null || obj.Equals(""))
                return true;
            else
                return false;
        }
        public static bool IsEmpty(this List<object> list)
        {
            if (list.IsNullOrEmpty() || list.Count == 0)
                return true;
            else
                return false;

        }

        public static bool IsEmpty(this IEnumerable<object> list)
        {
            if (list.IsNullOrEmpty() || list.Count() == 0)
                return true;
            else
                return false;

        }
    }
}
