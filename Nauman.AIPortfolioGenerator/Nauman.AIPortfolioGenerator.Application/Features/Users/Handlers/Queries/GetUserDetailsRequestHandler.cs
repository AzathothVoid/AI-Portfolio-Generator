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
    public class GetUserDetailsRequestHandler : IRequestHandler<GetUserDetailsRequest, UserDTO>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserDetailsRequestHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDTO> Handle(GetUserDetailsRequest request, CancellationToken cancellationToken)
        {
            var userDetails = await _userRepository.GetAsync(request.Id);

            return _mapper.Map<UserDTO>(userDetails);
        }
    }
}
