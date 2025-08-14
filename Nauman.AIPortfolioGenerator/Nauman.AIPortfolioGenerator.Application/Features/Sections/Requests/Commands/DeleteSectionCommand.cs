using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nauman.AIPortfolioGenerator.Application.Features.Sections.Requests.Commands
{
    public class DeleteSectionCommand : IRequest<Unit>
    {
        public int Id { get; set; } 
    }
}
