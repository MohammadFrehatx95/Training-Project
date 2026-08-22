using WebApplication1.Application.EmployeeDtos;
using WebApplication1.Application.Interfaces;
using WebApplication1.Domain.Entities;
using WebApplication1.Domain.Interfaces;

namespace WebApplication1.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public List<EmployeeDto> GetAll()
        {
            var employees = _employeeRepository.GetAll();

            return employees.Select(emp => new EmployeeDto
            {
                Id = emp.Id,
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                Email = emp.Email,
                Phone = emp.Phone,
                Salary = emp.Salary,
                HireDate = emp.HireDate,
                Gender = emp.Gender,
                Position = emp.Position,
                IsAction = emp.IsAction,
                DepartmentId = emp.DepartmentId,
                ManagerId = emp.ManagerId
            }).ToList();
        }

        public EmployeeDto? GetById(int id)
        {
            var emp = _employeeRepository.GetById(id);

            if (emp == null)
                throw new Exception("Employee Not Found");

            return new EmployeeDto
            {
                Id = emp.Id,
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                Email = emp.Email,
                Phone = emp.Phone,
                Salary = emp.Salary,
                HireDate = emp.HireDate,
                Gender = emp.Gender,
                Position = emp.Position,
                IsAction = emp.IsAction,
                DepartmentId = emp.DepartmentId,
                ManagerId = emp.ManagerId
            };
        }
        public Employee GetEntityById(int id)
        {
            var emp = _employeeRepository.GetById(id);

            if (emp == null)
                throw new Exception("Employee Not Found");

            return emp;
        }
        public void Add(Employee employee)
        {
            _employeeRepository.Add(employee);
        }

        public void Update(Employee employee)
        {
            _employeeRepository.Update(employee);
        }

        public void Delete(Employee employee)
        {
            _employeeRepository.Delete(employee);
        }
    }
}