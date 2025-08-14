using AutoMapper;
using MediatR;
using Nauman.AIPortfolioGenerator.Application.DTOs.Template;
using Nauman.AIPortfolioGenerator.Application.Features.Templates.Requests.Queries;
using Nauman.AIPortfolioGenerator.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nauman.AIPortfolioGenerator.Application.Features.Templates.Handlers.Queries
{
    public class GetTemplateDetailsRequestHandler : IRequestHandler<GetTemplateDetailsRequest, TemplateDTO>
    {
        private readonly ITemplateRepository _templateRepository;
        private readonly IMapper _mapper;

        public GetTemplateDetailsRequestHandler(ITemplateRepository templateRepository, IMapper mapper)
        {
            _templateRepository = templateRepository;
            _mapper = mapper;
        }

        public async Task<TemplateDTO> Handle(GetTemplateDetailsRequest request, CancellationToken cancellationToken)
        {
            var templateDetail = _templateRepository.GetAsync(request.Id);

            return _mapper.Map<TemplateDTO>(templateDetail);
        }
    }
}
