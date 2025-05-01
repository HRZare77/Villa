using System.Net;

namespace Villa_Web.Models
{
    public class APIResponse
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        public bool IsSuccess { get; set; } = true;
        public List<Villa>? Result { get; set; }
        public List<string>? Errors { get; set; }
        public APIResponse()
        {
            Errors = new List<string>();
        }
    }
}
