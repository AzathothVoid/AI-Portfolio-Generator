using AutoMapper;
using MediatR;
using Nauman.AIPortfolioGenerator.Application.Contracts.Persistence;
using Nauman.AIPortfolioGenerator.Application.DTOs.Portfolio;
using Nauman.AIPortfolioGenerator.Application.DTOs.Section;
using Nauman.AIPortfolioGenerator.Application.Features.Sections.Requests.Queries;
using Nauman.AIPortfolioGenerator.Application.Responses;
using Nauman.AIPortfolioGenerator.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nauman.AIPortfolioGenerator.Application.Features.Sections.Handlers.Queries
{
    public class GetSectionListByPortfolioRequestHandler : IRequestHandler<GetSectionListByPortfolioRequest, CustomQueryResponse<List<SectionDTO>>>
    {
        private readonly ISectionRepository _sectionRepository;
        private readonly IMapper _mapper;

        public GetSectionListByPortfolioRequestHandler(ISectionRepository sectionRepository, IMapper mapper)
        {
            _sectionRepository = sectionRepository;
            _mapper = mapper;
        }

        public async Task<CustomQueryResponse<List<SectionDTO>>> Handle(GetSectionListByPortfolioRequest request, CancellationToken cancellationToken)
        {
            var response = new CustomQueryResponse<List<SectionDTO>>();
            var sections = await _sectionRepository.GetAllByPortfolioAsync(request.Id);

            response.Success = true;
            response.Message = "GET Successful";
            response.Data = _mapper.Map<List<SectionDTO>>(sections);
            return response;
        }
    }
}
