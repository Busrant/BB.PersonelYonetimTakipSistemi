using BB.PersonelYonetimTakipSistemi.Data.Context;
using BB.PersonelYonetimTakipSistemi.Data.Model;
using BB.PersonelYonetimTakipSistemi.Model.DepartmentInfoDTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Dal.Departments
{
    public interface IDepartmentDal
    {
        Task<List<Department>> GetAllDepartmentEmployees();
        Task<List<Department>> GetAllDepartmentsInCompany(int companyId);
        List<DepartmentInfoDto> GetDepartmentInfos();
        void AddDepartment(Department department);
    }

    public class DepartmentDal : IDepartmentDal
    {
        public readonly ApplicationContext _applicationContext;

        public DepartmentDal(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async void AddDepartment(Department department)
        {
            try
            {
                using (ApplicationContext context = new ApplicationContext())
                {
                    var result = await context.AddAsync(department);
                    if (result.State == EntityState.Added)
                    {
                        await context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<Department>> GetAllDepartmentEmployees()
        {
            try
            {
                var request = await _applicationContext.Departments.ToListAsync();
                return request;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Department>> GetAllDepartmentsInCompany(int companyId)
        {
            try
            {
                var request = await _applicationContext.Departments.Where(i => i.CompanyId == companyId && i.IsActive == true).ToListAsync();
                return request;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<DepartmentInfoDto> GetDepartmentInfos()
        {
            try
            {
                var request = from C in _applicationContext.Careers
                join Dep in _applicationContext.Departments on C.DepartmentId equals Dep.ID
                group C by Dep.Name into deparment
                select new DepartmentInfoDto { Text = deparment.Key, Value = deparment.Count() };



                return request.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
