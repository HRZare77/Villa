using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Villa;
using Villa.Data;
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
            return VillaStore.villaList;
        }
    }
}
