using BB.PersonelYonetimTakipSistemi.Model.PermissionSummaries;
using BB.PersonelYonetimTakipSistemi.Service.PermissionSummaries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionSummaryController : ControllerBase
    {
        private readonly IPermissionSummaryService _permissionSummaryService;

        public PermissionSummaryController(IPermissionSummaryService permissionSummaryService)
        {
            _permissionSummaryService = permissionSummaryService;
        }

        [HttpPost("add-permissionSummary")]
        public async Task<IActionResult> AddPermissionSummary([FromBody] PermissionSummaryDto permissionSummaryDto)
        {
            var res = await _permissionSummaryService.AddPermissionSummary(permissionSummaryDto);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpGet("get-all-permissionSummary")]
        public async Task<IActionResult> GetAllPermissionSummary()
        {
            var res = await _permissionSummaryService.GetAllPermissionSummary();
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpPut("update-permissionSummary")]
        public async Task<IActionResult> UpdatePermissionSummary([FromBody] PermissionSummaryDto permissionSummaryDto, int id)
        {
            var res = await _permissionSummaryService.UpdatePermissionSummary(permissionSummaryDto, id);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpDelete("delete-permissionSummary")]
        public async Task<IActionResult> DeletePermissionSummary([FromBody] int id)
        {
            var res = await _permissionSummaryService.DeletePermissionSummary(id);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpGet("get-permission-by-employee-id")]
        public async Task<IActionResult> GetPermissionByEmployeeId([FromQuery] int employeeId)
        {
            var res = await _permissionSummaryService.GetPermissionByEmployeeId(employeeId);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }
    }
}
