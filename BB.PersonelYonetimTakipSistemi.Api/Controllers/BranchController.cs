using BB.PersonelYonetimTakipSistemi.Model.Branches;
using BB.PersonelYonetimTakipSistemi.Service.Branches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchService _branchService;

        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        [HttpPost("add-branch")]
        public async Task<IActionResult> AddBranch([FromBody] BranchDto branchDto)
        {
            var res = await _branchService.AddBranch(branchDto);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpGet("get-all-branches")]
        public async Task<IActionResult> GetAllBranches()
        {
            var res = await _branchService.GetAllBranch();
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpPut("update-branch")]
        public async Task<IActionResult> UpdateBranch([FromBody] BranchDto branchDto, int id)
        {
            var res = await _branchService.UpdateBranch(branchDto, id);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpDelete("delete-branch")]
        public async Task<IActionResult> DeleteBranch([FromBody] int id)
        {
            var res = await _branchService.DeleteBranch(id);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpGet("get-all-company-branches")]
        public async Task<IActionResult> GetAllCompanyBranches([FromQuery] int companyId)
        {
            var res = await _branchService.GetAllCompanyBranches(companyId);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpGet("get-branch-company")]
        public async Task<IActionResult> GetBranchCompany()
        {
            var res = await _branchService.GetBranchCompany();
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }
    }
}
