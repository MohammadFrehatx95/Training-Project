using WebApplication1.Domain.Entities;

namespace WebApplication1.Application.Interfaces
{
    public interface IDepartmentService
    {
        List<Department> GetAll();
        Department? GetById(int id);
        void Add(Department dept);
        void Update(Department dept);
        void Delete(Department dept);
    }
}
