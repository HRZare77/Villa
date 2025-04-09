using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Villa;
using Villa.Models.Dto;

namespace Villa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<VillaDTo> GetVillas()
        {
            return new List<VillaDTo>
            {
                new VillaDTo { Id = 1, Name = "Villa 1" },
                new VillaDTo { Id = 2, Name = "Villa 2" }
            };
        }
    }
}
