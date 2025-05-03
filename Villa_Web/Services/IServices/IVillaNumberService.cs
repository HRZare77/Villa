using Villa_Web.Models.Dto;

namespace Villa_Web.Services.IServices
{
    public interface IVillaNumberService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(VillaNumberCreateDTo dto);
        Task<T> UpdateAsync<T>(VillaNumberUpdateDTo dto);
        Task<T> DeleteAsync<T>(int id);
    }
}
