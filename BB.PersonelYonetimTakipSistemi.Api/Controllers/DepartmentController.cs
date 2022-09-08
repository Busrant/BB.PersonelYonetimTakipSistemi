using BB.PersonelYonetimTakipSistemi.Model.Departments;
using BB.PersonelYonetimTakipSistemi.Service.Departments;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentsService _departmentsService;

        public DepartmentController(IDepartmentsService departmentsService)
        {
            _departmentsService = departmentsService;
        }


        [HttpGet("get-all-department-employees")]
        public async Task<IActionResult> getAllDepartmentEmployees()
        {
            var res = await _departmentsService.GetAllDepartmentEmployees();
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpGet("get-all-departments-in-company")]
        public async Task<IActionResult> GetAllDepartmentsInCompany([FromQuery] int companyId)
        {
            var res = await _departmentsService.GetAllDepartmentsInCompany(companyId);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpGet("get-department-info")]
        public async Task<IActionResult> GetDepartmentInfos()
        {
            var res = await _departmentsService.GetDepartmentInfos();
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpPost("add-departments")]
        public async Task<IActionResult> AddDepartment([FromBody] DepartmentDto DepartmentDto)
        {
            var res = await _departmentsService.AddDepartment(DepartmentDto);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }
    }
}
