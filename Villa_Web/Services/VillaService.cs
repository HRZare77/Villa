using Villa_Utility;
using Villa_Web.Models;
using Villa_Web.Models.Dto;
using Villa_Web.Services.IServices;

namespace Villa_Web.Services
{
    public class VillaService : BaseService, IVillaService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private string _villaUrl;
        public VillaService(IHttpClientFactory httpClientFactory, IConfiguration configuration) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _villaUrl = configuration.GetValue<string>("ServiceUrls:VillaAPI");
        }

        public Task<T> CreateAsync<T>(VillaCreateDTo dto, string token)
        {
            var request = new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = _villaUrl + "/api/VillaAPI",
                Token = token
            };
            return SendAsync<T>(request);
        }

        public Task<T> DeleteAsync<T>(int id, string token)
        {
            var request = new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = _villaUrl + "/api/VillaAPI/" + id,
                Token = token
            };
            return SendAsync<T>(request);
        }

        public Task<T> GetAllAsync<T>(string token)
        {
            var request = new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = _villaUrl + "api/VillaAPI",
                Token = token
            };
            return SendAsync<T>(request);
        }

        public Task<T> GetAsync<T>(int id, string token)
        {
            var request = new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = _villaUrl + "/api/VillaAPI/" + id,
                Token = token
            };
            return SendAsync<T>(request);
        }

        public Task<T> UpdateAsync<T>(VillaUpdateDTo dto, string token)
        {
            var request = new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = _villaUrl + "/api/VillaAPI/" + dto.Id,
                Token = token
            };
            return SendAsync<T>(request);
        }


    }
}
