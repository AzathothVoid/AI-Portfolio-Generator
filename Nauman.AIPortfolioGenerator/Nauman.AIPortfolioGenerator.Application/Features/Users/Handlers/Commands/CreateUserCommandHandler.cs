using AutoMapper;
using MediatR;
using Nauman.AIPortfolioGenerator.Application.DTOs.User.Validators;
using Nauman.AIPortfolioGenerator.Application.Features.Users.Requests.Commands;
using Nauman.AIPortfolioGenerator.Application.Persistence;
using Nauman.AIPortfolioGenerator.Application.Contracts.Persistence;
using Nauman.AIPortfolioGenerator.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nauman.AIPortfolioGenerator.Application.Features.Users.Handlers.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateUserDTOValidator();
            var validationResult = await validator.ValidateAsync(request.userDTO);

            if (!validationResult.IsValid)
                throw new Exception();

            var user = _mapper.Map<User>(request.userDTO);

            user.PasswordHash = _passwordHasher.HashPassword(user, request.userDTO.PlainPassword);

            user = await _userRepository.AddAsync(user);

            return user.Id;
        }
    }
}
