using BB.PersonelYonetimTakipSistemi.Data.Context;
using BB.PersonelYonetimTakipSistemi.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Dal.PermissionTypes
{
    public interface IPermissionTypeDal
    {
        void AddPermissionType(PermissionType permissionType);
        Task<PermissionType> DeletePermissionType(int id);
        void UpdatePermissionType(PermissionType permissionType, int id);
        Task<List<PermissionType>> GetAllPermissionTypes();
    }
    public class PermissionTypeDal : IPermissionTypeDal
    {
        private readonly ApplicationContext _applicationContext;

        public PermissionTypeDal(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async void AddPermissionType(PermissionType permissionType)
        {
            try
            {
                using (ApplicationContext context = new ApplicationContext())
                {
                    var result = await context.AddAsync(permissionType);
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

        public async Task<PermissionType> DeletePermissionType(int id)
        {
            try
            {
                var permissionType = await _applicationContext.PermissionTypes.FirstOrDefaultAsync(i => i.ID == id);
                _applicationContext.Remove(permissionType);
                await _applicationContext.SaveChangesAsync();
                return permissionType;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<PermissionType>> GetAllPermissionTypes()
        {
            try
            {
                var permissionType = await _applicationContext.PermissionTypes.ToListAsync();
                return permissionType;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async void UpdatePermissionType(PermissionType permissionType, int id)
        {
            try
            {
                using (ApplicationContext context = new ApplicationContext())
                {
                    var result = context.Update(permissionType);
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
