using WebApplication1.Infrastructure.Data;
using WebApplication1.Domain.Interfaces;

namespace WebApplication1.Infrastructure.Repositories
{
    public class GenericReadRepository<T> : IGenericReadRepository<T>
        where T : class
    {
        private readonly AppDbContext _dbContext;

        public GenericReadRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public T? GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }
    }
}