using AutoMapper;
using MediatR;
using Nauman.AIPortfolioGenerator.Application.Features.Portfolios.Requests.Commands;
using Nauman.AIPortfolioGenerator.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Nauman.AIPortfolioGenerator.Application.Responses;

namespace Nauman.AIPortfolioGenerator.Application.Features.Portfolios.Handlers.Commands
{
    public class DeletePortfolioCommandHandler : IRequestHandler<DeletePortfolioCommand, BaseResponse>
    {
        private readonly IPortfolioRepository _portfolioRepository;
        private readonly IMapper _mapper;

        public DeletePortfolioCommandHandler(IPortfolioRepository portfolioRepository, IMapper mapper)
        {
            _portfolioRepository = portfolioRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(DeletePortfolioCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();
            var portfolio = await _portfolioRepository.GetAsync(request.Id);

            await _portfolioRepository.DeleteAsync(portfolio);

            response.Success = true;
            response.Message = "Deletion Successful";
            return response;
        }
    }
}
