using BB.PersonelYonetimTakipSistemi.Model.EmployeeDetailDTO;
using BB.PersonelYonetimTakipSistemi.Model.Employees;
using BB.PersonelYonetimTakipSistemi.Model.GeneralInformationDto;
using BB.PersonelYonetimTakipSistemi.Model.Users;
using BB.PersonelYonetimTakipSistemi.Service.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost("authenticade")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateRequest authenticateRequest, string username, string url)
        {

            var res = await _usersService.AuthenticateToken(authenticateRequest, username, url);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpGet("get-upcoming-birthdays")]
        public async Task<IActionResult> GetUpComingBirthday()
        {
            var res = await _usersService.GetUpComingBirthday();
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpGet("get-user-detail")]
        public async Task<IActionResult> GetUserDetail([FromQuery] int userId)
        {
            var res = await _usersService.GetUserDetail(userId);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpPost("update-user")]
        public async Task<IActionResult> UpdateUser([FromBody] UserDto userDto, int id)
        {
            var res = await _usersService.UpdateUser(userDto, id);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpPost("update-general-informations")]
        public async Task<IActionResult> UpdateGeneralInformations([FromBody] GeneralInformationDto generalInformationDto, int id)
        {
            var res = await _usersService.UpdateGeneralInformations(generalInformationDto, id);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpPost("update-address-information")]
        public async Task<IActionResult> UpdateAdressInformation([FromBody] UserDto userDto, int id)
        {
            var res = await _usersService.UpdateAdressInformation(userDto, id);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpPost("add-user")]
        public async Task<IActionResult> AddUser([FromBody] UserDto userDto)
        {
            var res = await _usersService.AddUser(userDto);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }
    }
}
