using AutoMapper;
using BB.PersonelYonetimTakipSistemi.Dal.Requests;
using BB.PersonelYonetimTakipSistemi.Data.Model;
using BB.PersonelYonetimTakipSistemi.Helper.DataResult;
using BB.PersonelYonetimTakipSistemi.Helper.Utilites;
using BB.PersonelYonetimTakipSistemi.Model.AppSettings;
using BB.PersonelYonetimTakipSistemi.Model.RequestDetailsDTO;
using BB.PersonelYonetimTakipSistemi.Model.RequestEmployeeDTO;
using BB.PersonelYonetimTakipSistemi.Model.RequestForTeamLeaderDTO;
using BB.PersonelYonetimTakipSistemi.Model.Requests;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Service.Requests
{
    public interface IRequestService
    {
        Task<IDataResult<RequestsDto>> CreateRequest(RequestsDto requestDayOff);
        Task<IDataResult<RequestsDto>> UpdateRequest(RequestsDto requestDayOffDto, int id);
        Task<IDataResult<List<Request>>> GetRequestsByEmployeeId(int id);
        Task<IDataResult<List<RequestForTeamLeaderDto>>> GetRequestsForTeamLeader(int managerId);
        Task<IDataResult<List<Request>>> GetUsedRequests(int employeeId);
        Task<IDataResult<List<Request>>> GetEmployeDayOffRequest(int employeeId, int requestType);
        Task<IDataResult<List<RequestEmployeeDto>>> GetUpComingRequests();
        Task<IDataResult<RequestDetailsDto>> GetRequestDetails(int requestId);
        Task<IDataResult<Request>> SaveRequestAnswer(int requestId, int answer);

    }
    public class RequestService : IRequestService
    {
        private readonly IRequestDal _requestDal;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public RequestService(IOptions<AppSettings> appSettings, IRequestDal requestDal, IMapper mapper)
        {
            _requestDal = requestDal;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        public async Task<IDataResult<RequestsDto>> UpdateRequest(RequestsDto requestDayOffDto, int id)
        {
            try
            {
                var request = _mapper.Map<Request>(requestDayOffDto);
                _requestDal.UpdateRequest(request, id);
                return new SuccessDataResult<RequestsDto>(requestDayOffDto);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<IDataResult<RequestsDto>> CreateRequest(RequestsDto requestDayOff)
        {
            try
            {
                var dayOff = _mapper.Map<Request>(requestDayOff);
                _requestDal.CreateRequest(dayOff);
                return new SuccessDataResult<RequestsDto>(requestDayOff);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<IDataResult<List<Request>>> GetRequestsByEmployeeId(int id)
        {
            try
            {
                return new SuccessDataResult<List<Request>>(await _requestDal.GetRequestsByEmployeeId(id));
            }
            catch (System.Exception ex)
            {
                return new ErrorDataResult<List<Request>>(ex.Message);
            }
        }

        public async Task<IDataResult<List<RequestForTeamLeaderDto>>> GetRequestsForTeamLeader(int managerId)
        {
            try
            {
                return new SuccessDataResult<List<RequestForTeamLeaderDto>>(await _requestDal.GetRequestsForTeamLeader(managerId));
            }
            catch (System.Exception ex)
            {
                return new ErrorDataResult<List<RequestForTeamLeaderDto>>(ex.Message);
            }
        }

        public async Task<IDataResult<List<Request>>> GetUsedRequests(int employeeId)
        {
            try
            {
                return new SuccessDataResult<List<Request>>(await _requestDal.GetUsedRequests(employeeId));
            }
            catch (System.Exception ex)
            {

                return new ErrorDataResult<List<Request>>(ex.Message);
            }
        }

        public async Task<IDataResult<List<RequestEmployeeDto>>> GetUpComingRequests()
        {
            try
            {
                return new SuccessDataResult<List<RequestEmployeeDto>>(_requestDal.GetUpComingRequests());
            }
            catch (System.Exception ex)
            {
                return new ErrorDataResult<List<RequestEmployeeDto>>(ex.Message);
            }
        }

        public async Task<IDataResult<List<Request>>> GetEmployeDayOffRequest(int employeeId, int requestType)
        {
            try
            {
                return new SuccessDataResult<List<Request>>(await _requestDal.GetEmployeDayOffRequest(employeeId, requestType));
            }
            catch (System.Exception ex)
            {
                return new ErrorDataResult<List<Request>>(ex.Message);
            }
        }

        public async Task<IDataResult<RequestDetailsDto>> GetRequestDetails(int requestId)
        {
            try
            {
                return new SuccessDataResult<RequestDetailsDto>(_requestDal.GetRequestDetails(requestId));
            }
            catch (System.Exception ex)
            {
                return new ErrorDataResult<RequestDetailsDto>(ex.Message);
            }
        }

        public async Task<IDataResult<Request>> SaveRequestAnswer(int requestId, int answer)
        {
            try
            {
                return new SuccessDataResult<Request>(await _requestDal.SaveRequestAnswer(requestId,answer));
            }
            catch (System.Exception ex)
            {
                return new ErrorDataResult<Request>(ex.Message);
            }
        }
    }
}
