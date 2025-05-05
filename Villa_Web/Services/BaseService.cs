using System.Text;
using Villa_Utility;
using Villa_Web.Models;
using Villa_Web.Services.IServices;

namespace Villa_Web.Services
{
    public class BaseService : IBaseService
    {
        public APIResponse ResponseModel { get; set; }

        public IHttpClientFactory HttpClientFactory { get; set; }
        public BaseService(IHttpClientFactory httpClientFactory)
        {
            ResponseModel = new APIResponse();
            HttpClientFactory = httpClientFactory;
        }

        public async Task<T> SendAsync<T>(APIRequest apiRequest)
        {
            try
            {
                var client = HttpClientFactory.CreateClient("VillaAPI");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.Url);
                if (apiRequest.Data != null)
                {
                    message.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(apiRequest.Data), Encoding.UTF8, mediaType: "application/json");
                }

                switch (apiRequest.ApiType)
                {
                    case SD.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case SD.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case SD.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    case SD.ApiType.GET:
                        message.Method = HttpMethod.Get;
                        break;
                }

                HttpResponseMessage apiResponse = await client.SendAsync(message);

                if(!string.IsNullOrEmpty(apiRequest.Token))
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiRequest.Token);
                }

                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                try
                {
                    var deserializedResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<APIResponse>(apiContent);
                    if (deserializedResponse != null && (apiResponse.StatusCode == System.Net.HttpStatusCode.BadRequest || apiResponse.StatusCode == System.Net.HttpStatusCode.NotFound))
                    {
                        deserializedResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                        deserializedResponse.IsSuccess = false;
                        var res = Newtonsoft.Json.JsonConvert.SerializeObject(deserializedResponse);
                        var returnObj = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(res);
                        return returnObj;
                    }
                }
                catch (Exception)
                {
                    var fallbackResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(apiContent);
                    return fallbackResponse;
                }
                var finalResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(apiContent);
                return finalResponse;
            }
            catch (Exception e)
            {
                var dto = new APIResponse()
                {
                    Errors = new List<string> { Convert.ToString(e.Message) },
                    IsSuccess = false,
                };
                var res = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
                var apiResponseModel = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(res);
                return apiResponseModel;
            }
        }

        public Task<T> SendAsync<T>(APIRequest apiRequest, string token)
        {
            throw new NotImplementedException();
        }

        public Task<T> SendAsync<T>(APIRequest apiRequest, string token, bool isAuthorized)
        {
            throw new NotImplementedException();
        }
    }
}
