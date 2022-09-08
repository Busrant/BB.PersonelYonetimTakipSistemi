using BB.PersonelYonetimTakipSistemi.Model.RequestType;
using BB.PersonelYonetimTakipSistemi.Service.RequestTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestTypeController : ControllerBase
    {
        private readonly IRequestTypeService _requestTypeService;

        public RequestTypeController(IRequestTypeService requestTypeService)
        {
            _requestTypeService = requestTypeService;
        }

        [HttpPost("add-requestType")]
        public async Task<IActionResult> AddRequestType([FromBody] RequestTypeDto requestTypeDto)
        {
            var res = await _requestTypeService.AddRequestType(requestTypeDto);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpGet("get-all-requestType")]
        public async Task<IActionResult> GetAllRequestType()
        {
            var res = await _requestTypeService.GetAllRequestType();
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpPut("update-requestType")]
        public async Task<IActionResult> UpdateRequestType([FromBody] RequestTypeDto requestTypeDto, int id)
        {
            var res = await _requestTypeService.UpdateRequestType(requestTypeDto, id);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpDelete("delete-requestType")]
        public async Task<IActionResult> DeleteRequestType([FromBody] int id)
        {
            var res = await _requestTypeService.DeleteRequestType(id);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }
    }
}
