using System;
using System.Collections.Generic;

using WebApplication1.Domain.Interfaces;
using WebApplication1.Domain.Entities;
using WebApplication1.Application.Interfaces;

namespace WebApplication1.Application.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public void Add(Department dept)
        {
            _departmentRepository.Add(dept);
        }

        public void Delete(Department dept)
        {
            _departmentRepository.Delete(dept);
        }

        public List<Department> GetAll()
        {
            return _departmentRepository.GetAll();
        }

        public Department? GetById(int id)
        {
            var dept = _departmentRepository.GetById(id);

            if (dept == null)
            {
                throw new Exception("Department not found");
            }

            return dept;
        }

        public void Update(Department dept)
        {
            _departmentRepository.Update(dept);
        }
    }
}