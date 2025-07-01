using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Villa.Data;
using Villa.Models;
using Villa.Models.Dto;
using Villa.Repository.IRepository;

namespace Villa.Repository
{
    public class UserRepository: IUserRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private string secretKey;
        public UserRepository(ApplicationDbContext db, IMapper mapper,IConfiguration configuration,UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _mapper = mapper;
            secretKey = configuration.GetValue<string>("ApiSettings:Secret");
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
           var user = await _db.ApplicationUsers.FirstOrDefaultAsync(u => u.UserName.ToLower() == loginRequestDTO.UserName.ToLower());
            if (user == null)
            {
                return null;
            }

            var passwordCheck = await _userManager.CheckPasswordAsync(user, loginRequestDTO.Password);

            var tokenHandler=new JwtSecurityTokenHandler();
            var key = System.Text.Encoding.ASCII.GetBytes(secretKey);
            var roles= await _userManager.GetRolesAsync(user);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(ClaimTypes.Role,roles.FirstOrDefault())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new LoginResponseDTO()
            {
                User = _mapper.Map<UserDTO>(user),
                Role = roles.FirstOrDefault(),
                Token = tokenHandler.WriteToken(token),
            };
        }
        public async Task<UserDTO> Register(RgisterationRequestDTO rgisterationRequestDTO)
        {
            ApplicationUser user = _mapper.Map<ApplicationUser>(rgisterationRequestDTO);
            _userManager.CreateAsync(user);
            if (! _roleManager.RoleExistsAsync("admin").GetAwaiter().GetResult())
            {
                await _roleManager.CreateAsync(new IdentityRole("admin"));
                await _roleManager.CreateAsync(new IdentityRole("customer"));
            }

            await _userManager.AddToRoleAsync(user, "admin");
            var localUser =_db.ApplicationUsers.FirstOrDefault(u=>u.UserName== rgisterationRequestDTO.UserName);
            return _mapper.Map<UserDTO>(localUser);

        }
        public Task<bool> IsUniqueUser(string userName)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(u => u.UserName.ToLower() == userName.ToLower());
            if (user == null)
            {
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}
