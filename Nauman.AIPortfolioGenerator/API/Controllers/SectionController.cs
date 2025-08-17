using Application.Features.Sections.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nauman.AIPortfolioGenerator.Application.DTOs.Portfolio;
using Nauman.AIPortfolioGenerator.Application.DTOs.Section;
using Nauman.AIPortfolioGenerator.Application.Features.Portfolios.Requests.Commands;
using Nauman.AIPortfolioGenerator.Application.Features.Portfolios.Requests.Queries;
using Nauman.AIPortfolioGenerator.Application.Features.Sections.Requests.Commands;
using Nauman.AIPortfolioGenerator.Application.Features.Sections.Requests.Queries;
using Nauman.AIPortfolioGenerator.Application.Responses;
using Nauman.AIPortfolioGenerator.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SectionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<CustomQueryResponse<List<SectionDTO>>>> Get()
        {
            var response = await _mediator.Send(new GetSectionListRequest());
            return Ok(response);
        }

        [HttpGet("byportfolio/{id}")]
        public async Task<ActionResult<CustomQueryResponse<List<SectionDTO>>>> GetByPortfolio(int id)
        {
            var response = await _mediator.Send(new GetSectionListByPortfolioRequest { Id = id});
            return Ok(response);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomQueryResponse<SectionDTO>>> Get(int id)
        {
            var response = await _mediator.Send(new GetSectionDetailsRequest { Id = id });
            return Ok(response);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult<CustomCommandResponse>> Post([FromBody] CreateSectionDTO section)
        {
            var response = await _mediator.Send(new CreateSectionCommand {  sectionDTO = section });
            return Ok(response);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<CustomCommandResponse>> Put(int id, [FromBody] UpdateSectionDTO section)
        {
            var response = await _mediator.Send(new UpdateSectionCommand { Id = id, sectionDTO = section });
            return Ok(response);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse>> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteSectionCommand { Id = id });
            return Ok(response);
        }
    }
}
