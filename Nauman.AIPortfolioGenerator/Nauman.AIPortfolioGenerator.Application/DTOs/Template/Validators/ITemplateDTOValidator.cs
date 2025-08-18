using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nauman.AIPortfolioGenerator.Application.DTOs.Template.Validators
{
    public class ITemplateDTOValidator : AbstractValidator<ITemplateDTO>
    {
        public ITemplateDTOValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} is null")
                .MinimumLength(10).WithMessage("{PropertyName} must be greater than 10 characters")
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters");

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} is null")
                .MinimumLength(50).WithMessage("{PropertyName} must be greater than 50 characters");

            RuleForEach(p => p.Keywords)
                .ChildRules(p =>
                {
                    p.RuleFor(p => p)
                        .MinimumLength(3).WithMessage("{PropertyName} must be greater than 3 characters")
                        .MaximumLength(20).WithMessage("{PropertyName} must not exceed 20 characters"); 
                });

            RuleFor(p => p.Themes)
                .NotNull().WithMessage("{PropertyName} must not be null")
                .Must(data => data != null && data.Length > 0);
            RuleForEach(p => p.Themes)
                .ChildRules(p =>
                {
                    p.RuleFor(p => p)
                        .MinimumLength(3).WithMessage("{PropertyName} must be greater than 3 characters")
                        .MaximumLength(20).WithMessage("{PropertyName} must not exceed 20 characters");
                });

            RuleFor(p => p.Palette)
                .NotNull().WithMessage("{PropertyName} must not be null")
                .Must(data => data != null && data.Length > 0);
            RuleForEach(p => p.Palette)
                .ChildRules(p =>
                {
                    p.RuleFor(p => p)
                        .MinimumLength(3).WithMessage("{PropertyName} must be greater than 3 characters")
                        .MaximumLength(20).WithMessage("{PropertyName} must not exceed 20 characters");
                });
        }
    }
}
