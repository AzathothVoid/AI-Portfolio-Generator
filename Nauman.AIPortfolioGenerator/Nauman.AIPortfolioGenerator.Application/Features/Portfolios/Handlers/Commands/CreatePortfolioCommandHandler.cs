using AutoMapper;
using MediatR;
using Nauman.AIPortfolioGenerator.Domain;
using Nauman.AIPortfolioGenerator.Application.Features.Portfolios.Requests.Commands;
using Nauman.AIPortfolioGenerator.Application.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using Nauman.AIPortfolioGenerator.Application.DTOs.Portfolio.Validators;
using Nauman.AIPortfolioGenerator.Application.Responses;
using System.Linq;

namespace Nauman.AIPortfolioGenerator.Application.Features.Portfolios.Handlers.Commands
{
    public class CreatePortfolioCommandHandler : IRequestHandler<CreatePortfolioCommand, CustomCommandResponse>
    {
        private readonly IPortfolioRepository _portfolioRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITemplateRepository _templateRepository;
        private readonly IMapper _mapper;

        public CreatePortfolioCommandHandler(IPortfolioRepository portfolioRepository, IUserRepository userRepository, ITemplateRepository templateRepository, IMapper mapper)
        {
            _portfolioRepository = portfolioRepository;
            _userRepository = userRepository;
            _templateRepository = templateRepository;
            _mapper = mapper;
        }
        
        public async Task<CustomCommandResponse> Handle(CreatePortfolioCommand request, CancellationToken cancellationToken)
        {
            var response = new CustomCommandResponse();
            var validator = new CreatePortfolioDTOValidator(_userRepository, _templateRepository);
            var validationResult = await validator.ValidateAsync(request.portfolioDTO);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Creation failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                return response;
            }

            var portfolio = _mapper.Map<Portfolio>(request.portfolioDTO);

            portfolio = await _portfolioRepository.AddAsync(portfolio);

            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = portfolio.Id;
            return response;
        }
    }
}
