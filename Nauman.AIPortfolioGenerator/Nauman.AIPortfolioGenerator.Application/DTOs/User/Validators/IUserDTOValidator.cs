using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nauman.AIPortfolioGenerator.Application.DTOs.User.Validators
{
    public class IUserDTOValidator : AbstractValidator<IUserDTO>
    {
        public IUserDTOValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} is null")
                .MinimumLength(10).WithMessage("{PropertyName} must be greater than {ComparisonValue} characters")
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed{ComparisonValue} characters");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} is null")
                .EmailAddress().WithMessage("{PropertyName} is Invalid");
        }
    }
}
