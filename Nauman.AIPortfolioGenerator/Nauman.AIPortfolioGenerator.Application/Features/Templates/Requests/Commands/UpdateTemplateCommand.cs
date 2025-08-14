using MediatR;
using Nauman.AIPortfolioGenerator.Application.DTOs.Template;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nauman.AIPortfolioGenerator.Application.Features.Templates.Requests.Commands
{
    public class UpdateTemplateCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public UpdateTemplateDTO templateDTO { get; set; }
    }
}
