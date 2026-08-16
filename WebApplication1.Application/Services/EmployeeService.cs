using System;
using System.Collections.Generic;

using WebApplication1.Domain.Interfaces;
using WebApplication1.Domain.Entities;
using WebApplication1.Application.Interfaces;

namespace WebApplication1.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public List<Employee> GetAll()
        {
            return _employeeRepository.GetAll();
        }

        public Employee? GetById(int id)
        {
            var emp =  _employeeRepository.GetById(id);

            if (emp == null)
            {
                throw new Exception("Employee Not Found");
            }

            return emp;
        }

        public void Add(Employee emp)
        {
            _employeeRepository.Add(emp);
        }

        public void Delete(Employee emp)
        {
            _employeeRepository.Delete(emp);
        }

        public void Update(Employee emp)
        {
            _employeeRepository.Update(emp);
        }
    }
}
