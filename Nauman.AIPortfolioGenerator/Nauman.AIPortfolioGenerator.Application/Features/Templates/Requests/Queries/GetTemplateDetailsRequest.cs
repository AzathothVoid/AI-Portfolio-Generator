using MediatR;
using Nauman.AIPortfolioGenerator.Application.DTOs.Template;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nauman.AIPortfolioGenerator.Application.Features.Templates.Requests.Queries
{
    public class GetTemplateDetailsRequest : IRequest<TemplateDTO>
    {
        public int Id { get; set; }
    }
}
