using Application.Features.Sections.Requests.Queries;
using Application.Responses.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nauman.AIPortfolioGenerator.Application.DTOs.Section;
using Nauman.AIPortfolioGenerator.Application.DTOs.Template;
using Nauman.AIPortfolioGenerator.Application.Features.Sections.Requests.Commands;
using Nauman.AIPortfolioGenerator.Application.Features.Sections.Requests.Queries;
using Nauman.AIPortfolioGenerator.Application.Features.Templates.Requests.Commands;
using Nauman.AIPortfolioGenerator.Application.Features.Templates.Requests.Queries;
using Nauman.AIPortfolioGenerator.Application.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TemplateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<CustomQueryResponse<List<TemplateDTO>>>> Get()
        {
            var response = await _mediator.Send(new GetTemplateListRequest());
            return Ok(response);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomQueryResponse<TemplateDTO>>> Get(int id)
        {
            var response = await _mediator.Send(new GetTemplateDetailsRequest { Id = id });
            return Ok(response);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult<CustomCommandResponse>> Post([FromBody] CreateTemplateDTO template)
        {
            var response = await _mediator.Send(new CreateTemplateCommand { templateDTO = template });
            return Ok(response);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<CustomCommandResponse>> Put(int id, [FromBody] UpdateTemplateDTO template)
        {
            var response = await _mediator.Send(new UpdateTemplateCommand { Id = id, templateDTO = template });
            return Ok(response);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse>> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteTemplateCommand { Id = id });
            return Ok(response);
        }
    }
}
