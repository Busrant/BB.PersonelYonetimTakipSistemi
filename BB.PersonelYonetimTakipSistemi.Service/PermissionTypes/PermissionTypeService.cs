using AutoMapper;
using BB.PersonelYonetimTakipSistemi.Dal.PermissionTypes;
using BB.PersonelYonetimTakipSistemi.Data.Model;
using BB.PersonelYonetimTakipSistemi.Helper.DataResult;
using BB.PersonelYonetimTakipSistemi.Model.PermissionTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Service.PermissionTypes
{
    public interface IPermissionTypeService
    {
        Task<IDataResult<PermissionTypeDto>> AddPermissionType(PermissionTypeDto permissionTypeDto);
        Task<IDataResult<PermissionTypeDto>> UpdatePermissionType(PermissionTypeDto permissionTypeDto, int id);
        Task<IDataResult<PermissionType>> DeletePermissionType(int id);
        Task<IDataResult<List<PermissionType>>> GetAllPermissionType();
    }
    public class PermissionTypeService : IPermissionTypeService
    {
        private readonly IPermissionTypeDal _permissionTypeDal;
        private readonly IMapper _mapper;

        public PermissionTypeService(IPermissionTypeDal permissionTypeDal, IMapper mapper)
        {
            _permissionTypeDal = permissionTypeDal;
            _mapper = mapper;
        }

        public async Task<IDataResult<PermissionTypeDto>> AddPermissionType(PermissionTypeDto permissionTypeDto)
        {
            var permissionType = _mapper.Map<PermissionType>(permissionTypeDto);
            _permissionTypeDal.AddPermissionType(permissionType);
            return new SuccessDataResult<PermissionTypeDto>(permissionTypeDto);
        }

        public async Task<IDataResult<PermissionType>> DeletePermissionType(int id)
        {
            try
            {
                return new SuccessDataResult<PermissionType>(await _permissionTypeDal.DeletePermissionType(id));
            }
            catch (System.Exception ex)
            {
                return new ErrorDataResult<PermissionType>(ex.Message);
            }
        }

        public async Task<IDataResult<List<PermissionType>>> GetAllPermissionType()
        {
            try
            {
                return new SuccessDataResult<List<PermissionType>>(await _permissionTypeDal.GetAllPermissionTypes());
            }
            catch (System.Exception ex)
            {
                return new ErrorDataResult<List<PermissionType>>(ex.Message);
            }
        }

        public async Task<IDataResult<PermissionTypeDto>> UpdatePermissionType(PermissionTypeDto permissionTypeDto, int id)
        {
            try
            {
                var permissionType = _mapper.Map<PermissionType>(permissionTypeDto);
                _permissionTypeDal.UpdatePermissionType(permissionType, id);
                return new SuccessDataResult<PermissionTypeDto>(permissionTypeDto);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
