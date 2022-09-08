using AutoMapper;
using BB.PersonelYonetimTakipSistemi.Dal.PermissionSummaries;
using BB.PersonelYonetimTakipSistemi.Data.Model;
using BB.PersonelYonetimTakipSistemi.Helper.DataResult;
using BB.PersonelYonetimTakipSistemi.Model.PermissionSummaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Service.PermissionSummaries
{
    public interface IPermissionSummaryService
    {
        Task<IDataResult<PermissionSummaryDto>> AddPermissionSummary(PermissionSummaryDto permissionSummaryDto);
        Task<IDataResult<PermissionSummaryDto>> UpdatePermissionSummary(PermissionSummaryDto permissionSummaryDto, int id);
        Task<IDataResult<PermissionSummary>> DeletePermissionSummary(int id);
        Task<IDataResult<List<PermissionSummary>>> GetAllPermissionSummary();
        Task<IDataResult<PermissionSummary>> GetPermissionByEmployeeId(int employeeId);
    }
    public class PermissionSummaryService : IPermissionSummaryService
    {
        private readonly IPermissionSummaryDal _permissionSummaryDal;
        private readonly IMapper _mapper;

        public PermissionSummaryService(IPermissionSummaryDal permissionSummaryDal, IMapper mapper)
        {
            _permissionSummaryDal = permissionSummaryDal;
            _mapper = mapper;
        }

        public async Task<IDataResult<PermissionSummaryDto>> AddPermissionSummary(PermissionSummaryDto permissionSummaryDto)
        {
            try
            {
                var permissionSummary = _mapper.Map<PermissionSummary>(permissionSummaryDto);
                _permissionSummaryDal.AddPermissionSummary(permissionSummary);
                return new SuccessDataResult<PermissionSummaryDto>(permissionSummaryDto);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<IDataResult<PermissionSummary>> DeletePermissionSummary(int id)
        {
            try
            {
                return new SuccessDataResult<PermissionSummary>(await _permissionSummaryDal.DeletePermissionSummary(id));
            }
            catch (System.Exception ex)
            {
                return new ErrorDataResult<PermissionSummary>(ex.Message);
            }
        }

        public async Task<IDataResult<List<PermissionSummary>>> GetAllPermissionSummary()
        {
            try
            {
                return new SuccessDataResult<List<PermissionSummary>>(await _permissionSummaryDal.GetAllPermissionSummaries());
            }
            catch (System.Exception ex)
            {
                return new ErrorDataResult<List<PermissionSummary>>(ex.Message);
            }
        }

        public async Task<IDataResult<PermissionSummary>> GetPermissionByEmployeeId(int employeeId)
        {
            return new SuccessDataResult<PermissionSummary>(await _permissionSummaryDal.GetPermissionByEmployeeId(employeeId));
        }

        public async Task<IDataResult<PermissionSummaryDto>> UpdatePermissionSummary(PermissionSummaryDto permissionSummaryDto, int id)
        {
            try
            {
                var permissionSummary = _mapper.Map<PermissionSummary>(permissionSummaryDto);
                _permissionSummaryDal.UpdatePermissionSummary(permissionSummary, id);
                return new SuccessDataResult<PermissionSummaryDto>(permissionSummaryDto);
            }
            catch (System.Exception)
            {

                throw;
            }
        }


    }
}
