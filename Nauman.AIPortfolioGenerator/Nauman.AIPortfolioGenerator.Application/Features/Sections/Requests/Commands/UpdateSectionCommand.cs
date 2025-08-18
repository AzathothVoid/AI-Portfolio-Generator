using Application.Responses.Common;
using MediatR;
using Nauman.AIPortfolioGenerator.Application.DTOs.Section;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nauman.AIPortfolioGenerator.Application.Features.Sections.Requests.Commands
{
    public class UpdateSectionCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public UpdateSectionDTO sectionDTO { get; set; }
    }
}
