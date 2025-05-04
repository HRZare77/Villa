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

        public async Task<IActionResult> UpdateVillaNumber(int villaNo)
        {
            VillaNumberUpdateVM villaNumberUpdateVM= new();
            var response = await _villaNumberService.GetAsync<APIResponse>(villaNo);
            if (response != null && response.IsSuccess)
            {
                VillaNumberDTo model = _mapper.Map<VillaNumberDTo>(response.Result);
                villaNumberUpdateVM.VillaNumber = _mapper.Map<VillaNumberUpdateDTo>(model);
            }

            response = await _villaService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                Console.WriteLine("Result: " + response.Result);
                var originalList = response.Result as List<Villa>;
                var villas = _mapper.Map<List<VillaDTo>>(originalList);
                villaNumberUpdateVM.VillaList = villas.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
                return View(villaNumberUpdateVM);
            }

            return NotFound();
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateVillaNumber(VillaNumberUpdateVM villaNumberUpdateVM)
        {
            if (ModelState.IsValid)
            {
                var response = await _villaNumberService.UpdateAsync<APIResponse>(villaNumberUpdateVM.VillaNumber);
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
                villaNumberUpdateVM.VillaList = villas.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
            }

            return View(villaNumberUpdateVM);
        }

        public async Task<IActionResult> DeleteVillaNumber(int villaNo)
        {
            VillaNumberDeleteVM villaNumberDeleteVM= new();
            var response = await _villaNumberService.GetAsync<APIResponse>(villaNo);
            if (response != null && response.IsSuccess)
            {
                VillaNumberDTo model = _mapper.Map<VillaNumberDTo>(response.Result);
                villaNumberDeleteVM.VillaNumber =model;
            }

            response = await _villaService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                Console.WriteLine("Result: " + response.Result);
                var originalList = response.Result as List<Villa>;
                var villas = _mapper.Map<List<VillaDTo>>(originalList);
                villaNumberDeleteVM.VillaList = villas.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
                return View(villaNumberDeleteVM);
            }

            return NotFound();
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteVillaNumber(VillaNumberDeleteVM villaNumberDeleteVM)
        {

            var response = await _villaNumberService.DeleteAsync<APIResponse>(villaNumberDeleteVM.VillaNumber.VillaNo);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction("IndexVillaNumber");
            }
            return View(villaNumberDeleteVM);
        }
    }
}
