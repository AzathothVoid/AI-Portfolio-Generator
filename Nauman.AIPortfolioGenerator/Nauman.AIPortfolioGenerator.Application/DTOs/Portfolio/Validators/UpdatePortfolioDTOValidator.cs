using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nauman.AIPortfolioGenerator.Application.DTOs.Portfolio.Validators
{
    public class UpdatePortfolioDTOValidator : AbstractValidator<UpdatePortfolioDTO>
    {
        public UpdatePortfolioDTOValidator()
        {
            Include(new IPortfolioDTOValidator());
        }
    }
}
