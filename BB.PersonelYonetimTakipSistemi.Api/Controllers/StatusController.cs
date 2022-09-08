using BB.PersonelYonetimTakipSistemi.Model.Statuses;
using BB.PersonelYonetimTakipSistemi.Service.Statuses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _statusService;
        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }

        [HttpPost("add-status")]
        public async Task<IActionResult> AddStatus([FromBody] StatusDto statusDto)
        {
            var res = await _statusService.AddStatus(statusDto);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpGet("get-all-statuses")]
        public async Task<IActionResult> GetAllStatuses()
        {
            var res = await _statusService.GetAllStatus();
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpPut("update-status")]
        public async Task<IActionResult> UpdateStatus([FromBody] StatusDto statusDto, int id)
        {
            var res = await _statusService.UpdateStatus(statusDto, id);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpDelete("delete-status")]
        public async Task<IActionResult> DeleteStatus([FromBody] int id)
        {
            var res = await _statusService.DeleteStatus(id);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }
    }
}
