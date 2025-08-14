using AutoMapper;
using MediatR;
using Nauman.AIPortfolioGenerator.Application.Features.Portfolios.Requests.Commands;
using Nauman.AIPortfolioGenerator.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nauman.AIPortfolioGenerator.Application.Features.Portfolios.Handlers.Commands
{
    public class DeletePortfolioCommandHandler : IRequestHandler<DeletePortfolioCommand, Unit>
    {
        private readonly IPortfolioRepository _portfolioRepository;
        private readonly IMapper _mapper;

        public DeletePortfolioCommandHandler(IPortfolioRepository portfolioRepository, IMapper mapper)
        {
            _portfolioRepository = portfolioRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeletePortfolioCommand request, CancellationToken cancellationToken)
        {
            var portfolio = await _portfolioRepository.GetAsync(request.Id);

            await _portfolioRepository.DeleteAsync(portfolio);

            return Unit.Value;
        }
    }
}
