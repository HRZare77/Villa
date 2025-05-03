using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Villa_Web.Services.IServices;
using Villa_Web.Models.Dto;
using Villa_Web.Models;
using Newtonsoft.Json;
using Villa_Web.Services;

namespace Villa_Web.Controllers
{
    public class VillaNumberController : Controller
    {
        private readonly IVillaNumberService _villaNumberService;
        private readonly IMapper _mapper;
        public VillaNumberController(IVillaNumberService villaNumberService, IMapper mapper)
        {
            _villaNumberService = villaNumberService;
            _mapper = mapper;
        }

        public async Task<IActionResult> IndexVillaNumber()
        {
            var list = await _villaNumberService.GetAllAsync<APIResponse>();
            if (list != null && list.IsSuccess)
            {
                var model = _mapper.Map<List<VillaNumberDTo>>(list.Result);
                return View(model);
            }
            return View(new List<VillaNumberDTo>());

        }
    }
}
