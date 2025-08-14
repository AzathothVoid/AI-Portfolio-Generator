using FluentValidation;
using Nauman.AIPortfolioGenerator.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nauman.AIPortfolioGenerator.Application.DTOs.Section.Validators
{
    public class CreateSectionDTOValidator : AbstractValidator<CreateSectionDTO>
    {
        private readonly ITemplateRepository _templateRepostiory;
        private readonly IPortfolioRepository _portfolioRepository;

        public CreateSectionDTOValidator(ITemplateRepository templateRepostiory, IPortfolioRepository portfolioRepository)
        {
            _templateRepostiory = templateRepostiory;
            _portfolioRepository = portfolioRepository;

            Include(new ISectionDTOValidator(templateRepostiory, portfolioRepository));
        }
    }
}
