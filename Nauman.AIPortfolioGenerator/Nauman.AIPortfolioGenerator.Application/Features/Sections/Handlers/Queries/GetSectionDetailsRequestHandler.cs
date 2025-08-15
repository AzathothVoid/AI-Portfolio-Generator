using AutoMapper;
using MediatR;
using Nauman.AIPortfolioGenerator.Application.Contracts.Persistence;
using Nauman.AIPortfolioGenerator.Application.DTOs.Portfolio;
using Nauman.AIPortfolioGenerator.Application.DTOs.Section;
using Nauman.AIPortfolioGenerator.Application.Features.Sections.Requests.Queries;
using Nauman.AIPortfolioGenerator.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nauman.AIPortfolioGenerator.Application.Features.Sections.Handlers.Queries
{
    public class GetSectionDetailsRequestHandler : IRequestHandler<GetSectionDetailsRequest, CustomQueryResponse<SectionDTO>
    {
        private readonly ISectionRepository _sectionRepository;
        private readonly IMapper _mapper;

        public GetSectionDetailsRequestHandler(ISectionRepository sectionRepository, IMapper mapper)
        {
             _sectionRepository = sectionRepository;
            _mapper = mapper;
        }

        public async Task<CustomQueryResponse<SectionDTO>> Handle(GetSectionDetailsRequest request, CancellationToken cancellationToken)
        {
            var response = new CustomQueryResponse<SectionDTO>();
            var sectionDetails = await _sectionRepository.GetAsync(request.Id);

            response.Success = true;
            response.Message = "GET Successful";
            response.Data = _mapper.Map<SectionDTO>(sectionDetails);
            return response;
        }
    }
}
