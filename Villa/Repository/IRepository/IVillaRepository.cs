using System.Linq.Expressions;

namespace Villa.Repository.IRepository
{
    public interface IVillaRepository:IRepository<Models.Villa>
    {
        Task<Models.Villa> UpdateAsync(Models.Villa entity);
    }
}
