using Microsoft.AspNetCore.Mvc;
using Villa_Web.Models;
using Villa_Web.Models.Dto;
using Villa_Web.Services.IServices;

namespace Villa_Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpGet]
        public IActionResult Login()
        {
            LoginRequestDTO loginRequestDTO = new LoginRequestDTO();
            return View(loginRequestDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginRequestDTO loginRequestDTO)
        {
            if (ModelState.IsValid)
            {
                var response = await _authService.LoginAsync<APIResponse>(loginRequestDTO);
                if (response != null && response.IsSuccess)
                {
                    HttpContext.Session.SetString("JWToken", response.Result.ToString());
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(loginRequestDTO);
        }

        [HttpGet]
        public IActionResult Register()
        {
            RgisterationRequestDTO rgisterationRequestDTO = new RgisterationRequestDTO();
            return View(rgisterationRequestDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RgisterationRequestDTO rgisterationRequestDTO)
        {
            if (ModelState.IsValid)
            {
                var response = await _authService.RegisterAsync<APIResponse>(rgisterationRequestDTO);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction("Login");
                }
            }
            return View(rgisterationRequestDTO);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
