using WebApplication1.Domain.Entities;

namespace WebApplication1.Domain.Interfaces
{
    public interface ICompanyRepository : IGenericReadRepository<Company>, IGenericWriteRepository<Company>
    {
    }
}
