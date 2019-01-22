﻿using InvocingApp.Data.Domains;
using InvoiceApp.Persistence.Repositories;
using InvoiceApp.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Persistence.Services
{
    public class CompanyService 
    {
        private IBaseRepository<InvoiceAppDbContext> _baseRepository;
        private IOtherRepository<InvoiceAppDbContext> _otherRepository;

        public CompanyService(IBaseRepository<InvoiceAppDbContext> baseRepository, IOtherRepository<InvoiceAppDbContext> otherRepository)
        {
            _baseRepository = baseRepository;
            _otherRepository = otherRepository;
        }

        public List<Company> GetAllCompany()
        {
            var listOfCompany = _baseRepository.Getall<Company>().Where(x => !x.IsDeleted && x.IsActive).ToList();
            return listOfCompany;
        }

        public Company GetCompanyById(long Id)
        {
            var companyresult = _baseRepository.GetById<Company>(Id);
            return companyresult;
        }

        public void PostCompany(Company company)
        {
            var existingCompany = GetAllCompany().FirstOrDefault(x => x.Email == company.Email && x.PhoneNumber == company.PhoneNumber);
            if (existingCompany != null)
            {
                existingCompany.Address = company.Address;
                existingCompany.CompanyName = company.CompanyName;
                existingCompany.Customers = company.Customers;
                existingCompany.Email = company.Email;
                existingCompany.PhoneNumber = company.PhoneNumber;
            }
                _baseRepository.Create(company);
        }

        public void BulkPostCompanies (IEnumerable<Company> companies)
        {
            foreach (Company comp in companies)
            {
                if (GetAllCompany().FirstOrDefault(x => x.Email == comp.Email && x.PhoneNumber == comp.PhoneNumber) != null)
                    companies = null;
            }
            _baseRepository.Create(companies);
        }

        public void UpdateCompanyObject(Company company)
        {
            if (company != null)
                _baseRepository.Update(company);
        }

        public void UpdateCompanyById (long Id)
        {
            _otherRepository.UpdateById<Company>(Id);            
        }
    }
}
