using BB.PersonelYonetimTakipSistemi.Data.Context;
using BB.PersonelYonetimTakipSistemi.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Dal.Companies
{
    public interface ICompanyDal
    {
        void AddCompany(Company company);
        Task<Company> DeleteCompany(int id);
        void UpdateCompany(Company company, int id);
        Task<List<Company>> GetAllCompanies();
    }
    public class CompanyDal : ICompanyDal
    {
        private readonly ApplicationContext _applicationContext;

        public CompanyDal(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async void AddCompany(Company company)
        {
            try
            {
                using (ApplicationContext context = new ApplicationContext())
                {
                    var result = await context.AddAsync(company);
                    if (result.State == EntityState.Added)
                    {
                        await context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Company> DeleteCompany(int id)
        {
            try
            {
                var company = await _applicationContext.Companies.FirstOrDefaultAsync(i => i.ID == id);
                _applicationContext.Remove(company);
                await _applicationContext.SaveChangesAsync();
                return company;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Company>> GetAllCompanies()
        {
            try
            {
                var company = await _applicationContext.Companies.ToListAsync();
                return company;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async void UpdateCompany(Company company, int id)
        {
            try
            {
                using (ApplicationContext context = new ApplicationContext())
                {
                    var result = context.Update(company);
                    if (result.State == EntityState.Modified)
                    {
                        await context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
