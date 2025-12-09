
using Microsoft.EntityFrameworkCore;

namespace UOW.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _applicationDbContext;
        protected readonly DbSet<T> _dbSet;
        public Repository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _dbSet = _applicationDbContext.Set<T>();
        }
        public Task AddAsync(T entity)
        {
            return _dbSet.AddAsync(entity).AsTask();
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            return Task.FromResult(_dbSet.AsEnumerable());
        }

        public Task<T?> GetByIdAsync(int id)
        {
            return _dbSet.FindAsync(id).AsTask();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
