using Villa_Web.Models.Dto;

namespace Villa_Web.Services.IServices
{
    public interface IVillaNumberService
    {
        Task<T> GetAllAsync<T>(string token);
        Task<T> GetAsync<T>(int id, string token);
        Task<T> CreateAsync<T>(VillaNumberCreateDTo dto, string token);
        Task<T> UpdateAsync<T>(VillaNumberUpdateDTo dto, string token);
        Task<T> DeleteAsync<T>(int id, string token);
    }
}
