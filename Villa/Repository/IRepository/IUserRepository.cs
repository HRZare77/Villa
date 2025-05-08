using Villa.Models.Dto;

namespace Villa.Repository.IRepository
{
    public interface IUserRepository
    {
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<UserDTO> Register(RgisterationRequestDTO rgisterationRequestDTO);
        Task<bool> IsUniqueUser(string userName);
    }
}
