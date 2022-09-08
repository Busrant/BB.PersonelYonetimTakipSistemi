using AutoMapper;
using BB.PersonelYonetimTakipSistemi.Dal.Statuses;
using BB.PersonelYonetimTakipSistemi.Data.Model;
using BB.PersonelYonetimTakipSistemi.Helper.DataResult;
using BB.PersonelYonetimTakipSistemi.Model.Statuses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Service.Statuses
{
    public interface IStatusService
    {
        Task<IDataResult<StatusDto>> AddStatus(StatusDto statusDto);
        Task<IDataResult<StatusDto>> UpdateStatus(StatusDto statusDto, int id);
        Task<IDataResult<Status>> DeleteStatus(int id);
        Task<IDataResult<List<Status>>> GetAllStatus();

    }
    public class StatusService : IStatusService
    {

        private readonly IStatusDal _statusDal;
        private readonly IMapper _mapper;
        public StatusService(IStatusDal statusDal, IMapper mapper)
        {
            _statusDal = statusDal;
            _mapper = mapper;
        }

        public async Task<IDataResult<StatusDto>> AddStatus(StatusDto statusDto)
        {
            try
            {
                var status = _mapper.Map<Status>(statusDto);
                _statusDal.AddStatus(status);
                return new SuccessDataResult<StatusDto>(statusDto);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<IDataResult<Status>> DeleteStatus(int id)
        {
            try
            {
                return new SuccessDataResult<Status>(await _statusDal.DeleteStatus(id));
            }
            catch (System.Exception ex)
            {
                return new ErrorDataResult<Status>(ex.Message);
            }
        }

        public async Task<IDataResult<List<Status>>> GetAllStatus()
        {
            try
            {
                return new SuccessDataResult<List<Status>>(await _statusDal.GetStatuses());
            }
            catch (System.Exception ex)
            {
                return new ErrorDataResult<List<Status>>(ex.Message);
            }
        }

        public async Task<IDataResult<StatusDto>> UpdateStatus(StatusDto statusDto, int id)
        {
            try
            {
                var status = _mapper.Map<Status>(statusDto);
                _statusDal.UpdateStatus(status, id);
                return new SuccessDataResult<StatusDto>(statusDto);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
