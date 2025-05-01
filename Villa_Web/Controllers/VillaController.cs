using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Villa_Web.Models;
using Villa_Web.Models.Dto;
using Villa_Web.Services.IServices;

namespace Villa_Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly IVillaService _villaService;
        private readonly IMapper _mapper;
        public VillaController(IVillaService villaService,IMapper mapper)
        {
            _villaService = villaService;
            _mapper = mapper;
        }
        public async Task<IActionResult> IndexVilla()
        {
            var list = await _villaService.GetAllAsync<APIResponse>();
            if (list != null && list.IsSuccess)
            {
                var model = _mapper.Map<List<VillaDTo>>(list.Result);
                return View(model);
            }
            return View(new List<VillaDTo>());
        }

        public async Task<IActionResult> CreateVilla()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVilla(VillaCreateDTo villaCreateDTo)
        {
            if (ModelState.IsValid)
            {
                var response = await _villaService.CreateAsync<APIResponse>(villaCreateDTo);
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Villa created successfully";
                    return RedirectToAction("IndexVilla");
                }
                else
                {
                    TempData["error"] = response.Errors.FirstOrDefault();
                }
            }
            return View(villaCreateDTo);
        }
    }
}
