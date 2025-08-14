using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nauman.AIPortfolioGenerator.Application.Features.Templates.Requests.Commands
{
    public class DeleteTemplateCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
