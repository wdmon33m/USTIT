using System.Net;

namespace USTIT.Services.HeadDepartmentAPI.Models
{
    public class APIResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public List<string> ErrorMessages { get; set; }
        public object Result { get; set; }

        public APIResponse BadRequest(string? errorMessage = null)
        {
            StatusCode = HttpStatusCode.BadRequest;
            IsSuccess = false;
            ErrorMessages = new() { errorMessage };
            return this;
        }

        public APIResponse NoContent(string? errorMessage = null)
        {
            StatusCode = HttpStatusCode.NoContent;
            IsSuccess = false;
            ErrorMessages = new() { errorMessage };
            return this;
        }

        public APIResponse InternalServerError(string? errorMessage = null)
        {
            StatusCode = HttpStatusCode.InternalServerError;
            IsSuccess = false;
            ErrorMessages = new() { errorMessage };
            return this;
        }

        public APIResponse NotFound(string? errorMessage = null)
        {
            StatusCode = HttpStatusCode.NotFound;
            IsSuccess = false;
            ErrorMessages = new() { errorMessage };
            return this;
        }
    }
}
