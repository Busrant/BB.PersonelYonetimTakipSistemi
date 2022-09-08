using AutoMapper;
using BB.PersonelYonetimTakipSistemi.Dal.RequestTypes;
using BB.PersonelYonetimTakipSistemi.Data.Model;
using BB.PersonelYonetimTakipSistemi.Helper.DataResult;
using BB.PersonelYonetimTakipSistemi.Model.RequestType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Service.RequestTypes
{
    public interface IRequestTypeService
    {
        Task<IDataResult<RequestTypeDto>> AddRequestType(RequestTypeDto requestTypeDto);
        Task<IDataResult<RequestTypeDto>> UpdateRequestType(RequestTypeDto requestTypeDto, int id);
        Task<IDataResult<RequestType>> DeleteRequestType(int id);
        Task<IDataResult<List<RequestType>>> GetAllRequestType();

    }
    public class RequestTypeService : IRequestTypeService
    {
        private readonly IRequestTypeDal _requestTypeDal;
        private readonly IMapper _mapper;
        public RequestTypeService(IRequestTypeDal requestTypeDal, IMapper mapper)
        {
            _requestTypeDal = requestTypeDal;
            _mapper = mapper;
        }

        public async Task<IDataResult<RequestTypeDto>> AddRequestType(RequestTypeDto requestTypeDto)
        {
            try
            {
                var requestType = _mapper.Map<RequestType>(requestTypeDto);
                _requestTypeDal.AddRequestType(requestType);
                return new SuccessDataResult<RequestTypeDto>(requestTypeDto);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<IDataResult<RequestType>> DeleteRequestType(int id)
        {
            try
            {
                return new SuccessDataResult<RequestType>(await _requestTypeDal.DeleteRequestType(id));
            }
            catch (System.Exception ex)
            {
                return new ErrorDataResult<RequestType>(ex.Message);
            }
        }

        public async Task<IDataResult<List<RequestType>>> GetAllRequestType()
        {
            try
            {
                return new SuccessDataResult<List<RequestType>>(await _requestTypeDal.GetAllRequestType());
            }
            catch (System.Exception ex)
            {
                return new ErrorDataResult<List<RequestType>>(ex.Message);
            }
        }

        public async Task<IDataResult<RequestTypeDto>> UpdateRequestType(RequestTypeDto requestTypeDto, int id)
        {
            try
            {
                var requestType = _mapper.Map<RequestType>(requestTypeDto);
                _requestTypeDal.UpdateRequestType(requestType, id);
                return new SuccessDataResult<RequestTypeDto>(requestTypeDto);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
