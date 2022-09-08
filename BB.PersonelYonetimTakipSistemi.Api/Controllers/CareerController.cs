using BB.PersonelYonetimTakipSistemi.Model.Careers;
using BB.PersonelYonetimTakipSistemi.Service.Careers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CareerController : ControllerBase
    {
        private readonly ICareerService _careerService;

        public CareerController(ICareerService careerService)
        {
            _careerService = careerService;
        }

        [HttpPost("add-career")]
        public async Task<IActionResult> AddCareer([FromBody] CareerDto careerDto)
        {
            var res = await _careerService.AddCareer(careerDto);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpGet("get-all-careers")]
        public async Task<IActionResult> GetAllCareers()
        {
            var res = await _careerService.GetAllCareer();
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpPut("update-career")]
        public async Task<IActionResult> UpdateCareer([FromBody] CareerDto careerDto, int id)
        {
            var res = await _careerService.UpdateCareer(careerDto, id);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpDelete("delete-career")]
        public async Task<IActionResult> DeleteCareer([FromBody] int id)
        {
            var res = await _careerService.DeleteCareer(id);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpGet("get-employee-career")]
        public async Task<IActionResult> GetEmployeeCareer([FromQuery] int employeeId)
        {
            var res = await _careerService.GetEmployeeCareer(employeeId);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }
    }
}
