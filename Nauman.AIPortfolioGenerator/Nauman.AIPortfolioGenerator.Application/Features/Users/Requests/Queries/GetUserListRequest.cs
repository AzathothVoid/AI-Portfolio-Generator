using MediatR;
using Nauman.AIPortfolioGenerator.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nauman.AIPortfolioGenerator.Application.Features.Users.Requests.Queries
{
    public class GetUserListRequest : IRequest<List<UserDTO>>
    {
    }
}
