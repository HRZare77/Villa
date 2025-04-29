using Villa_Web.Models.Dto;

namespace Villa_Web.Services.IServices
{
    public interface IVillaService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(VillaCreateDTo dto);
        Task<T> UpdateAsync<T>(VillaUpdateDTo dto);
        Task<T> DeleteAsync<T>(int id);
    }
}
