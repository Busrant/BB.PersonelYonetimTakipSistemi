using BB.PersonelYonetimTakipSistemi.Data.Context;
using BB.PersonelYonetimTakipSistemi.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Dal.RequestTypes
{
    public interface IRequestTypeDal
    {
        void AddRequestType(RequestType requestType);
        Task<RequestType> DeleteRequestType(int id);
        void UpdateRequestType(RequestType requestType, int id);
        Task<List<RequestType>> GetAllRequestType();
    }
    public class RequestTypeDal:IRequestTypeDal
    {
        private readonly ApplicationContext _applicationContext;

        public RequestTypeDal(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async void AddRequestType(RequestType requestType)
        {
            try
            {
                using (ApplicationContext context = new ApplicationContext())
                {
                    var result = await context.AddAsync(requestType);
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

        public async Task<RequestType> DeleteRequestType(int id)
        {
            try
            {
                var requestType = await _applicationContext.RequestTypes.FirstOrDefaultAsync(i=>i.ID==id);
                _applicationContext.Remove(requestType);
                await _applicationContext.SaveChangesAsync();
                return requestType;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<RequestType>> GetAllRequestType()
        {
            try
            {
                var requestType = await _applicationContext.RequestTypes.ToListAsync();
                return requestType;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async void UpdateRequestType(RequestType requestType, int id)
        {
            try
            {
                using (ApplicationContext context = new ApplicationContext())
                {
                    var result = context.Update(requestType);
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
