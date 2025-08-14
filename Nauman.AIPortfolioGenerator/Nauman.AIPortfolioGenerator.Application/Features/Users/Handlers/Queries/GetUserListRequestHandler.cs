using AutoMapper;
using MediatR;
using Nauman.AIPortfolioGenerator.Application.DTOs.User;
using Nauman.AIPortfolioGenerator.Application.Features.Users.Requests.Queries;
using Nauman.AIPortfolioGenerator.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nauman.AIPortfolioGenerator.Application.Features.Users.Handlers.Queries
{
    public class GetUserListRequestHandler : IRequestHandler<GetUserListRequest, List<UserDTO>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserListRequestHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserDTO>> Handle(GetUserListRequest request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync();

            return _mapper.Map<List<UserDTO>>(users);
        }
    }
}
