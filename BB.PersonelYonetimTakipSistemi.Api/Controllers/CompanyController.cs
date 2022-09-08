using BB.PersonelYonetimTakipSistemi.Model.Companies;
using BB.PersonelYonetimTakipSistemi.Service.Companies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost("add-company")]
        public async Task<IActionResult> AddCompany([FromBody] CompanyDto companyDto)
        {
            var res = await _companyService.AddCompany(companyDto);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpGet("get-all-companies")]
        public async Task<IActionResult> GetAllCompanies()
        {
            var res = await _companyService.GetAllCompany();
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpPut("update-company")]
        public async Task<IActionResult> UpdateCompany([FromBody] CompanyDto companyDto, int id)
        {
            var res = await _companyService.UpdateCompany(companyDto, id);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpDelete("delete-company")]
        public async Task<IActionResult> DeleteBranch([FromBody] int id)
        {
            var res = await _companyService.DeleteCompany(id);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }
    }
}
