using Application.Responses.Common;
using MediatR;
using Nauman.AIPortfolioGenerator.Application.DTOs.Portfolio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nauman.AIPortfolioGenerator.Application.Features.Portfolios.Requests.Commands
{
    public class UpdatePortfolioCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public UpdatePortfolioDTO portfolioDTO { get; set; }
    }
}
