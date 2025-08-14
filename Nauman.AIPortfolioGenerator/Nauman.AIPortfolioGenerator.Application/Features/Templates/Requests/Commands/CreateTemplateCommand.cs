using MediatR;
using Nauman.AIPortfolioGenerator.Application.DTOs.Template;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nauman.AIPortfolioGenerator.Application.Features.Templates.Requests.Commands
{
    public class CreateTemplateCommand : IRequest<int>
    {
        public CreateTemplateDTO templateDTO { get; set; }
    }
}
