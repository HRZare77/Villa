using Villa_Web.Models;

namespace Villa_Web.Services.IServices
{
    public interface IBaseService
    {
        APIResponse ResponseModel { get; set; }
        Task<T> SendAsync<T>(APIRequest apiRequest);
        Task<T> SendAsync<T>(APIRequest apiRequest, string token);
        Task<T> SendAsync<T>(APIRequest apiRequest, string token, bool isAuthorized);
    }
}
