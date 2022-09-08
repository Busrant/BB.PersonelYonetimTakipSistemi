using BB.PersonelYonetimTakipSistemi.Model.PermissionTypes;
using BB.PersonelYonetimTakipSistemi.Model.ReplaceEmployeeDTO;
using BB.PersonelYonetimTakipSistemi.Model.Requests;
using BB.PersonelYonetimTakipSistemi.Model.TimeDays;
using BB.PersonelYonetimTakipSistemi.UI.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.UI.Controllers
{
    public class DayOffController : BaseController
    {
        public IActionResult DayOffIndex()
        {
            return View();
        }


        public async Task<ActionResult> GetAllPermissionDays()
        {
            var url = "/api/PermissionType/get-all-permissionType";
            var res = await HttpAction.Get<List<PermissionTypeDto>>(url);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        public async Task<ActionResult> CreateRequest(RequestsDto request)
        {
            try
            {
                var res = await HttpAction.Post<RequestsDto>(request, "/api/Request/create-dayoff-request", Token);
                var x = 5;
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("401"))
                {
                    return RedirectToAction("Login", "Login");
                }

                throw ex;
            }
        }

        public async Task<ActionResult> GetEmployeeForReplace(int departmentId, int branchId)
        {
            var url = "/api/Employees/get-employee-for-replace?departmentId=" + departmentId.ToString() + "&branchId=" + branchId.ToString();
            var res = await HttpAction.Get<List<ReplaceEmployeeDto>>(url);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        public async Task<ActionResult> GetAllDayOffs(string startDate, string endDate)
        {
            var url = "/api/TimeDay/get-all-dayoffs?startDate=" + startDate + "&endDate=" + endDate;
            var res = await HttpAction.Get<List<TimeDayDto>>(url);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }
    }
}
