using Application.Features.Sections.Requests.Queries;
using AutoMapper;
using MediatR;
using Nauman.AIPortfolioGenerator.Application.Contracts.Persistence;
using Nauman.AIPortfolioGenerator.Application.DTOs.Portfolio;
using Nauman.AIPortfolioGenerator.Application.DTOs.Section;
using Nauman.AIPortfolioGenerator.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Sections.Handlers.Queries
{
    public class GetSectionListRequestHandler : IRequestHandler<GetSectionListRequest, CustomQueryResponse<List<SectionDTO>>>
    {
        private readonly ISectionRepository _sectionRepository;
        private readonly IMapper _mapper;

        public GetSectionListRequestHandler(ISectionRepository sectionRepository, IMapper mapper)
        {
            _sectionRepository = sectionRepository;
            _mapper = mapper;
        }
        public async Task<CustomQueryResponse<List<SectionDTO>>> Handle(GetSectionListRequest request, CancellationToken cancellationToken)
        {
            var response = new CustomQueryResponse<List<SectionDTO>>();
            var sections = await _sectionRepository.GetAllAsync();

            response.Success = true;
            response.Message = "GET Successful";
            response.Data = _mapper.Map<List<SectionDTO>>(sections);

            return response;
        }
    }
}
