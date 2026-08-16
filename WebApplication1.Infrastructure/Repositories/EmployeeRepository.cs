using WebApplication1.Infrastructure.Data;
using WebApplication1.Domain.Interfaces;
using WebApplication1.Domain.Entities;

namespace WebApplication1.Infrastructure.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        private readonly AppDbContext _dbContext;
        public EmployeeRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
