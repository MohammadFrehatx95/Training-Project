using WebApplication1.Domain.Entities;

namespace WebApplication1.Domain.Interfaces
{
    public interface IDepartmentRepository : IGenericReadRepository<Department>, IGenericWriteRepository<Department>
    {

    }
}
