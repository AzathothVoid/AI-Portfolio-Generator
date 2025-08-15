using MediatR;
using Nauman.AIPortfolioGenerator.Application.DTOs.Template;
using Nauman.AIPortfolioGenerator.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nauman.AIPortfolioGenerator.Application.Features.Templates.Requests.Queries
{
    public class GetTemplateListRequest : IRequest<CustomQueryResponse<List<TemplateDTO>>>
    {
    }
}
