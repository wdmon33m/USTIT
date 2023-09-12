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
        public static APIResponse GetBadRequest(APIResponse response,List<string> errorMessages)
        {
            response.StatusCode = HttpStatusCode.BadRequest;
            response.ErrorMessages = errorMessages;
            return response;
        }
    }
}
