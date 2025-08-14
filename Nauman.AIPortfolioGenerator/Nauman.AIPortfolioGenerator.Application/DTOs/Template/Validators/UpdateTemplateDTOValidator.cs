using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nauman.AIPortfolioGenerator.Application.DTOs.Template.Validators
{
    public class UpdateTemplateDTOValidator : AbstractValidator<UpdateTemplateDTO>
    {
        public UpdateTemplateDTOValidator()
        {
            Include(new ITemplateDTOValidator());
        }
    }
}
