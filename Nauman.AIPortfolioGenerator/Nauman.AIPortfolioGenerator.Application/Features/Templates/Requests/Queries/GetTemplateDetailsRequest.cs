using MediatR;
using Nauman.AIPortfolioGenerator.Application.DTOs.Template;
using Nauman.AIPortfolioGenerator.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nauman.AIPortfolioGenerator.Application.Features.Templates.Requests.Queries
{
    public class GetTemplateDetailsRequest : IRequest<CustomQueryResponse<TemplateDTO>>
    {
        public int Id { get; set; }
    }
}
