using Villa.Repository.IRepository;
using System.Linq.Expressions;
using Villa.Data;
using Microsoft.EntityFrameworkCore;

namespace Villa.Repository
{
    public class VillaRepository:Repository<Models.Villa>, IVillaRepository
    {
        private readonly ApplicationDbContext _db;
        public VillaRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }
        
        public async Task<Models.Villa> UpdateAsync(Models.Villa entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _db.Villas.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
