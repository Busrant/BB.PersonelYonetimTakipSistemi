using BB.PersonelYonetimTakipSistemi.Dal.Departments;
using BB.PersonelYonetimTakipSistemi.Data.Model;
using BB.PersonelYonetimTakipSistemi.Helper.Utilites;
using BB.PersonelYonetimTakipSistemi.Model.AllEmployeeDTO;
using BB.PersonelYonetimTakipSistemi.Model.Careers;
using BB.PersonelYonetimTakipSistemi.Model.DepartmentInfoDTO;
using BB.PersonelYonetimTakipSistemi.Model.Departments;
using BB.PersonelYonetimTakipSistemi.Model.EmployeeCareerDTO;
using BB.PersonelYonetimTakipSistemi.Model.Employees;
using BB.PersonelYonetimTakipSistemi.Model.RequestDetailsDTO;
using BB.PersonelYonetimTakipSistemi.Model.RequestEmployeeDTO;
using BB.PersonelYonetimTakipSistemi.Model.RequestForTeamLeaderDTO;
using BB.PersonelYonetimTakipSistemi.Model.Requests;
using BB.PersonelYonetimTakipSistemi.Model.Users;
using BB.PersonelYonetimTakipSistemi.UI.Helper;
using BB.PersonelYonetimTakipSistemi.UI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.UI.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<ActionResult> Index()
        {
            try
            {
                var res = Token;
                if (res != null && res != "")
                {
                    return View();
                }
                return RedirectToAction("Login", "Login");
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<ActionResult> GetEmployee()
        {
            try
            {
                var url = "/api/Employees/get-all-employees";

                var data = await HttpAction.Get<List<AllEmployeeDto>>(url);
                return Ok(data);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ActionResult> GetAllDepartmentEmployees()
        {
            try
            {
                var url = "/api/Department/get-all-department-employees";

                var data = await HttpAction.Get<List<DepartmentDto>>(url);
                return Ok(data);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<ActionResult> GetUsedRequests(int employeeId)
        {
            try
            {
                var url = "/api/Request/get-used-request?employeeId=" + employeeId;
                var data = await HttpAction.Get<List<RequestsDto>>(url, Token);
                return Ok(data);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ActionResult> GetPermissions(int employeeId)
        {
            try
            {
                var url = "/api/PermissionSummary/get-permission-by-employee-id?employeeId=" + employeeId;
                var res = await HttpAction.Get<PermissionSummary>(url);
                return Ok(res);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<ActionResult> GetEmployeeDepartmentInfo()
        {
            try
            {
                var url = "/api/Employee/get-employee-department-info";
                var data = await HttpAction.Get<List<RequestsDto>>(url);
                return Ok(data);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ActionResult> GetUpcomingRequests()
        {
            try
            {
                var url = "/api/Request/get-upcoming-request";
                var data = await HttpAction.Get<List<RequestEmployeeDto>>(url);
                return Ok(data);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ActionResult> GetEmployeeCareer(int employeeId)
        {
            try
            {
                var url = "/api/Career/get-employee-career?employeeId=" + employeeId.ToString();
                var data = await HttpAction.Get<List<EmployeeCareerDto>>(url);
                return Ok(data);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ActionResult> GetUpComingBirthdays()
        {
            try
            {
                var url = "/api/Users/get-upcoming-birthdays";
                var data = await HttpAction.Get<List<UserDto>>(url);
                return Ok(data);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ActionResult> GetRequestsForTeamLeader(int managerId)
        {
            try
            {
                var url = "/api/Request/get-request-for-team-leader?managerId=" + managerId;
                var data = await HttpAction.Get<List<RequestForTeamLeaderDto>>(url);
                return Ok(data);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ActionResult> CreateRequest(RequestsDto request)
        {
            try
            {
                var res = await HttpAction.Post<RequestsDto>(request, "/api/Request/create-dayoff-request");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("401"))
                {
                    return RedirectToAction("Index", "Login");
                }

                throw;
            }
        }

        public async Task<ActionResult> GetRequestDetails(int requestId)
        {
            try
            {
                var url = "/api/Request/get-request-details?requestId=" + requestId;
                var res = await HttpAction.Get<RequestDetailsDto>(url);
                return Ok(res);
            }
            catch (Exception)
            {
                throw;
            }
        }
      

        public async Task<ActionResult> GetDepartmentInfos()
        {
            try
            {
                var url = "/api/Department/get-department-info";
                var res = await HttpAction.Get<List<DepartmentInfoDto>>(url);
                return Ok(res);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ActionResult> SaveRequestAnswer(int requestId, int answer)
        {
            try
            {
                var url = "/api/Request/save-request-answer?requestId=" + requestId.ToString() + "&answer=" + answer.ToString();
                var res = await HttpAction.Get<Request>(url);
                return Ok(res);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
