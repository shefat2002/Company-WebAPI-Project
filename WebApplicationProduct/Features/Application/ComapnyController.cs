using Microsoft.AspNetCore.Mvc;
using WebApplicationProduct.Features.ServiceImplementation.ServiceInterface;
using WebApplicationProduct.Features.ServiceImplementation.ServiceInterface.Messaging;

namespace WebApplicationProduct.Features.Application
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComapnyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        public ComapnyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddAsync([FromBody] CompanyRequest request)
        {
            await _companyService.Add(request);

            return Ok("Success");
        }

        [HttpGet("getby/{id}")]
        public async Task<IActionResult>GetByAsync(int id)
        {
            var response= await _companyService.GetBy(id);
            return Ok(response);
        }
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateAsync([FromQuery] UpdateBranchRequest  frmRequest,int id)
        {
            try
            {   
                UpdateBranchRequest companyRequest = new();
                companyRequest.Name = frmRequest.Name;
                companyRequest.branchName = frmRequest.branchName;
                companyRequest.branchId = frmRequest.branchId;

                await _companyService.Update(companyRequest, id);
                return Ok("Success");
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _companyService.Delete(id);
            return Ok("Success");
        }
    }
}


