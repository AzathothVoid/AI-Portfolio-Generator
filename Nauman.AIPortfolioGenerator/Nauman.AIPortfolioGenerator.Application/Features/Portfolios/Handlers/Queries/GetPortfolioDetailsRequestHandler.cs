using AutoMapper;
using MediatR;
using Nauman.AIPortfolioGenerator.Application.DTOs.Portfolio;
using Nauman.AIPortfolioGenerator.Application.Features.Portfolios.Requests.Queries;
using Nauman.AIPortfolioGenerator.Application.Contracts.Persistence;
using Nauman.AIPortfolioGenerator.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nauman.AIPortfolioGenerator.Application.Features.Portfolios.Handlers.Queries
{
    public class GetPortfolioDetailsRequestHandler : IRequestHandler<GetPortfolioDetailsRequest, CustomQueryResponse<PortfolioDTO>>
    {
        private readonly IPortfolioRepository _portfolioRepository;
        private readonly IMapper _mapper;

        public GetPortfolioDetailsRequestHandler(IPortfolioRepository portfolioRepository, IMapper mapper)
        {
            _portfolioRepository = portfolioRepository;
            _mapper = mapper;
        }
        public async Task<CustomQueryResponse<PortfolioDTO>> Handle(GetPortfolioDetailsRequest request, CancellationToken cancellationToken)
        {
            var response = new CustomQueryResponse<PortfolioDTO>();
            var portfolioDetail = await _portfolioRepository.GetAsync(request.id);

            response.Success = true;
            response.Message = "OK";
            response.Data = _mapper.Map<PortfolioDTO>(portfolioDetail);
            return response;
        }
    }
}
