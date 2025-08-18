using Application.Responses;
using AutoMapper;
using MediatR;
using Nauman.AIPortfolioGenerator.Application.Contracts.Persistence;
using Nauman.AIPortfolioGenerator.Application.DTOs.Section;
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
    public class GetTemplateDetailsRequestHandler : IRequestHandler<GetTemplateDetailsRequest, CustomQueryResponse<TemplateDTO>>
    {
        private readonly ITemplateRepository _templateRepository;
        private readonly IMapper _mapper;

        public GetTemplateDetailsRequestHandler(ITemplateRepository templateRepository, IMapper mapper)
        {
            _templateRepository = templateRepository;
            _mapper = mapper;
        }

        public async Task<CustomQueryResponse<TemplateDTO>> Handle(GetTemplateDetailsRequest request, CancellationToken cancellationToken)
        {
            var response = new CustomQueryResponse<TemplateDTO>();
            var templateDetail = await _templateRepository.GetAsync(request.Id);

            if (templateDetail == null)
            {
                response.Success = false;
                response.Message = "No such record";
                response.Data = null;
                return response;
            }

            response.Success = true;
            response.Message = "GET Successful";
            response.Data = _mapper.Map<TemplateDTO>(templateDetail);
            return response;
        }
    }
}
