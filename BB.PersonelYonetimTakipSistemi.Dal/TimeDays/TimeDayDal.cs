using BB.PersonelYonetimTakipSistemi.Data.Context;
using BB.PersonelYonetimTakipSistemi.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Dal.TimeDays
{
    public interface ITimeDayDal
    {
        void AddTimeDay(TimeDay timeDay);
        Task<TimeDay> DeleteTimeDay(int id);
        void UpdateTimeDay(TimeDay timeDay, int id);
        Task<List<TimeDay>> GetAllTimeDay();
        Task<List<TimeDay>> GetAllDayOffs(DateTime startDate, DateTime endDate);
    }
    public class TimeDayDal:ITimeDayDal
    {
        private readonly ApplicationContext _applicationContext;

        public TimeDayDal(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async void AddTimeDay(TimeDay timeDay)
        {
            try
            {
                using (ApplicationContext context = new ApplicationContext())
                {
                    var result = await context.AddAsync(timeDay);
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

        public async Task<TimeDay> DeleteTimeDay(int id)
        {
            try
            {
                var timeDay = await _applicationContext.TimeDays.FirstOrDefaultAsync(i => i.ID == id);
                _applicationContext.Remove(timeDay);
                await _applicationContext.SaveChangesAsync();
                return timeDay;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<TimeDay>> GetAllDayOffs(DateTime startDate, DateTime endDate)
        {
            try
            {
                var days = await _applicationContext.TimeDays.Where(i => i.TimeValue >= startDate && i.TimeValue <= endDate && i.TimeDayTypeId == 8).ToListAsync();
                return days;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<TimeDay>> GetAllTimeDay()
        {
            try
            {
                var timeDay = await _applicationContext.TimeDays.ToListAsync();
                return timeDay;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async void UpdateTimeDay(TimeDay timeDay, int id)
        {
            try
            {
                using (ApplicationContext context = new ApplicationContext())
                {
                    var result = context.Update(timeDay);
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
