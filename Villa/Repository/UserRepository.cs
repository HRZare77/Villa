using AutoMapper;
using Villa.Data;
using Villa.Models.Dto;
using Villa.Repository.IRepository;

namespace Villa.Repository
{
    public class UserRepository: IUserRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public UserRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            throw new NotImplementedException();
        }
        public Task<RgisterationRequestDTO> Register(RgisterationRequestDTO rgisterationRequestDTO)
        {
            throw new NotImplementedException();
        }
        public Task<bool> IsUniqueUser(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
