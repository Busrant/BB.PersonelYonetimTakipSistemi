using BB.PersonelYonetimTakipSistemi.Model.WorkTypes;
using BB.PersonelYonetimTakipSistemi.Service.WorkTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkTypeController : ControllerBase
    {
        private readonly IWorkTypeService _workTypeService;

        public WorkTypeController(IWorkTypeService workTypeService)
        {
            _workTypeService = workTypeService;
        }

        [HttpPost("add-workType")]
        public async Task<IActionResult> AddWorkType([FromBody] WorkTypeDto workTypeDto)
        {
            var res = await _workTypeService.AddWorkType(workTypeDto);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpGet("get-all-WorkType")]
        public async Task<IActionResult> GetAllWorkType()
        {
            var res = await _workTypeService.GetAllWorkType();
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpPut("update-WorkType")]
        public async Task<IActionResult> UpdateWorkType([FromBody] WorkTypeDto workTypeDto, int id)
        {
            var res = await _workTypeService.UpdateWorkType(workTypeDto, id);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpDelete("delete-WorkType")]
        public async Task<IActionResult> DeleteWorkType([FromBody] int id)
        {
            var res = await _workTypeService.DeleteWorkType(id);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }
    }
}
