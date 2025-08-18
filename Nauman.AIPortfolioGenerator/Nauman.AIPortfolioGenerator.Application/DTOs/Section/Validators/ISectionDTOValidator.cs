using FluentValidation;
using Nauman.AIPortfolioGenerator.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nauman.AIPortfolioGenerator.Application.DTOs.Section.Validators
{
    public class ISectionDTOValidator : AbstractValidator<ISectionDTO>
    {
        private readonly ITemplateRepository _templateRepostiory;
        private readonly IPortfolioRepository _portfolioRepository;

        public ISectionDTOValidator(ITemplateRepository templateRepostiory, IPortfolioRepository portfolioRepository)
        {
            _templateRepostiory = templateRepostiory;
            _portfolioRepository = portfolioRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} is null")
                .MinimumLength(10).WithMessage("{PropertyName} must be greater than 10 characters")
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters");

            RuleFor(p => p.Type)
                .NotNull().WithMessage("{PropertyName} is null")
                .IsInEnum().WithMessage("{PropertyName} is invalid");

            RuleFor(p => p.Description)
                     .MinimumLength(10).WithMessage("{PropertyName} must be greater than 10 characters");

            RuleFor(p => p.Portfolio)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than {ComparisonValue}")
                .MustAsync(async (id, token) =>
                {
                    var portfolioExists = await _portfolioRepository.Exists(id);
                    return !portfolioExists;
                }).WithMessage("{PeropertyName} does not exists");

            RuleFor(p => p.Template)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than {ComparisonValue}")
                .MustAsync(async (id, token) =>
                {
                    var templateExists = await _templateRepostiory.Exists(id);
                    return !templateExists;
                }).WithMessage("{PeropertyName} does not exists");

            RuleFor(p => p.Data)
                .NotNull().WithMessage("{PropertyName} must not be null")
                .Must(data => data != null && data.Count > 0);
            RuleForEach(p => p.Data)
                .ChildRules(pair =>
                {
                    pair.RuleFor(p => p.Key)
                        .NotEmpty().WithMessage("{PropertyName} is required")
                        .NotNull().WithMessage("{PropertyName} is null");

                    pair.RuleFor(p => p.Value)
                        .NotEmpty().WithMessage("{PropertyName} is required")
                        .NotNull().WithMessage("{PropertyName} is null");
                });
        }
    }
}
