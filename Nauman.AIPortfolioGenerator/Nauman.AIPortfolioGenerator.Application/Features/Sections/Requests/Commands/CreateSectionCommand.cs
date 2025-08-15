using MediatR;
using Nauman.AIPortfolioGenerator.Application.DTOs.Section;
using Nauman.AIPortfolioGenerator.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nauman.AIPortfolioGenerator.Application.Features.Sections.Requests.Commands
{
    public class CreateSectionCommand : IRequest<CustomCommandResponse>
    {
        public CreateSectionDTO sectionDTO { get; set; }
    }
}
