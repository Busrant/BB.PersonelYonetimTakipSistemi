using BB.PersonelYonetimTakipSistemi.Data.Model;
using BB.PersonelYonetimTakipSistemi.Model.Branches;
using BB.PersonelYonetimTakipSistemi.Model.Careers;
using BB.PersonelYonetimTakipSistemi.Model.Departments;
using BB.PersonelYonetimTakipSistemi.Model.EmployeeDetailDTO;
using BB.PersonelYonetimTakipSistemi.Model.Employees;
using BB.PersonelYonetimTakipSistemi.Model.GeneralInformationDto;
using BB.PersonelYonetimTakipSistemi.Model.Requests;
using BB.PersonelYonetimTakipSistemi.Model.Statuses;
using BB.PersonelYonetimTakipSistemi.Model.Users;
using BB.PersonelYonetimTakipSistemi.Model.WorkTypes;
using BB.PersonelYonetimTakipSistemi.UI.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.UI.Controllers
{
    public class ListEmployeeController : BaseController
    {
        public IActionResult List()
        {
            if (Token != null && Token != "")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        public async Task<IActionResult> ProfileEmployeeAsync(string id, string userId)
        {
            ViewBag.Id = id;
            ViewBag.UserId = userId;
            return View();

        }

        public async Task<IActionResult> CreateEmployee()
        {
            return View();
        }

        public async Task<ActionResult> GetAllDepartmentsInCompany(int companyId)
        {
            try
            {
                var url = "/api/Department/get-all-departments-in-company?companyId=" + companyId.ToString();
                var res = await HttpAction.Get<List<DepartmentDto>>(url);
                return Ok(res);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ActionResult> GetEmployeeDetail(int employeeId)
        {
            try
            {
                var url = "/api/Employees/get-employee-details?employeeId=" + employeeId.ToString();
                var res = await HttpAction.Get<EmployeeDetailDto>(url);
                return Ok(res);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public async Task<ActionResult> GetRequestsByEmployeeId(int employeeId)
        {
            try
            {
                var url = "/api/Request/get-request-by-employeeId?employeeId=" + employeeId.ToString();
                var res = await HttpAction.Get<List<RequestsDto>>(url);
                return Ok(res);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ActionResult> GetUserDetail(int userId)
        {
            try
            {
                var url = "/api/Users/get-user-detail?userId=" + userId.ToString();
                var res = await HttpAction.Get<UserDto>(url);
                return Ok(res);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ActionResult> GetEmployeDayOffRequest(int employeeId, int requestType)
        {
            try
            {
                var url = "/api/Request/get-employee-dayoff-request?employeeId=" + employeeId.ToString() + "&requestType=" + requestType.ToString();
                var res = await HttpAction.Get<List<RequestsDto>>(url);
                return Ok(res);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IActionResult> UpdateUser(UserDto userDto)
        {
            try
            {
                var res = await HttpAction.Post<UserDto>(userDto, "/api/Users/update-user");
                return Ok(res);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ActionResult> GetAllStatuses()
        {
            try
            {
                var url = "/api/Status/get-all-statuses";
                var res = await HttpAction.Get<List<StatusDto>>(url);
                return Ok(res);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IActionResult> AddUser(UserDto userDto)
        {
            try
            {
                var res = await HttpAction.Post<UserDto>(userDto, "/api/Users/add-user");
                return Ok(res);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IActionResult> AddEmployee(EmployeeDto employeeDto)
        {
            try
            {
                var res = await HttpAction.Post<EmployeeDto>(employeeDto, "/api/Employees/add-employee");
                return Ok(res);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IActionResult> AddCareer(CareerDto careerDto)
        {
            try
            {
                var res = await HttpAction.Post<CareerDto>(careerDto, "/api/Career/add-career");
                return Ok(res);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<ActionResult> GetAllCompanyBranches(int companyId)
        {
            try
            {
                var url = "/api/Branch/get-all-company-branches?companyId=" + companyId.ToString();
                var res = await HttpAction.Get<List<BranchDto>>(url);
                return Ok(res);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ActionResult> GetAllWorkTypes()
        {
            try
            {
                var url = "/api/WorkType/get-all-WorkType";
                var res = await HttpAction.Get<List<WorkTypeDto>>(url);
                return Ok(res);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IActionResult> UpdateGeneralInformation(GeneralInformationDto generalInformationDto)
        {
            try
            {
                var res = await HttpAction.Post<GeneralInformationDto>(generalInformationDto, "/api/Users/update-general-informations");
                return Ok(res);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IActionResult> UpdateAdressInformation(UserDto userDto, int id)
        {
            try
            {
                var res = await HttpAction.Post<UserDto>(userDto, "/api/Users/update-address-information");
                return Ok(res);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IActionResult> CreateDepartment()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IActionResult> AddStatus(StatusDto statusDto)
        {
            try
            {
                var res = await HttpAction.Post<StatusDto>(statusDto, "/api/Status/add-status");
                return Ok(res);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IActionResult> AddDepartments(DepartmentDto departmentDto)
        {
            try
            {
                var res = await HttpAction.Post<DepartmentDto>(departmentDto, "/api/Department/add-departments");
                return Ok(res);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IActionResult> GetAllCompanies()
        {
            try
            {
                var url = "/api/Company/get-all-companies";
                var res = await HttpAction.Get<Department>(url);
                if (res.Success)
                {
                   return Ok(res);
                }
                return BadRequest(res);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IActionResult> CreateStatus()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}