using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Nauman.AIPortfolioGenerator.Application.DTOs.Portfolio;

namespace Nauman.AIPortfolioGenerator.Application.Features.Portfolios.Requests.Queries
{
    public class GetPortfolioListRequest : IRequest<List<PortfolioDTO>>
    {

    }
}
