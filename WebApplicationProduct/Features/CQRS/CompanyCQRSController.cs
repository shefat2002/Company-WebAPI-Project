using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApplicationProduct.Features.ServiceImplementation.ServiceInterface;

namespace WebApplicationProduct.Features.CQRS
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyCQRSController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompanyCQRSController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateCompanyCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(new { id });
        }
        [HttpGet("getby/{id}")]
        public async Task<IActionResult> GetBy(int id)
        {
            var response = await _mediator.Send(new GetCompanyQuery(id));
            return Ok(response);

        }


    }
}
