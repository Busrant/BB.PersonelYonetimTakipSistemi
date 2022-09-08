using AutoMapper;
using BB.PersonelYonetimTakipSistemi.Dal.WorkTypes;
using BB.PersonelYonetimTakipSistemi.Data.Model;
using BB.PersonelYonetimTakipSistemi.Helper.DataResult;
using BB.PersonelYonetimTakipSistemi.Model.WorkTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Service.WorkTypes
{
    public interface IWorkTypeService
    {
        Task<IDataResult<WorkTypeDto>> AddWorkType(WorkTypeDto workTypeDto);
        Task<IDataResult<WorkTypeDto>> UpdateWorkType(WorkTypeDto workTypeDto, int id);
        Task<IDataResult<WorkType>> DeleteWorkType(int id);
        Task<IDataResult<List<WorkType>>> GetAllWorkType();

    }

    public class WorkTypeService : IWorkTypeService
    {
        private readonly IWorkTypeDal _workTypeDal;
        private readonly IMapper _mapper;

        public WorkTypeService(IWorkTypeDal workTypeDal, IMapper mapper)
        {
            _workTypeDal = workTypeDal;
            _mapper = mapper;
        }

        public async Task<IDataResult<WorkTypeDto>> AddWorkType(WorkTypeDto workTypeDto)
        {
            try
            {
                var workType = _mapper.Map<WorkType>(workTypeDto);
                _workTypeDal.AddWorkType(workType);
                return new SuccessDataResult<WorkTypeDto>(workTypeDto);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<IDataResult<WorkType>> DeleteWorkType(int id)
        {
            try
            {
                return new SuccessDataResult<WorkType>(await _workTypeDal.DeleteWorkType(id));
            }
            catch (System.Exception ex)
            {
                return new ErrorDataResult<WorkType>(ex.Message);
            }
        }

        public async Task<IDataResult<List<WorkType>>> GetAllWorkType()
        {
            try
            {
                return new SuccessDataResult<List<WorkType>>(await _workTypeDal.GetAllWorkTypes());
            }
            catch (System.Exception ex)
            {
                return new ErrorDataResult<List<WorkType>>(ex.Message);
            }
        }

        public async Task<IDataResult<WorkTypeDto>> UpdateWorkType(WorkTypeDto workTypeDto, int id)
        {
            try
            {
                var workType = _mapper.Map<WorkType>(workTypeDto);
                _workTypeDal.UpdateWorkType(workType, id);
                return new SuccessDataResult<WorkTypeDto>(workTypeDto);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
