using BB.PersonelYonetimTakipSistemi.Data.Model;
using BB.PersonelYonetimTakipSistemi.Model.PermissionTypes;
using BB.PersonelYonetimTakipSistemi.Service.PermissionTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionTypeController : ControllerBase
    {
        private readonly IPermissionTypeService _permissionTypeService;

        public PermissionTypeController(IPermissionTypeService permissionTypeService)
        {
            _permissionTypeService = permissionTypeService;
        }

        [HttpPost("adad-permissionType")]
        public async Task<IActionResult> AddPermissionType([FromBody] PermissionTypeDto permissionTypeDto)
        {
            var res = await _permissionTypeService.AddPermissionType(permissionTypeDto);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpGet("get-all-permissionType")]
        public async Task<IActionResult> GetAllPermissionType()
        {
            var res = await _permissionTypeService.GetAllPermissionType();
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpPut("update-permissionType")]
        public async Task<IActionResult> UpdatePermissionType([FromBody] PermissionTypeDto permissionTypeDto, int id)
        {
            var res = await _permissionTypeService.UpdatePermissionType(permissionTypeDto, id);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpDelete("delete-permissionType")]
        public async Task<IActionResult> DeletePermissionType([FromBody] int id)
        {
            var res = await _permissionTypeService.DeletePermissionType(id);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }
    }
}
