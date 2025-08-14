using AutoMapper;
using MediatR;
using Nauman.AIPortfolioGenerator.Application.DTOs.Section;
using Nauman.AIPortfolioGenerator.Application.Features.Sections.Requests.Queries;
using Nauman.AIPortfolioGenerator.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nauman.AIPortfolioGenerator.Application.Features.Sections.Handlers.Queries
{
    public class GetSectionDetailsRequestHandler : IRequestHandler<GetSectionDetailsRequest, SectionDTO>
    {
        private readonly ISectionRepository _sectionRepository;
        private readonly IMapper _mapper;

        public GetSectionDetailsRequestHandler(ISectionRepository sectionRepository, IMapper mapper)
        {
             _sectionRepository = sectionRepository;
            _mapper = mapper;
        }

        public async Task<SectionDTO> Handle(GetSectionDetailsRequest request, CancellationToken cancellationToken)
        {
            var sectionDetails = await _sectionRepository.GetAsync(request.Id);
            return _mapper.Map<SectionDTO>(sectionDetails);
        }
    }
}
