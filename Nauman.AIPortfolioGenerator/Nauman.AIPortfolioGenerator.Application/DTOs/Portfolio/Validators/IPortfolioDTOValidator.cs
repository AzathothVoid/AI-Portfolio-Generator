using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nauman.AIPortfolioGenerator.Application.DTOs.Portfolio.Validators
{
    public class IPortfolioDTOValidator : AbstractValidator<IPortfolioDTO>
    {
        public IPortfolioDTOValidator()
        {
            RuleFor(p => p.Title)
              .NotEmpty().WithMessage("{PropertyName} is required")
              .NotNull().WithMessage("{PropertyName} is null")
              .MinimumLength(10).WithMessage("{PropertyName} must be greater than 10 characters")
              .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters");

            RuleFor(p => p.Slug)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} is null")
                .MinimumLength(10).WithMessage("{PropertyName} must be greater than 10 characters");

        }
    }
}
