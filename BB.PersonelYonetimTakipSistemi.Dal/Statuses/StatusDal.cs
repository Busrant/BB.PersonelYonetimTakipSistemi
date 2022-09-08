using BB.PersonelYonetimTakipSistemi.Data.Context;
using BB.PersonelYonetimTakipSistemi.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Dal.Statuses
{
    public interface IStatusDal
    {
        void AddStatus(Status status);
        Task<Status> DeleteStatus(int id);
        void UpdateStatus(Status status, int id);
        Task<List<Status>> GetStatuses();
    }
    public class StatusDal : IStatusDal
    {
        private readonly ApplicationContext _applicationContext;

        public StatusDal(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async void AddStatus(Status status)
        {
            try
            {
                using (ApplicationContext context = new ApplicationContext())
                {
                    var result = await context.AddAsync(status);
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

        public async Task<Status> DeleteStatus(int id)
        {
            try
            {
                var status = await _applicationContext.Statuses.FirstOrDefaultAsync(i => i.ID == id);
                _applicationContext.Remove(status);
                await _applicationContext.SaveChangesAsync();
                return status;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Status>> GetStatuses()
        {
            try
            {
                var status = await _applicationContext.Statuses.ToListAsync();
                return status;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async void UpdateStatus(Status status, int id)
        {
            try
            {
                using (ApplicationContext context = new ApplicationContext())
                {
                    var result = context.Update(status);
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
