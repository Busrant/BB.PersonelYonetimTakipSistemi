using AutoMapper;
using BB.PersonelYonetimTakipSistemi.Dal.Departments;
using BB.PersonelYonetimTakipSistemi.Data.Model;
using BB.PersonelYonetimTakipSistemi.Helper.DataResult;
using BB.PersonelYonetimTakipSistemi.Model.DepartmentInfoDTO;
using BB.PersonelYonetimTakipSistemi.Model.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Service.Departments
{
    public interface IDepartmentsService
    {
        Task<IDataResult<List<Department>>> GetAllDepartmentEmployees();
        Task<IDataResult<List<Department>>> GetAllDepartmentsInCompany(int companyId);
        Task<IDataResult<List<DepartmentInfoDto>>> GetDepartmentInfos();
        Task<IDataResult<DepartmentDto>> AddDepartment(DepartmentDto departmentDto);
    }

    public class DepartmentService : IDepartmentsService
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentDal _departmentDal;

        public DepartmentService(IDepartmentDal departmentDal, IMapper mapper)
        {
            _mapper = mapper;
            _departmentDal = departmentDal;
        }

        public async Task<IDataResult<DepartmentDto>> AddDepartment(DepartmentDto departmentDto)
        {
            try
            {
                var dep = _mapper.Map<Department>(departmentDto);
                _departmentDal.AddDepartment(dep);
                return new SuccessDataResult<DepartmentDto>(departmentDto);
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IDataResult<List<Department>>> GetAllDepartmentEmployees()
        {
            try
            {
                return new SuccessDataResult<List<Department>>(await _departmentDal.GetAllDepartmentEmployees());
            }
            catch (System.Exception ex)
            {
                return new ErrorDataResult<List<Department>>(ex.Message);
            }
        }

        public async Task<IDataResult<List<Department>>> GetAllDepartmentsInCompany(int companyId)
        {
            try
            {
                return new SuccessDataResult<List<Department>>(await _departmentDal.GetAllDepartmentsInCompany(companyId));
            }
            catch (System.Exception ex)
            {
                return new ErrorDataResult<List<Department>>(ex.Message);
            }
        }

        public async Task<IDataResult<List<DepartmentInfoDto>>> GetDepartmentInfos()
        {
            try
            {
                return new SuccessDataResult<List<DepartmentInfoDto>>(_departmentDal.GetDepartmentInfos());
            }
            catch (System.Exception ex)
            {
                return new ErrorDataResult<List<DepartmentInfoDto>>(ex.Message);
            }
        }
    }
}
