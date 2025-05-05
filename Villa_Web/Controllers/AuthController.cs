using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Villa_Utility;
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
            var response = await _authService.LoginAsync<APIResponse>(loginRequestDTO);
            if (ModelState.IsValid)
            {
                if (response != null && response.IsSuccess)
                {
                    LoginResponseDTO loginResponseDTO = JsonConvert.DeserializeObject<LoginResponseDTO>(response.Result.ToString());
                    HttpContext.Session.SetString(SD.SessionToken, loginResponseDTO.Token.ToString());
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("ErrorMessages", response.Errors.FirstOrDefault());
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
        public async Task<IActionResult> Logout()
        {
          await HttpContext.SignOutAsync();
            HttpContext.Session.SetString(SD.SessionToken, string.Empty);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
