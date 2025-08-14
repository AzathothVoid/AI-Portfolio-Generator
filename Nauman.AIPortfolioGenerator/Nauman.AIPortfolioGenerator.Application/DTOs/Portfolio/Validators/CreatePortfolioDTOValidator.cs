using FluentValidation;
using Nauman.AIPortfolioGenerator.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nauman.AIPortfolioGenerator.Application.DTOs.Portfolio.Validators
{
    public class CreatePortfolioDTOValidator : AbstractValidator<CreatePortfolioDTO>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITemplateRepository _templateRepository;

        public CreatePortfolioDTOValidator(IUserRepository userRepository, ITemplateRepository templateRepository)
        {
            _userRepository = userRepository;
            _templateRepository = templateRepository;

            Include(new IPortfolioDTOValidator());

            RuleFor(p => p.User)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than {ComparisonValue}")
                .MustAsync(async (id, token) =>
                {
                    var userExists = await _userRepository.Exists(id);
                    return !userExists;
                }).WithMessage("{PeropertyName} does not exists");

            RuleFor(p => p.Template)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than {ComparisonValue}")
                .MustAsync(async (id, token) =>
                {
                    var templateExists = await _templateRepository.Exists(id);
                    return !templateExists;
                }).WithMessage("{PeropertyName} does not exists");
        }
    }
}
