using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nauman.AIPortfolioGenerator.Application.DTOs.Template.Validators
{
    public class CreateTemplateDTOValidator : AbstractValidator<CreateTemplateDTO>
    {
        public CreateTemplateDTOValidator()
        {
            Include(new ITemplateDTOValidator());
        }
    }
}
