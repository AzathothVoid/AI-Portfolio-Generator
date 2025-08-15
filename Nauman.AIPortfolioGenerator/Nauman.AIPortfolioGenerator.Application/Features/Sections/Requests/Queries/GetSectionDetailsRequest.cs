using MediatR;
using Nauman.AIPortfolioGenerator.Application.DTOs.Section;
using Nauman.AIPortfolioGenerator.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nauman.AIPortfolioGenerator.Application.Features.Sections.Requests.Queries
{
    public class GetSectionDetailsRequest : IRequest<CustomQueryResponse<SectionDTO>>
    {
        public int Id { get; set; }
    }
}
