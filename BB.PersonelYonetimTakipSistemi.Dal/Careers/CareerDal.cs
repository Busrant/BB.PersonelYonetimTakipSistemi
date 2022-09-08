using BB.PersonelYonetimTakipSistemi.Data.Context;
using BB.PersonelYonetimTakipSistemi.Data.Model;
using BB.PersonelYonetimTakipSistemi.Model.EmployeeCareerDTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Dal.Careers
{
    public interface ICareerDal
    {
        void AddCareer(Career career);
        Task<Career> DeleteCareer(int id);
        void UpdateCareer(Career career, int id);
        Task<List<Career>> GetAllCareers();
        List<EmployeeCareerDto> GetEmployeeCareer(int employeeId);
    }
    public class CareerDal : ICareerDal
    {
        private readonly ApplicationContext _applicationContext;

        public CareerDal(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async void AddCareer(Career career)
        {
            try
            {
                using (ApplicationContext context = new ApplicationContext())
                {
                    var result = await context.AddAsync(career);
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

        public async Task<Career> DeleteCareer(int id)
        {
            try
            {
                var career = await _applicationContext.Careers.FirstOrDefaultAsync(i => i.ID==id);
                _applicationContext.Remove(career);
                await _applicationContext.SaveChangesAsync();
                return career;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Career>> GetAllCareers()
        {
            try
            {
                var career = await _applicationContext.Careers.ToListAsync();
                return career;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public  List<EmployeeCareerDto> GetEmployeeCareer(int employeeId)
        {
            try
            {
                var careers = from C in _applicationContext.Careers
                              join B in _applicationContext.Branches on C.BranchId equals B.ID
                              join D in _applicationContext.Departments on C.DepartmentId equals D.ID
                              join S in _applicationContext.Statuses on C.StatusId equals S.ID
                              join W in _applicationContext.WorkTypes on C.WorkTypeId equals W.ID
                              join Co in _applicationContext.Companies on D.CompanyId equals Co.ID
                              where C.EmployeeId == employeeId
                              select new EmployeeCareerDto {Career=C,Branch=B,Department=D,Status=S,WorkType=W, Company=Co};
                return careers.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async void UpdateCareer(Career career, int id)
        {
            try
            {
                using (ApplicationContext context = new ApplicationContext())
                {
                    var result = context.Update(career);
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
