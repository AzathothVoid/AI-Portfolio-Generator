using AutoMapper;
using MediatR;
using Nauman.AIPortfolioGenerator.Application.Features.Users.Requests.Commands;
using Nauman.AIPortfolioGenerator.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Nauman.AIPortfolioGenerator.Application.Responses;

namespace Nauman.AIPortfolioGenerator.Application.Features.Users.Handlers.Commands
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, BaseResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public DeleteUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();
            var user = await _userRepository.GetAsync(request.Id);

            await _userRepository.DeleteAsync(user);

            response.Success = true;
            response.Message = "Deletion Successful";
            return response;
        }
    }
}
