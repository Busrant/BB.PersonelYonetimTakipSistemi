using BB.PersonelYonetimTakipSistemi.Data.Context;
using BB.PersonelYonetimTakipSistemi.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Dal.Branches
{
    public interface IBranchDal
    {
        void AddBranch(Branch branch);
        Task<Branch> DeleteBranch(int id);
        void UpdateBranch(Branch branch, int id);
        Task<List<Branch>> GetAllBranches();
        Task<List<Branch>> GetAllCompanyBranches(int companyId);
        Task<List<Branch>> GetBranchCompany();

    }
    public class BranchDal : IBranchDal
    {
        private readonly ApplicationContext _applicationContext;

        public BranchDal(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async void AddBranch(Branch branch)
        {
            try
            {
                using (ApplicationContext context = new ApplicationContext())
                {
                    var result = await context.AddAsync(branch);
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

        public async Task<Branch> DeleteBranch(int id)
        {
            try
            {
                var branch = await _applicationContext.Branches.FirstOrDefaultAsync(i => i.ID == id);
                _applicationContext.Remove(branch);
                await _applicationContext.SaveChangesAsync();
                return branch;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Branch>> GetAllBranches()
        {
            try
            {
                var branch = await _applicationContext.Branches.ToListAsync();
                return branch;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Branch>> GetAllCompanyBranches(int companyId)
        {
            try
            {
                var req = await _applicationContext.Branches.Where(i => i.CompanyId == companyId && i.IsActive == true).ToListAsync();
                return req;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Branch>> GetBranchCompany()
        {
            try
            {
                var res = await _applicationContext.Branches.ToListAsync();
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async void UpdateBranch(Branch branch, int id)
        {
            try
            {
                using (ApplicationContext context = new ApplicationContext())
                {
                    var result = context.Update(branch);
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
