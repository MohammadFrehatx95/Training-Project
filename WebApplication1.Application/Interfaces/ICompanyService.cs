using WebApplication1.Domain.Entities;

namespace WebApplication1.Application.Interfaces
{
    public interface ICompanyService
    {
        List<Company> GetAll();
        Company? GetById(int id);
        void Add(Company company);
        void Update(Company company);
        void Delete(Company company);
    }
}
