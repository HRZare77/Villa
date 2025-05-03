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
                    return RedirectToAction("IndexVilla");
                }
            }
            return View(villaCreateDTo);
        }

        public async Task<IActionResult> UpdateVilla( int id)
        {
            var response = await _villaService.GetAsync<APIResponse>(id);
            if (response != null && response.IsSuccess)
            {
                VillaDTo model = _mapper.Map<VillaDTo>(response.Result);
                return View(model);
            }
            return NotFound();
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateVilla(VillaUpdateDTo villaUpdateDTo)
        {
            if (ModelState.IsValid)
            {
                var response = await _villaService.UpdateAsync<APIResponse>(villaUpdateDTo);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction("IndexVilla");
                }
            }
            return View(villaUpdateDTo);
        }

        public async Task<IActionResult> DeleteVilla( int id)
        {
            var response = await _villaService.GetAsync<APIResponse>(id);
            if (response != null && response.IsSuccess)
            {
                VillaDTo model = _mapper.Map<VillaDTo>(response.Result);
                return View(model);
            }

            return NotFound();
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteVilla(VillaDTo villaDTo)
        {
           
                var response = await _villaService.DeleteAsync<APIResponse>(villaDTo.Id);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction("IndexVilla");
                }
            return View(villaDTo);
        }
    }
}
