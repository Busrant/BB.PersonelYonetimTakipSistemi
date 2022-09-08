using BB.PersonelYonetimTakipSistemi.Data.Context;
using BB.PersonelYonetimTakipSistemi.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Dal.PermissionSummaries
{
    public interface IPermissionSummaryDal
    {
        void AddPermissionSummary(PermissionSummary permissionSummary);
        Task<PermissionSummary> DeletePermissionSummary(int id);
        void UpdatePermissionSummary(PermissionSummary permissionSummary, int id);
        Task<List<PermissionSummary>> GetAllPermissionSummaries();
        Task<PermissionSummary> GetPermissionByEmployeeId(int employeeId);
    }
    public class PermissionSummaryDal:IPermissionSummaryDal
    {
        private readonly ApplicationContext _applicationContext;

        public PermissionSummaryDal(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async void AddPermissionSummary(PermissionSummary permissionSummary)
        {
            try
            {
                using (ApplicationContext context = new ApplicationContext())
                {
                    var result = await context.AddAsync(permissionSummary);
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

        public async Task<PermissionSummary> DeletePermissionSummary(int id)
        {
            try
            {
                var permissionSummary = await _applicationContext.PermissionSummaries.FirstOrDefaultAsync(i=>i.ID == id);
                _applicationContext.Remove(permissionSummary);
                await _applicationContext.SaveChangesAsync();
                return permissionSummary;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<PermissionSummary>> GetAllPermissionSummaries()
        {
            try
            {
                var permissionSummary = await _applicationContext.PermissionSummaries.ToListAsync();
                return permissionSummary;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async void UpdatePermissionSummary(PermissionSummary permissionSummary, int id)
        {
            try
            {
                using (ApplicationContext context = new ApplicationContext())
                {
                    var result = context.Update(permissionSummary);
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

        public async Task<PermissionSummary> GetPermissionByEmployeeId(int employeeId)
        {
            try
            {
                var per = await _applicationContext.PermissionSummaries.Where(i => i.EmployeeId == employeeId).OrderByDescending(i=>i.ID).FirstOrDefaultAsync();
                return per;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
