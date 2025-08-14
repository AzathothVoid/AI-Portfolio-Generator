using AutoMapper;
using MediatR;
using Nauman.AIPortfolioGenerator.Application.DTOs.Template;
using Nauman.AIPortfolioGenerator.Application.Features.Templates.Requests.Queries;
using Nauman.AIPortfolioGenerator.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nauman.AIPortfolioGenerator.Application.Features.Templates.Handlers.Queries
{
    public class GetTemplateListRequestHandler : IRequestHandler<GetTemplateListRequest, List<TemplateDTO>>
    {
        private readonly ITemplateRepository _templateRepository;
        private readonly IMapper _mapper;

        public GetTemplateListRequestHandler(ITemplateRepository templateRepository, IMapper mapper)
        {
            _templateRepository = templateRepository;
            _mapper = mapper;
        }

        public async Task<List<TemplateDTO>> Handle(GetTemplateListRequest request, CancellationToken cancellationToken)
        {
            var templates = await _templateRepository.GetAllAsync();

            return _mapper.Map<List<TemplateDTO>>(templates);
        }
    }
}
