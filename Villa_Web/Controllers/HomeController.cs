using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Villa_Web.Models;
using Villa_Web.Models.Dto;
using Villa_Web.Services.IServices;

namespace Villa_Web.Controllers;

public class HomeController : Controller
{
    private readonly IVillaService _villaService;
    private readonly IMapper _mapper;
    public HomeController(IVillaService villaService, IMapper mapper)
    {
        _villaService = villaService;
        _mapper = mapper;
    }
    public async Task<IActionResult> Index()
    {
        var list = await _villaService.GetAllAsync<APIResponse>();
        if (list != null && list.IsSuccess)
        {
            var model = _mapper.Map<List<VillaDTo>>(list.Result);
            return View(model);
        }
        return View(new List<VillaDTo>());
    }

}
