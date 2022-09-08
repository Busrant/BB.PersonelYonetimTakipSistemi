using BB.PersonelYonetimTakipSistemi.Data.Context;
using BB.PersonelYonetimTakipSistemi.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.Entity.Core.Objects;
using BB.PersonelYonetimTakipSistemi.Model.RequestEmployeeDTO;
using BB.PersonelYonetimTakipSistemi.Model.RequestForTeamLeaderDTO;
using BB.PersonelYonetimTakipSistemi.Model.RequestDetailsDTO;

namespace BB.PersonelYonetimTakipSistemi.Dal.Requests
{
    public interface IRequestDal
    {
        void CreateRequest(Request requestDayOff);
        void UpdateRequest(Request requestDayOff, int id);
        Task<List<Request>> GetRequestsByEmployeeId(int id);
        Task<List<RequestForTeamLeaderDto>> GetRequestsForTeamLeader(int managerId);
        Task<List<Request>> GetUsedRequests(int employeeId);
        List<RequestEmployeeDto> GetUpComingRequests();
        Task<List<Request>> GetEmployeDayOffRequest(int employeeId, int requestType);
        RequestDetailsDto GetRequestDetails(int requestId);
        Task<Request> SaveRequestAnswer(int requestId, int answer);
    }
    public class RequestDal : IRequestDal
    {
        public readonly ApplicationContext _applicationContext;
        public RequestDal(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async void UpdateRequest(Request requestDayOff, int id)
        {
            try
            {
                using (ApplicationContext context = new ApplicationContext())
                {
                    var result = context.Update(requestDayOff);
                    if (result.State == EntityState.Modified)
                    {
                        await context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async void CreateRequest(Request requestDayOff)
        {
            try
            {
                using (ApplicationContext context = new ApplicationContext())
                {
                    var result = await context.AddAsync(requestDayOff);
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
        public async Task<List<Request>> GetRequestsByEmployeeId(int id)
        {
            try
            {
                var request = await _applicationContext.RequestDayOffs.Where(i => i.IsAccepted == null && i.EmployeeID == id).ToListAsync();
                return request;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<RequestForTeamLeaderDto>> GetRequestsForTeamLeader(int managerId)
        {
            try
            {
                var res = from D in _applicationContext.Departments
                          join C in _applicationContext.Careers on D.ID equals C.DepartmentId
                          join R in _applicationContext.RequestDayOffs on C.EmployeeId equals R.EmployeeID
                          join E in _applicationContext.Employees on C.EmployeeId equals E.ID
                          join PT in _applicationContext.PermissionTypes on R.PermissionTypeId equals PT.ID
                          join RT in _applicationContext.RequestTypes on R.RequestTypeId equals RT.ID
                          join U in _applicationContext.Users on E.UserId equals U.ID
                          where C.IsActive == true && D.ManagerId == managerId && R.IsAccepted == 0
                          select new RequestForTeamLeaderDto { Career = C, Department = D, Employee = E, PermissionType = PT, Request = R, RequestType = RT, User = U };
                return await res.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Request>> GetUsedRequests(int employeeId)
        {
            try
            {
                var result = await _applicationContext.RequestDayOffs.Where(i => i.EndDate < DateTime.Now && i.IsAccepted == 1 && i.EmployeeID == employeeId).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<Request>> GetEmployeDayOffRequest(int employeeId, int requestType)
        {
            try
            {
                var result = await _applicationContext.RequestDayOffs.Where(i => i.EmployeeID == employeeId && i.RequestTypeId == requestType).ToListAsync();
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public List<RequestEmployeeDto> GetUpComingRequests()
        {
            try
            {
                var result = from R in _applicationContext.RequestDayOffs
                             join E in _applicationContext.Employees on R.EmployeeID equals E.ID
                             join U in _applicationContext.Users on E.UserId equals U.ID
                             where R.StartDate > DateTime.Now && R.IsAccepted == 1 && R.RequestTypeId == 1 && E.IsActive == true
                             select new RequestEmployeeDto { Employee = E, Request = R, User = U };
                return result.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public RequestDetailsDto GetRequestDetails(int requestId)
        {
            try
            {
                var result = from R in _applicationContext.RequestDayOffs
                             join C in _applicationContext.Careers on R.EmployeeID equals C.EmployeeId
                             join D in _applicationContext.Departments on C.DepartmentId equals D.ID
                             join E in _applicationContext.Employees on R.ReplaceEmployeeId equals E.ID
                             join U in _applicationContext.Users on E.UserId equals U.ID
                             join PT in _applicationContext.PermissionTypes on R.PermissionTypeId equals PT.ID
                             join ReqT in _applicationContext.RequestTypes on R.RequestTypeId equals ReqT.ID
                             where R.ID == requestId
                             select new RequestDetailsDto { Request = R, Career = C, Department = D, Employee = E, User = U, PermissionType = PT, RequestType = ReqT };

                return result.FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Request> SaveRequestAnswer(int requestId, int answer)
        {
            try
            {
                var result = await _applicationContext.RequestDayOffs.Where(i => i.ID == requestId).FirstOrDefaultAsync();
                result.IsAccepted = answer;
                var res = _applicationContext.SaveChangesAsync();
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
