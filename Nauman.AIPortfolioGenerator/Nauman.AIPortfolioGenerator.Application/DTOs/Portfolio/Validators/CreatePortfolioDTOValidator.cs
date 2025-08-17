using FluentValidation;
using Nauman.AIPortfolioGenerator.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nauman.AIPortfolioGenerator.Application.DTOs.Portfolio.Validators
{
    public class CreatePortfolioDTOValidator : AbstractValidator<CreatePortfolioDTO>
    {
        private readonly ITemplateRepository _templateRepository;

        public CreatePortfolioDTOValidator (ITemplateRepository templateRepository)
        {
            _templateRepository = templateRepository;

            Include(new IPortfolioDTOValidator());

            // TODO: Cross Check with Identity to check if the user exists
            RuleFor(p => p.UserId)
                .MustAsync(async (id, token) =>
                {
                    return true;
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
