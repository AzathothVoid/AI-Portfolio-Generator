using AutoMapper;
using MediatR;
using Nauman.AIPortfolioGenerator.Application.Contracts.Persistence;
using Nauman.AIPortfolioGenerator.Application.DTOs.User;
using Nauman.AIPortfolioGenerator.Application.Features.Users.Requests.Queries;
using Nauman.AIPortfolioGenerator.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nauman.AIPortfolioGenerator.Application.Features.Users.Handlers.Queries
{
    public class GetUserListRequestHandler : IRequestHandler<GetUserListRequest, CustomQueryResponse<List<UserDTO>>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserListRequestHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<CustomQueryResponse<List<UserDTO>>> Handle(GetUserListRequest request, CancellationToken cancellationToken)
        {
            var response = new CustomQueryResponse<List<UserDTO>>();
            var users = await _userRepository.GetAllAsync();

            response.Success = true;
            response.Message = "GET Successful";
            response.Data = _mapper.Map<List<UserDTO>>(users);
            return response;
        }
    }
}
