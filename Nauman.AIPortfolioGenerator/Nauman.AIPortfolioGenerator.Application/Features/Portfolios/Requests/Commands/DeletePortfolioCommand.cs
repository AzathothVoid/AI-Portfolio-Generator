using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nauman.AIPortfolioGenerator.Application.Features.Portfolios.Requests.Commands
{
    public class DeletePortfolioCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
