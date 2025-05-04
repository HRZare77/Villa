using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Villa_Web.Services.IServices;
using Villa_Web.Models.Dto;
using Villa_Web.Models;
using Newtonsoft.Json;
using Villa_Web.Services;
using Villa_Web.Models.VM;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Villa_Web.Controllers
{
    public class VillaNumberController : Controller
    {
        private readonly IVillaNumberService _villaNumberService;
        private readonly IVillaService _villaService;
        private readonly IMapper _mapper;
        public VillaNumberController(IVillaNumberService villaNumberService, IMapper mapper, IVillaService villaService)
        {
            _villaNumberService = villaNumberService;
            _mapper = mapper;
            _villaService = villaService;
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

        public async Task<IActionResult> CreateVillaNumber()
        {
            VillaNumberCreateVM villaNumberCreateVM = new();
            var list = await _villaService.GetAllAsync<APIResponse>();
            if (list != null && list.IsSuccess)
            {
                Console.WriteLine("Result: " + list.Result);
                var originalList = list.Result as List<Villa>;
                var villas = _mapper.Map<List<VillaDTo>>(originalList);
                villaNumberCreateVM.VillaList = villas.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
            }
            return View(villaNumberCreateVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVillaNumber(VillaNumberCreateVM villaNumberCreateVM)
        {
            if (ModelState.IsValid)
            {
                var response = await _villaNumberService.CreateAsync<APIResponse>(villaNumberCreateVM.VillaNumber);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexVillaNumber));
                }
                else
                {
                    if (response != null && response.Errors.Count > 0)
                    {
                        foreach (var error in response.Errors)
                        {
                            ModelState.AddModelError("ErrorMessages", error);
                        }
                    }
                }
            }

            var list = await _villaService.GetAllAsync<APIResponse>();
            if (list != null && list.IsSuccess)
            {
                Console.WriteLine("Result: " + list.Result);
                var originalList = list.Result as List<Villa>;
                var villas = _mapper.Map<List<VillaDTo>>(originalList);
                villaNumberCreateVM.VillaList = villas.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
            }

            return View(villaNumberCreateVM);
        }

        public async Task<IActionResult> UpdateVillaNumber(int id)
        {
            var response = await _villaNumberService.GetAsync<APIResponse>(id);
            if (response != null && response.IsSuccess)
            {
                VillaNumberDTo model = _mapper.Map<VillaNumberDTo>(response.Result);
                return View(model);
            }
            return NotFound();
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateVillaNumber(VillaNumberUpdateDTo villaNumberUpdateDTo)
        {
            if (ModelState.IsValid)
            {
                var response = await _villaNumberService.UpdateAsync<APIResponse>(villaNumberUpdateDTo);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction("IndexVilla");
                }
            }
            return View(villaNumberUpdateDTo);
        }

        public async Task<IActionResult> DeleteVillaNumber(int id)
        {
            var response = await _villaNumberService.GetAsync<APIResponse>(id);
            if (response != null && response.IsSuccess)
            {
                VillaNumberDTo model = _mapper.Map<VillaNumberDTo>(response.Result);
                return View(model);
            }

            return NotFound();
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteVillaNumber(VillaNumberDTo villaNumberDTo)
        {

            var response = await _villaNumberService.DeleteAsync<APIResponse>(villaNumberDTo.VillaNo);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction("IndexVilla");
            }
            return View(villaNumberDTo);
        }
    }
}
