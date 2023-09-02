using USTIT.WEB.Utility;
using static USTIT.WEB.Utility.SD;

namespace USTITWEB.Models
{
    public class APIRequest
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
    }
}
