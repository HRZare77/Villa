using Villa.Repository.IRepository;
using System.Linq.Expressions;
using Villa.Data;
using Microsoft.EntityFrameworkCore;

namespace Villa.Repository
{
    public class VillaRepository: IVillaRepository
    {
        private readonly ApplicationDbContext _db;
        public VillaRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task CreateAsync(Models.Villa entity)
        {
           await _db.Villas.AddAsync(entity);
            await SaveAsync();
        } 
        public async Task<IEnumerable<Models.Villa>> GetAllAsync(Expression<Func<Models.Villa, bool>>? filter = null)
        {
            IQueryable<Models.Villa> query = _db.Villas;
            if (filter != null)
              query= query.Where(filter);

            return await query.ToListAsync();
        }
        public async Task<Models.Villa> GetAsync(Expression<Func<Models.Villa, bool>> filter = null, bool tracked=true)
        {
            IQueryable<Models.Villa> query = _db.Villas;
            if (!tracked)
                query = query.AsNoTracking();
            if (filter != null)
                query = query.Where(filter);

            return await query.FirstOrDefaultAsync();
        } 
        public async Task RemoveAsync(Models.Villa entity)
        {
            _db.Villas.Remove(entity);
            await SaveAsync();
        }
        public async Task SaveAsync()
        {
             await _db.SaveChangesAsync();
        }
        public async Task UpdateAsync(Models.Villa entity)
        {
            _db.Villas.Update(entity);
            await SaveAsync();
        }
    }
}
