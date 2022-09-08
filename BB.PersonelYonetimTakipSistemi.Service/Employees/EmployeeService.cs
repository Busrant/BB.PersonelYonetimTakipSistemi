using AutoMapper;
using BB.PersonelYonetimTakipSistemi.Dal.Employees;
using BB.PersonelYonetimTakipSistemi.Data.Model;
using BB.PersonelYonetimTakipSistemi.Helper.DataResult;
using BB.PersonelYonetimTakipSistemi.Model.AllEmployeeDTO;
using BB.PersonelYonetimTakipSistemi.Model.EmployeeDetailDTO;
using BB.PersonelYonetimTakipSistemi.Model.Employees;
using BB.PersonelYonetimTakipSistemi.Model.ReplaceEmployeeDTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Service.Employees
{
    public interface IEmployeeService
    {
        Task<IDataResult<EmployeeDto>> AddEmployee(EmployeeDto employee);
        Task<IDataResult<Employee>> DeleteEmployee(int id);
        Task<IDataResult<List<AllEmployeeDto>>> GetAllEmployee();
        Task<IDataResult<List<Employee>>> GetEmployeeDepartmentInfo();
        Task<IDataResult<EmployeeDto>> UpdateEmployee(EmployeeDto employeeDto, int id);
        Task<IDataResult<Employee>> GetRequestDayInfo(int employeeId);
        Task<IDataResult<EmployeeDetailDto>> GetEmployeeDetail(int employeeId);
        Task<IDataResult<List<ReplaceEmployeeDto>>> GetEmployeeForReplace(int departmentId, int branchId);
        Task<IDataResult<EmployeeDto>> UpdatePassword(string companyEmail, string password);
    }
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeesDal _employeeDal;
        private readonly IMapper _mapper;


        public EmployeeService(IEmployeesDal employeeDal, IMapper mapper)
        {
            _employeeDal = employeeDal;
            _mapper = mapper;
        }

        public async Task<IDataResult<EmployeeDto>> AddEmployee(EmployeeDto employeeDto)
        {
            try
            {
                var employee = _mapper.Map<Employee>(employeeDto);
                var result = _mapper.Map<EmployeeDto>(await _employeeDal.AddEmployee(employee));
                return new SuccessDataResult<EmployeeDto>(result);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<IDataResult<Employee>> DeleteEmployee(int id)
        {
            try
            {
                return new SuccessDataResult<Employee>(await _employeeDal.DeleteEmployee(id));
            }
            catch (System.Exception ex)
            {
                return new ErrorDataResult<Employee>(ex.Message);
            }
        }

        public async Task<IDataResult<List<AllEmployeeDto>>> GetAllEmployee()
        {
            try
            {
                return new SuccessDataResult<List<AllEmployeeDto>>(_employeeDal.GetAllEmployee());
            }
            catch (System.Exception ex)
            {
                return new ErrorDataResult<List<AllEmployeeDto>>(ex.Message);
            }
        }

        public async Task<IDataResult<List<Employee>>> GetEmployeeDepartmentInfo()
        {
            try
            {
                return new SuccessDataResult<List<Employee>>(await _employeeDal.GetEmployeeDepartmentInfo());
            }
            catch (System.Exception ex)
            {
                return new ErrorDataResult<List<Employee>>(ex.Message);
            }
        }



        public async Task<IDataResult<EmployeeDto>> UpdateEmployee(EmployeeDto employeeDto, int id)
        {
            try
            {
                var employee = _mapper.Map<Employee>(employeeDto);
                _employeeDal.UpdateEmployee(employee, id);
                return new SuccessDataResult<EmployeeDto>(employeeDto);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<IDataResult<Employee>> GetRequestDayInfo(int employeeId)
        {
            try
            {
                return new SuccessDataResult<Employee>(await _employeeDal.GetRequestDayInfo(employeeId));

            }
            catch (System.Exception ex)
            {
                return new ErrorDataResult<Employee>(ex.Message);
            }
        }

        public async Task<IDataResult<EmployeeDetailDto>> GetEmployeeDetail(int employeeId)
        {
            try
            {
                return new SuccessDataResult<EmployeeDetailDto>(await _employeeDal.GetEmployeeDetail(employeeId));
            }
            catch (System.Exception ex)
            {
                return new ErrorDataResult<EmployeeDetailDto>(ex.Message);
            }
        }

        public async Task<IDataResult<List<ReplaceEmployeeDto>>> GetEmployeeForReplace(int departmentId, int branchId)
        {
            try
            {
                return new SuccessDataResult<List<ReplaceEmployeeDto>>(await _employeeDal.GetEmployeeForReplace(departmentId, branchId));
            }
            catch (System.Exception ex)
            {
                return new ErrorDataResult<List<ReplaceEmployeeDto>>(ex.Message);
            }
        }

        public async Task<IDataResult<EmployeeDto>> UpdatePassword(string companyEmail, string password)
        {
            try
            {
                var employee = await _employeeDal.UpdatePassword(companyEmail, password);
                var employeeDto = _mapper.Map<EmployeeDto>(employee);
                return new SuccessDataResult<EmployeeDto>(employeeDto);
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }
    }
}
