using AutoMapper;
using MediatR;
using Nauman.AIPortfolioGenerator.Application.DTOs.Portfolio.Validators;
using Nauman.AIPortfolioGenerator.Application.Features.Portfolios.Requests.Commands;
using Nauman.AIPortfolioGenerator.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nauman.AIPortfolioGenerator.Application.Features.Portfolios.Handlers.Commands
{
    public class UpdatePortfolioCommandHandler : IRequestHandler<UpdatePortfolioCommand, Unit>
    {
        private readonly IPortfolioRepository _portfolioRepository;
        private readonly IMapper _mapper;

        public UpdatePortfolioCommandHandler(IPortfolioRepository portfolioRepository, IMapper mapper)
        {
            _portfolioRepository = portfolioRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePortfolioCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdatePortfolioDTOValidator();
            var validationResult = await validator.ValidateAsync(request.portfolioDTO);

            if (!validationResult.IsValid)
                throw new Exception();

            var portfolio = await _portfolioRepository.GetAsync(request.Id);

            _mapper.Map(request.portfolioDTO, portfolio);

            await _portfolioRepository.UpdateAsync(portfolio);

            return Unit.Value;
        }
    }
}
