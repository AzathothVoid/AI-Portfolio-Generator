using AutoMapper;
using MediatR;
using Nauman.AIPortfolioGenerator.Application.Contracts.Persistence;
using Nauman.AIPortfolioGenerator.Application.DTOs.Template;
using Nauman.AIPortfolioGenerator.Application.Features.Templates.Requests.Queries;
using Nauman.AIPortfolioGenerator.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nauman.AIPortfolioGenerator.Application.Features.Templates.Handlers.Queries
{
    public class GetTemplateListRequestHandler : IRequestHandler<GetTemplateListRequest, CustomQueryResponse<List<TemplateDTO>>>
    {
        private readonly ITemplateRepository _templateRepository;
        private readonly IMapper _mapper;

        public GetTemplateListRequestHandler(ITemplateRepository templateRepository, IMapper mapper)
        {
            _templateRepository = templateRepository;
            _mapper = mapper;
        }

        public async Task<CustomQueryResponse<List<TemplateDTO>>> Handle(GetTemplateListRequest request, CancellationToken cancellationToken)
        {
            var response = new CustomQueryResponse<List<TemplateDTO>>();
            var templates = await _templateRepository.GetAllAsync();

            response.Success = true;
            response.Message = "GET Successful";
            response.Data = _mapper.Map<List<TemplateDTO>>(templates);
            return response;
        }
    }
}
