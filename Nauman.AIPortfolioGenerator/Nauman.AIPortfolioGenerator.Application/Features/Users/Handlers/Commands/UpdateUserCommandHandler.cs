using AutoMapper;
using MediatR;
using Nauman.AIPortfolioGenerator.Application.Contracts.Persistence;
using Nauman.AIPortfolioGenerator.Application.DTOs.User.Validators;
using Nauman.AIPortfolioGenerator.Application.Features.Users.Requests.Commands;
using Nauman.AIPortfolioGenerator.Application.Persistence;
using Nauman.AIPortfolioGenerator.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nauman.AIPortfolioGenerator.Application.Features.Users.Handlers.Commands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, BaseResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();
            var validator = new UpdateUserCommandValidator(
                new UpdateUserDTOValidator(),
                new ChangeUserPasswordDTOValidator(),
                new ChangeUserPremiumStatusDTOValidator()
                );

            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Update failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                return response;
            }

            var user = await _userRepository.GetAsync(request.Id);

            if (request.userDTO != null)
            {
                _mapper.Map(request.userDTO, user);

                await _userRepository.UpdateAsync(user);

            } else if (request.changePasswordDTO != null)
            {
                user.PasswordHash = _passwordHasher.HashPassword(user, request.changePasswordDTO.PlainPassword);

            } else if (request.changePremiumStatusDTO != null)
            {
                await _userRepository.ChangePremiumStatus(user, request.changePremiumStatusDTO.isPremium);
            }

            response.Success = true;
            response.Message = "Update Successful";
            return response;
        }
    }
}
