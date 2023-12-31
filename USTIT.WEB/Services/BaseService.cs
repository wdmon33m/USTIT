﻿using Newtonsoft.Json;
using System.Text;
using System.Net;
using USTIT.WEB.Services.IServices;
using static USTIT.WEB.Utility.SD;
using USTIT.WEB.Models;

namespace USTIT.WEB.Services
{
    public class BaseService : IBaseServices
    {
        public APIResponse responseModel { get; set; }
        public IHttpClientFactory httpClient { get; set; }
        public BaseService(IHttpClientFactory httpClient)
        {
            this.responseModel = new();
            this.httpClient = httpClient;
        }

        public async Task<T> SendAsync<T>(APIRequest apiRequest)
        {
            try
            {
                var client = httpClient.CreateClient("USTAPI");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.Url);

                if (apiRequest.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),
                        Encoding.UTF8, "application/json");
                }

                switch (apiRequest.ApiType)
                {
                    case ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;

                    case ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;

                    case ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;

                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                HttpResponseMessage apiResponse = null;
                apiResponse = await client.SendAsync(message);

                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                try
                {
                    var ApiResponse = JsonConvert.DeserializeObject<APIResponse>(apiContent);
                    if (ApiResponse is not null)
                    {
                        if (ApiResponse.StatusCode == HttpStatusCode.BadRequest ||
                            ApiResponse.StatusCode == HttpStatusCode.NotFound)
                        {
                            ApiResponse.StatusCode = HttpStatusCode.BadRequest;
                            ApiResponse.IsSuccess = false;

                            var res = JsonConvert.SerializeObject(ApiResponse);
                            var returnObj = JsonConvert.DeserializeObject<T>(res);
                            return returnObj;

                        }
                    }
                }
                catch (Exception)
                {
                    var exceptionResponse = JsonConvert.DeserializeObject<T>(apiContent);
                    return exceptionResponse;
                }

                var APIResponse = JsonConvert.DeserializeObject<T>(apiContent);
                return APIResponse;
            }
            catch (Exception ex)
            {
                var dto = new APIResponse
                {
                    ErrorMessages = new List<string> { ex.Message } ,
                    IsSuccess = false,
                };
                var res = JsonConvert.SerializeObject(dto);
                var APIResponse = JsonConvert.DeserializeObject<T> (res);
                return APIResponse;
            }
        }
    }
}
