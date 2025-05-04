using Villa.Models.Dto;

namespace Villa.Repository.IRepository
{
    public interface IUserRepository
    {
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<RgisterationRequestDTO> Register(RgisterationRequestDTO rgisterationRequestDTO);
        Task<bool> IsUniqueUser(string userName);
    }
}
