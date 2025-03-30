using Microsoft.EntityFrameworkCore;

namespace ExpenseSolution.Repositories
{
    public class GenericRepository<T>(AppDbContext context) : IGenericRepository<T> where T:class
    {
        protected readonly AppDbContext _context = context;
        protected readonly DbSet<T> _dbSet = context.Set<T>();
        public async Task<T> Create(T entity)
        {
            var e = await _dbSet.AddAsync(entity);
            _context.SaveChanges();
            return e.Entity;
        }

        public async Task Delete(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<T> GetById(int id)
        {
            var entity = await _dbSet.FindAsync(id);

            if (entity == null)
            {
                throw new Exception("Entity not found for this id");
            }

            return entity;
        }

        public async Task<List<T>> GetAll()
        {
            var result = await _dbSet.ToListAsync();

            return result;
        }
    }
}
