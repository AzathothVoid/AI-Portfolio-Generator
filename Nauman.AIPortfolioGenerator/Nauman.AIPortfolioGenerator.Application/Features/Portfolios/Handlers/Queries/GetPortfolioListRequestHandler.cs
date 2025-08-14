using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nauman.AIPortfolioGenerator.Application.DTOs.Portfolio;
using Nauman.AIPortfolioGenerator.Application.Features.Portfolios.Requests.Queries;
using Nauman.AIPortfolioGenerator.Application.Persistence.Contracts;

namespace Nauman.AIPortfolioGenerator.Application.Features.Portfolios.Handlers.Queries
{
    public class GetPortfolioListRequestHandler : IRequestHandler<GetPortfolioListRequest, List<PortfolioDTO>>
    {
        private readonly IPortfolioRepository _portfolRepository;
        private readonly IMapper _mapper;

        public GetPortfolioListRequestHandler(IPortfolioRepository portfolRepository, IMapper mapper)
        {
            _portfolRepository = portfolRepository;
            _mapper = mapper;
        }
        public async Task<List<PortfolioDTO>> Handle(GetPortfolioListRequest request, CancellationToken cancellationToken)
        {
            var portfolios = await _portfolRepository.GetAllAsync();
            return _mapper.Map<List<PortfolioDTO>>(portfolios);
        }
    }
}
