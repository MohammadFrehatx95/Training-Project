using WebApplication1.Infrastructure.Data;
using WebApplication1.Domain.Interfaces;
using WebApplication1.Domain.Entities;

namespace WebApplication1.Infrastructure.Repositories
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        private readonly AppDbContext _dbContext;

        public DepartmentRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
