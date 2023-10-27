using System.Net;
using USTIT.Services.BasicDataAPI.Models;

namespace USTIT.Services.BasicDataAPI.Utility
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
    }
}
