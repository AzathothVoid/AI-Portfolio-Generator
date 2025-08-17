using MediatR;
using Nauman.AIPortfolioGenerator.Application.DTOs.Section;
using Nauman.AIPortfolioGenerator.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Sections.Requests.Queries
{
    public class GetSectionListRequest : IRequest<CustomQueryResponse<List<SectionDTO>>>
    {
    }
}
