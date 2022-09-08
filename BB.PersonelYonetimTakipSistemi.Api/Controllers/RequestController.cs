using BB.PersonelYonetimTakipSistemi.Model.Requests;
using BB.PersonelYonetimTakipSistemi.Service.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _RequestsService;

        public RequestController(IRequestService requestsService)
        {
            _RequestsService = requestsService;
        }

        [HttpPost("create-dayoff-request")]
        public async Task<IActionResult> CreateRequest([FromBody] RequestsDto request)
        {
            var res = await _RequestsService.CreateRequest(request);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpPut("update-request")]
        public async Task<IActionResult> UpdateRequest([FromBody] RequestsDto request, int id)
        {
            var res = await _RequestsService.UpdateRequest(request, id);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpGet("get-request-by-employeeId")]
        public async Task<IActionResult> GetRequestsByEmployeeId([FromQuery] int employeeId)
        {
            var res = await _RequestsService.GetRequestsByEmployeeId(employeeId);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpGet("get-request-for-team-leader")]
        public async Task<IActionResult> GetRequestsForTeamLeader([FromQuery] int managerId) 
        {
            var res = await _RequestsService.GetRequestsForTeamLeader(managerId);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpGet("get-used-request")]
        public async Task<IActionResult> getUsedRequests([FromQuery] int employeeId)
        {
            var res = await _RequestsService.GetUsedRequests(employeeId);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpGet("get-employee-dayoff-request")]
        public async Task<IActionResult> GetEmployeDayOffRequest([FromQuery] int employeeId, int requestType)
        {
            var res = await _RequestsService.GetEmployeDayOffRequest(employeeId, requestType);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpGet("get-upcoming-request")]
        public async Task<IActionResult> getUpComingRequests()
        {
            var res = await _RequestsService.GetUpComingRequests();
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpGet("get-request-details")]
        public async Task<IActionResult> GetRequestDetails([FromQuery]int requestId)
        {
            var res = await _RequestsService.GetRequestDetails(requestId);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpGet("save-request-answer")]
        public async Task<IActionResult> SaveRequestAnswer([FromQuery]int requestId, int answer)
        {
            var res = await _RequestsService.SaveRequestAnswer(requestId, answer);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

    }
}
