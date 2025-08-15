using AutoMapper;
using MediatR;
using Nauman.AIPortfolioGenerator.Application.Contracts.Persistence;
using Nauman.AIPortfolioGenerator.Application.DTOs.Template;
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
    public class GetUserDetailsRequestHandler : IRequestHandler<GetUserDetailsRequest, CustomQueryResponse<UserDTO>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserDetailsRequestHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<CustomQueryResponse<UserDTO>> Handle(GetUserDetailsRequest request, CancellationToken cancellationToken)
        {
            var response = new CustomQueryResponse<UserDTO>();
            var userDetails = await _userRepository.GetAsync(request.Id);

            response.Success = true;
            response.Message = "GET Successful";
            response.Data = _mapper.Map<UserDTO>(userDetails);
            return response;
        }
    }
}
