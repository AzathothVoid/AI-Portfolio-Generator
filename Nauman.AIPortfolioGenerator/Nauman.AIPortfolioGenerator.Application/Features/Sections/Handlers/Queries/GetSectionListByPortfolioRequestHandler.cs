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
    public class GetSectionListByPortfolioRequestHandler : IRequestHandler<GetSectionListByPortfolioRequest, List<SectionDTO>>
    {
        private readonly ISectionRepository _sectionRepository;
        private readonly IMapper _mapper;

        public GetSectionListByPortfolioRequestHandler(ISectionRepository sectionRepository, IMapper mapper)
        {
            _sectionRepository = sectionRepository;
            _mapper = mapper;
        }

        public async Task<List<SectionDTO>> Handle(GetSectionListByPortfolioRequest request, CancellationToken cancellationToken)
        {
            var sections = await _sectionRepository.GetAllByPortfolioAsync(request.Id);

            return _mapper.Map<List<SectionDTO>>(sections);
        }
    }
}
