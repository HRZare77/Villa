using System.Linq.Expressions;

namespace Villa.Repository.IRepository
{
    public interface IVillaRepository
    {
        Task<IEnumerable<Models.Villa>> GetAllAsync(Expression<Func<Models.Villa, bool>>? filter = null);
        Task<Models.Villa> GetAsync(Expression<Func<Models.Villa, bool>> filter = null, bool tracked=true);
        Task CreateAsync(Models.Villa entity);
        Task RemoveAsync(Models.Villa entity);
        Task SaveAsync();
        Task UpdateAsync(Models.Villa entity);
    }
}
