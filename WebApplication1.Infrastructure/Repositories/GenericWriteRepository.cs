using WebApplication1.Infrastructure.Data;
using WebApplication1.Domain.Interfaces;

namespace WebApplication1.Infrastructure.Repositories
{
    public class GenericWriteRepository<T> : IGenericWriteRepository<T>
        where T : class
    {
        private readonly AppDbContext _dbContext;

        public GenericWriteRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            _dbContext.SaveChanges();
        }
    }
}