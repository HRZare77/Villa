using Villa.Repository.IRepository;
using System.Linq.Expressions;
using Villa.Data;
using Microsoft.EntityFrameworkCore;

namespace Villa.Repository
{
    public class VillaNumberRepository : Repository<Models.VillaNumber>, IVillaNumberRepository
    {
        private readonly ApplicationDbContext _db;
        public VillaNumberRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }
        
        public async Task<Models.VillaNumber> UpdateAsync(Models.VillaNumber entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _db.VillaNumbers.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
