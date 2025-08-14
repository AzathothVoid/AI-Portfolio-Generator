using MediatR;
using Nauman.AIPortfolioGenerator.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nauman.AIPortfolioGenerator.Application.Features.Users.Requests.Commands
{
    public class UpdateUserCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public UpdateUserDTO? userDTO { get; set; }
        public ChangeUserPasswordDTO? changePasswordDTO { get; set; }
        public ChangeUserPremiumStatusDTO? changePremiumStatusDTO { get; set; }
    }
}
