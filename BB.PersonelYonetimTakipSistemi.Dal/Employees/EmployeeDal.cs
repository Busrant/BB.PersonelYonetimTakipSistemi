using BB.PersonelYonetimTakipSistemi.Dal.Base;
using BB.PersonelYonetimTakipSistemi.Data.Context;
using BB.PersonelYonetimTakipSistemi.Data.Model;
using BB.PersonelYonetimTakipSistemi.Model.AllEmployeeDTO;
using BB.PersonelYonetimTakipSistemi.Model.EmployeeDetailDTO;
using BB.PersonelYonetimTakipSistemi.Model.ReplaceEmployeeDTO;
using BB.PersonelYonetimTakipSistemi.Model.TeamLeadersDTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Dal.Employees
{
    public interface IEmployeesDal
    {
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee> DeleteEmployee(int id);
        void UpdateEmployee(Employee employee, int id);
        List<AllEmployeeDto> GetAllEmployee();
        Task<List<Employee>> GetEmployeeDepartmentInfo();
        Task<Employee> GetRequestDayInfo(int employeeId);
        Task<EmployeeDetailDto> GetEmployeeDetail(int employeeId);
        Task<List<ReplaceEmployeeDto>> GetEmployeeForReplace(int departmentId, int branchId);
        Task<Employee> UpdatePassword(string companyEmail, string password);
    }

    public class EmployeeDal : BaseDal, IEmployeesDal
    {
        private readonly ApplicationContext _applicationContext;
        public EmployeeDal(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public async Task<Employee> AddEmployee(Employee employee)
        {
            try
            {
                using (ApplicationContext context = new ApplicationContext())
                {
                    var result = await context.AddAsync(employee);
                    if (result.State == EntityState.Added)
                    {
                        await context.SaveChangesAsync();
                        var addedEmployee = await context.Employees.Where(i => i == employee).FirstAsync();
                        return addedEmployee;
                    }
                    return null;

                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<Employee> DeleteEmployee(int id)
        {
            try
            {
                var employee = await _applicationContext.Employees.FirstOrDefaultAsync(x => x.ID == id);
                _applicationContext.Remove(employee);
                await _applicationContext.SaveChangesAsync();
                return employee;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<AllEmployeeDto> GetAllEmployee()
        {
            try
            {
                var employee = from E in _applicationContext.Employees
                               join U in _applicationContext.Users on E.UserId equals U.ID
                               join C in _applicationContext.Careers on E.ID equals C.EmployeeId
                               join D in _applicationContext.Departments on C.DepartmentId equals D.ID
                               join S in _applicationContext.Statuses on C.StatusId equals S.ID
                               where C.IsActive == true && E.IsActive == true && D.IsActive == true
                               orderby U.Name 
                               select new AllEmployeeDto { Career = C, Department = D, Employee = E, Status = S, User = U };
                return employee.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async void UpdateEmployee(Employee employee, int id)
        {
            try
            {
                using (ApplicationContext context = new ApplicationContext())
                {
                    var result = context.Update(employee);
                    if (result.State == EntityState.Modified)
                    {
                        await context.SaveChangesAsync();
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Employee>> GetEmployeeDepartmentInfo()
        {
            try
            {
                var result = await _applicationContext.Employees.Where(i => i.IsActive == true).ToListAsync();
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<EmployeeDetailDto> GetEmployeeDetail(int employeeId)
        {
            try
            {
                var result = from E in _applicationContext.Employees
                             join U in _applicationContext.Users on E.UserId equals U.ID
                             join C in _applicationContext.Careers on E.ID equals C.EmployeeId
                             join D in _applicationContext.Departments on C.DepartmentId equals D.ID
                             join S in _applicationContext.Statuses on C.StatusId equals S.ID
                             join Co in _applicationContext.Companies on D.CompanyId equals Co.ID
                             join W in _applicationContext.WorkTypes on C.WorkTypeId equals W.ID
                             where E.ID == employeeId
                             select new EmployeeDetailDto { Employee = E, User = U, Career = C, Department = D, Status = S, Company = Co, WorkType = W };
                return result.FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Employee> UpdatePassword(string companyEmail, string password)
        {
            try
            {
                Employee result = await (from E in _applicationContext.Employees
                                         join U in _applicationContext.Users on E.UserId equals U.ID
                                         where E.CompanyEmail == companyEmail
                                         select E).FirstOrDefaultAsync();
                var pss = ToMD5(password);
                result.Password = pss;
                _applicationContext.SaveChanges();
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }


        public async Task<Employee> GetRequestDayInfo(int employeeId)
        {
            try
            {
                var result = await _applicationContext.Employees.FirstOrDefaultAsync(i => i.ID == employeeId);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<ReplaceEmployeeDto>> GetEmployeeForReplace(int departmentId, int branchId)
        {
            try
            {
                var result = from E in _applicationContext.Employees
                             join U in _applicationContext.Users on E.UserId equals U.ID
                             join C in _applicationContext.Careers on E.ID equals C.EmployeeId
                             where C.DepartmentId == departmentId && C.BranchId == branchId
                             select new ReplaceEmployeeDto { Employee = E, User = U, Career = C };
                return result.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
