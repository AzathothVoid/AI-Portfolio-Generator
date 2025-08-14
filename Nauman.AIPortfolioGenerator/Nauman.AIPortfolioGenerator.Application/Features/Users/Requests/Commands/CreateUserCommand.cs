using MediatR;
using Nauman.AIPortfolioGenerator.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nauman.AIPortfolioGenerator.Application.Features.Users.Requests.Commands
{
    public class CreateUserCommand : IRequest<int>
    {
        public CreateUserDTOcs userDTO { get; set; }
    }
}
