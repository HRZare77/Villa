using System.Linq.Expressions;

namespace Villa.Repository.IRepository
{
    public interface IVillaNumberRepository : IRepository<Models.VillaNumber>
    {
        Task<Models.VillaNumber> UpdateAsync(Models.VillaNumber entity);
    }
}
