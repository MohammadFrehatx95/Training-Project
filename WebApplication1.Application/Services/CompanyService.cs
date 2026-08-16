using System;
using System.Collections.Generic;

using WebApplication1.Domain.Interfaces;
using WebApplication1.Domain.Entities;
using WebApplication1.Application.Interfaces;

namespace WebApplication1.Application.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public void Add(Company company)
        {
            _companyRepository.Add(company);
        }

        public void Delete(Company company)
        {
            _companyRepository.Delete(company);
        }

        public List<Company> GetAll()
        {
           return _companyRepository.GetAll();
        }

        public Company? GetById(int id)
        {
           var comp = _companyRepository.GetById(id);

            if (comp == null)
            {
                throw new Exception("Company not found");
            }

            return comp;
        }

        public void Update(Company company)
        {
            _companyRepository.Update(company);
        }
    }
}
