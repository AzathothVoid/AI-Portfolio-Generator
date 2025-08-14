using MediatR;
using Nauman.AIPortfolioGenerator.Application.DTOs.Portfolio;
using Nauman.AIPortfolioGenerator.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nauman.AIPortfolioGenerator.Application.Features.Portfolios.Requests.Commands
{
    public class CreatePortfolioCommand : IRequest<CustomCommandResponse>
    {
        public CreatePortfolioDTO portfolioDTO { get; set; }
    }
}
