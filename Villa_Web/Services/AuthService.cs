using Villa_Utility;
using Villa_Web.Models;
using Villa_Web.Models.Dto;
using Villa_Web.Services.IServices;

namespace Villa_Web.Services
{
    public class AuthService : BaseService, IAuthService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private string _villaUrl;
        public AuthService(IHttpClientFactory httpClientFactory, IConfiguration configuration) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _villaUrl = configuration.GetValue<string>("ServiceUrls:VillaAPI");
        }

        public Task<T> LoginAsync<T>(LoginRequestDTO loginRequestDTO)
        {
            var request = new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = loginRequestDTO,
                Url = _villaUrl + "/api/UsersAuth/login"
            };
            return SendAsync<T>(request);
        }
        public Task<T> RegisterAsync<T>(RgisterationRequestDTO registerRequestDTO)
        {
            var request = new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = registerRequestDTO,
                Url = _villaUrl + "/api/UsersAuth/register"
            };
            return SendAsync<T>(request);
        }
    }
}
