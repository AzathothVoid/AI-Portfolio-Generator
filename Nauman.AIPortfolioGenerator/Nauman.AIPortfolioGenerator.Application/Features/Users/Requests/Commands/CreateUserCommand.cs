using MediatR;
using Nauman.AIPortfolioGenerator.Application.DTOs.User;
using Nauman.AIPortfolioGenerator.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nauman.AIPortfolioGenerator.Application.Features.Users.Requests.Commands
{
    public class CreateUserCommand : IRequest<CustomCommandResponse>
    {
        public CreateUserDTO userDTO { get; set; }
    }
}
