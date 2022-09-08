using BB.PersonelYonetimTakipSistemi.Data.Context;
using BB.PersonelYonetimTakipSistemi.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Dal.WorkTypes
{
    public interface IWorkTypeDal
    {
        void AddWorkType(WorkType workType);
        Task<WorkType> DeleteWorkType(int id);
        void UpdateWorkType(WorkType workType, int id);
        Task<List<WorkType>> GetAllWorkTypes();
    }
    public class WorkTypeDal : IWorkTypeDal
    {
        private readonly ApplicationContext _applicationContext;

        public WorkTypeDal(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async void AddWorkType(WorkType workType)
        {
            try
            {
                using (ApplicationContext context = new ApplicationContext())
                {
                    var result = await context.AddAsync(workType);
                    if (result.State==EntityState.Added)
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

        public async Task<WorkType> DeleteWorkType(int id)
        {
            try
            {
                var workType = await _applicationContext.WorkTypes.FirstOrDefaultAsync(i=>i.ID == id);
                _applicationContext.Remove(workType);
                await _applicationContext.SaveChangesAsync();
                return workType;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<WorkType>> GetAllWorkTypes()
        {
            try
            {
                var workType = await _applicationContext.WorkTypes.ToListAsync();
                return workType;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async void UpdateWorkType(WorkType workType, int id)
        {
            try
            {
                using (ApplicationContext context = new ApplicationContext())
                {
                    var result = context.Update(workType);
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
