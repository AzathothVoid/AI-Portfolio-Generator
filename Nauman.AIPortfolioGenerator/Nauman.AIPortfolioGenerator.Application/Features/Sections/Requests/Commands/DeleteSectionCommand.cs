using Application.Responses.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nauman.AIPortfolioGenerator.Application.Features.Sections.Requests.Commands
{
    public class DeleteSectionCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; } 
    }
}
