using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Villa.Models.Dto;
using Villa.Repository.IRepository;

namespace Villa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        [HttpPost("register")]
        public async Task<ActionResult<RgisterationRequestDTO>> Register([FromBody] RgisterationRequestDTO rgisterationRequestDTO)
        {
            if (!await _userRepository.IsUniqueUser(rgisterationRequestDTO.UserName))
            {
                ModelState.AddModelError("ErrorMessages", "User already exists!");
                return BadRequest(ModelState);
            }
            var user = await _userRepository.Register(rgisterationRequestDTO);
            return Ok();
        }
        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDTO>> Login([FromBody] LoginRequestDTO loginRequestDTO)
        {
            var user = await _userRepository.Login(loginRequestDTO);
            if (user == null)
            {
                return Unauthorized();
            }
            return Ok(user);
        }
    }
}
