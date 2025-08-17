using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nauman.AIPortfolioGenerator.Application.DTOs.Portfolio;
using Nauman.AIPortfolioGenerator.Application.Features.Portfolios.Requests.Commands;
using Nauman.AIPortfolioGenerator.Application.Features.Portfolios.Requests.Queries;
using Nauman.AIPortfolioGenerator.Application.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PortfolioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<CustomQueryResponse<List<PortfolioDTO>>>> Get()
        {
            var response = await _mediator.Send(new GetPortfolioListRequest());
            return Ok(response);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomQueryResponse<PortfolioDTO>>> Get(int id)
        {
            var response = await _mediator.Send(new GetPortfolioDetailsRequest { id = id });
            return Ok(response);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult<CustomCommandResponse>> Post([FromBody] CreatePortfolioDTO portfolio)
        {
            var response = await _mediator.Send(new CreatePortfolioCommand { portfolioDTO = portfolio });
            return Ok(response);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<CustomCommandResponse>> Put(int id, [FromBody] UpdatePortfolioDTO portfolio)
        {
            var response = await _mediator.Send(new UpdatePortfolioCommand { Id = id, portfolioDTO = portfolio });
            return Ok(response);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse>> Delete(int id)
        {
            var response = await _mediator.Send(new DeletePortfolioCommand { Id = id });
            return Ok(response);
        }
    }
}
