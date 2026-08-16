using WebApplication1.Domain.Entities;

namespace WebApplication1.Domain.Interfaces
{
    public interface IEmployeeRepository : IGenericReadRepository<Employee>, IGenericWriteRepository<Employee>
    {

    }
}
