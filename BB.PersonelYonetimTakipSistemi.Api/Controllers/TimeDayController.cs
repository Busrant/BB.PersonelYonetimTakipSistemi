using BB.PersonelYonetimTakipSistemi.Model.TimeDays;
using BB.PersonelYonetimTakipSistemi.Service.TimeDays;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeDayController : ControllerBase
    {
        private readonly ITimeDaysService _timeDaysService;

        public TimeDayController(ITimeDaysService timeDaysService)
        {
            _timeDaysService = timeDaysService;
        }

        [HttpPost("add-timeday")]
        public async Task<IActionResult> AddTimeDay([FromBody] TimeDayDto timeDayDto)
        {
            var res = await _timeDaysService.AddTimeDay(timeDayDto);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpGet("get-all-timeday")]
        public async Task<IActionResult> GetAllTimeDays()
        {
            var res = await _timeDaysService.GetAllTimeDay();
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpPut("update-timeday")]
        public async Task<IActionResult> UpdateTimeDay([FromBody] TimeDayDto timeDayDto, int id)
        {
            var res = await _timeDaysService.UpdateTimeDay(timeDayDto, id);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpDelete("delete-timeday")]
        public async Task<IActionResult> DeleteTimeDay([FromBody] int id)
        {
            var res = await _timeDaysService.DeleteTimeDay(id);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpGet("get-all-dayoffs")]
        public async Task<IActionResult> GetAllDayOffs([FromQuery] DateTime startDate, DateTime endDate)
        {
            var res = await _timeDaysService.GetAllDayOffs(startDate, endDate);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }
    }
}
