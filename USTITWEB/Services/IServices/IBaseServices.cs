using USTITWEB.Models;

namespace USTITWEB.Services.IServices
{
    public interface IBaseServices
    {
        APIResponse responseModel { get; set; }
        Task<T> SendAsync<T>(APIRequest aPIRequest);
    }
}
