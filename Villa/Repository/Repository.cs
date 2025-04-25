using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;
using Villa.Data;
using Villa.Repository.IRepository;

namespace Villa.Repository
{
    public class Repository<T>:IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        private readonly DbSet<T> _dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            _dbSet = db.Set<T>();
        }
        public async Task CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await SaveAsync();
        }
        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = _dbSet;
            if (filter != null)
                query = query.Where(filter);

            return await query.ToListAsync();
        }
        public async Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true)
        {
            IQueryable<T> query = _dbSet;
            if (!tracked)
                query = query.AsNoTracking();
            if (filter != null)
                query = query.Where(filter);

            return await query.FirstOrDefaultAsync();
        }
        public async Task RemoveAsync(T entity)
        {
            _dbSet.Remove(entity);
            await SaveAsync();
        }
        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await SaveAsync();
        }
    }
}
