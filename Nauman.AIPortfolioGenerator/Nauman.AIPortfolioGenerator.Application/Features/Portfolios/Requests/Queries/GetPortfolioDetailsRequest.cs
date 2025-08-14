using MediatR;
using Nauman.AIPortfolioGenerator.Application.DTOs.Portfolio;
using Nauman.AIPortfolioGenerator.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nauman.AIPortfolioGenerator.Application.Features.Portfolios.Requests.Queries
{
    public class GetPortfolioDetailsRequest : IRequest<CustomQueryResponse<PortfolioDTO>>
    {
        public int id { get; set; }
    }
}
