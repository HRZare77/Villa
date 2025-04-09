using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Villa;

namespace Villa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Models.Villa> GetVillas()
        {
            return new List<Models.Villa>
            {
                new Models.Villa { Id = 1, Name = "Villa 1" },
                new Models.Villa { Id = 2, Name = "Villa 2" }
            };
        }
    }
}
