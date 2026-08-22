using WebApplication1.Application.EmployeeDtos;
using WebApplication1.Domain.Entities;

namespace WebApplication1.Application.Interfaces
{
    public interface IEmployeeService
    {
        List<EmployeeDto> GetAll();
        EmployeeDto? GetById(int id);
        Employee GetEntityById(int id);
        void Add(Employee employee);
        void Update(Employee employee);
        void Delete(Employee employee);
    }
}
