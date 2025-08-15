using MediatR;
using Nauman.AIPortfolioGenerator.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nauman.AIPortfolioGenerator.Application.Features.Users.Requests.Commands
{
    public class DeleteUserCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
    }
}
