using BB.PersonelYonetimTakipSistemi.Model.Employees;
using BB.PersonelYonetimTakipSistemi.Service.Employees;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost("add-employee")]

        public async Task<IActionResult> AddEmployee([FromBody] EmployeeDto employees)
        {
            var res = await _employeeService.AddEmployee(employees);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpGet("get-all-employees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var res = await _employeeService.GetAllEmployee();
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpGet("get-employee-department-info")]
        public async Task<IActionResult> GetEmployeeDepartmentInfo()
        {
            var res = await _employeeService.GetEmployeeDepartmentInfo();
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }


        [HttpDelete("delete-user-by-id")]
        public async Task<IActionResult> DeleteEmployee([FromBody] int id)
        {
            var res = await _employeeService.DeleteEmployee(id);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpPut("update-employee")]

        public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeDto employees, int id)
        {
            var res = await _employeeService.UpdateEmployee(employees, id);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);

            if (id != employees.ID)
            {
                return BadRequest();
            }
        }

        [HttpGet("get-employee-details")]
        public async Task<IActionResult> GetEmployeeDetail([FromQuery] int employeeId)
        {
            var res = await _employeeService.GetEmployeeDetail(employeeId);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpGet("get-request-day-info")]
        public async Task<IActionResult> getRequestDayInfo([FromQuery] int employeeId)
        {
            var res = await _employeeService.GetRequestDayInfo(employeeId);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpGet("get-employee-for-replace")]
        public async Task<IActionResult> GetEmployeeForReplace([FromQuery] int departmentId, int branchId)
        {
            var res = await _employeeService.GetEmployeeForReplace(departmentId, branchId);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }


        [HttpGet("update-password")]
        public async Task<IActionResult> UpdatePassword([FromQuery]string companyEmail, string password)
        {
            try
            {
                var res = await _employeeService.UpdatePassword(companyEmail, password);
                if (res.Success)
                {
                    return Ok(res);
                }
                return BadRequest(res);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
